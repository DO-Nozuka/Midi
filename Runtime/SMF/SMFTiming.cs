using System;
using System.Collections.Generic;

namespace Dono.Midi
{
    /// <summary>
    /// データ生成時はTotalDeltaTimeだけを格納
    /// タイミングイベントのリストを初期化
    /// </summary>
    public class SMFTiming
    {
        public int Measure { get; private set; }
        public int Tick { get; private set; }
        /// <summary>
        /// in MicroSec
        /// </summary>
        public float RealTime { get; private set; }

        public int TotalDeltaTime { get; private set; }
        public int Division { get; private set; }

        public SMFTiming(int totalDeltaTime, int division)
        {
            TotalDeltaTime = totalDeltaTime;
            Division = division;
        }

        public SMFTiming(int totalDeltaTime, int division, List<SMFEvent> tempoEvents, List<SMFEvent> changeBeatEvents) : this(totalDeltaTime, division)
        {
            UpdateRealTime(this, tempoEvents, division);
            UpdateMeasureTick(this, changeBeatEvents, division);
        }

        private void SetMeasureTick(int measure, int tick)
        {
            Measure = measure;
            Tick = tick;
        }

        //private void SetRealTime(float realTime)
        //{
        //    RealTime = realTime;
        //}

        /// <summary>
        /// tempoEventsとchangeBeatEventsを元にmessagesのMeasure/Tick/RealTimeを初期化する
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="tempoEvents"></param>
        /// <param name="changeBeatEvents"></param>
        public static void InitializeTimes(List<SMFEvent> messages, List<SMFEvent> tempoEvents, List<SMFEvent> changeBeatEvents, int division)
        {
            foreach (var message in messages)
            {
                UpdateRealTime(message, tempoEvents, division);
                UpdateMeasureTick(message, changeBeatEvents, division);
            }
        }

        /// <summary>
        /// tempoEventsとchangeBeatEventsのMeasure/Tick/RealTimeを初期化する
        /// </summary>
        /// <param name="tempoEvents">テンポ指示メッセージリスト</param>
        /// <param name="changeBeatEvents">拍子メッセージリスト</param>
        public static void InitializeTimingEvents(List<SMFEvent> tempoEvents, List<SMFEvent> changeBeatEvents, int division)
        {
            /*                    Measure/Tick RealTime
             * ChangeBeatEvents        ●         ×
             * tempoEvnets             ×         ●
             * ●の2箇所を先に計算する
             */
            UpdateChangeBeatMeasureTick(changeBeatEvents, division);
            UpdateTempoRealTime(tempoEvents, division);

            /*                    Measure/Tick RealTime
             * ChangeBeatEvents        〇         ●
             * tempoEvnets             ●         〇
             * ●を計算する
             */
            foreach(var changeBeatEvent in changeBeatEvents)
            {
                UpdateRealTime(changeBeatEvent, tempoEvents, division);
            }
            foreach(var tempoEvent in tempoEvents)
            {
                UpdateMeasureTick(tempoEvent, changeBeatEvents, division);
            }
        }


        /* Update RealTime */
        private static void UpdateTempoRealTime(List<SMFEvent> tempoEvents, int division)
        {
            // nullチェック
            if (tempoEvents == null)
                throw new FormatException();

            // 要素数チェック
            if (tempoEvents.Count == 0)
                throw new FormatException();

            // 0に要素があるか
            if (!tempoEvents.Exists(n => n.Timing.TotalDeltaTime == 0))
                throw new FormatException();

            // ソート
            tempoEvents.Sort((n, m) => n.Timing.TotalDeltaTime - m.Timing.TotalDeltaTime);

            // tempoEventsのRealTimeを更新
            tempoEvents[0].Timing.RealTime = 0.0f;

            for (int i = 1; i < tempoEvents.Count; i++)
            {
                var QuarterNoteLength = tempoEvents[i - 1].Message.QuarterNoteLength;

                float diffDeltaTime = tempoEvents[i].Timing.TotalDeltaTime - tempoEvents[i - 1].Timing.TotalDeltaTime;
                float diffQuarterNoteCount = diffDeltaTime / division;
                float diffRealTime = diffQuarterNoteCount * QuarterNoteLength;

                tempoEvents[i].Timing.RealTime = tempoEvents[i - 1].Timing.RealTime + diffRealTime;
            }
        }
        private static void UpdateRealTime(SMFEvent smfEvent, List<SMFEvent> tempoEvents, int division)
        {
            // nullチェック
            if (smfEvent == null)
                throw new FormatException();


            UpdateRealTime(smfEvent.Timing, tempoEvents, division);
        }

        private static void UpdateRealTime(SMFTiming smfTiming, List<SMFEvent> tempoEvents, int division)
        {
            // 値の範囲チェック
            if (smfTiming.TotalDeltaTime < 0)
                throw new FormatException();

            // 一番近いTempoを見つける
            SMFEvent nearestTimingEvent = tempoEvents[tempoEvents.Count - 1];
            for (int i = 0; i < tempoEvents.Count; i++)
            {
                if (smfTiming.TotalDeltaTime == tempoEvents[i].Timing.TotalDeltaTime)
                {
                    // 同じ場合は計算せずに返す
                    smfTiming.RealTime = tempoEvents[i].Timing.RealTime;
                    return;
                }
                else if (smfTiming.TotalDeltaTime < tempoEvents[i].Timing.TotalDeltaTime)
                {
                    nearestTimingEvent = tempoEvents[i - 1];
                    break;
                }
            }

            // 一番近いTempoとの差分を計算する
            var QuarterNoteLength = nearestTimingEvent.Message.QuarterNoteLength;
            float diffDeltaTime = smfTiming.TotalDeltaTime - nearestTimingEvent.Timing.TotalDeltaTime;
            float diffQuarterNoteCount = diffDeltaTime / division;
            float diffRealTime = diffQuarterNoteCount * QuarterNoteLength;

            smfTiming.RealTime = nearestTimingEvent.Timing.RealTime + diffRealTime;
        }

        /* Update MeasureTick */
        private static void UpdateChangeBeatMeasureTick(List<SMFEvent> changeBeatEvents, int division)
        {
            // nullチェック
            if (changeBeatEvents == null)
                throw new FormatException();

            // 要素数チェック
            if (changeBeatEvents.Count == 0)
                throw new FormatException();

            // 0に要素があるか
            if (!changeBeatEvents.Exists(n => n.Timing.TotalDeltaTime == 0))
                throw new FormatException();

            // ソート
            changeBeatEvents.Sort((n, m) => n.Timing.TotalDeltaTime - m.Timing.TotalDeltaTime);

            // changeBeatEventsのMeasure/Tickを更新
            changeBeatEvents[0].Timing.SetMeasureTick(1, 0);

            for (int i = 1; i < changeBeatEvents.Count; i++)
            {
                int diffDeltaTime = changeBeatEvents[i].Timing.TotalDeltaTime - changeBeatEvents[i - 1].Timing.TotalDeltaTime + changeBeatEvents[i - 1].Timing.Tick;
                int oneMeasureTime = (int)((changeBeatEvents[i - 1].Message.Bytes[3] / Math.Pow(2, changeBeatEvents[i - 1].Message.Bytes[4])) * 4 * division);

                int diffMeasure = diffDeltaTime / oneMeasureTime;
                int measure = changeBeatEvents[i - 1].Timing.Measure + diffMeasure;
                int tick = diffDeltaTime - (oneMeasureTime * diffMeasure);

                changeBeatEvents[i].Timing.SetMeasureTick(measure, tick);
            }
        }

        private static void UpdateMeasureTick(SMFEvent smfEvent, List<SMFEvent> changeBeatEvents, int division)
        {
            // nullチェック
            if (smfEvent == null)
                throw new FormatException();

            UpdateMeasureTick(smfEvent.Timing, changeBeatEvents, division);
        }

        private static void UpdateMeasureTick(SMFTiming smfTiming, List<SMFEvent> changeBeatEvents, int division)
        {
            // 値の範囲チェック
            if (smfTiming.TotalDeltaTime < 0)
                throw new FormatException();

            // 一番近いchangeBeatEventを見つける
            SMFEvent nearestChangeBeatEvent = changeBeatEvents[changeBeatEvents.Count - 1];
            for (int i = 0; i < changeBeatEvents.Count; i++)
            {
                if (smfTiming.TotalDeltaTime == changeBeatEvents[i].Timing.TotalDeltaTime)
                {
                    // 同じ場合は計算せずに返す
                    smfTiming.SetMeasureTick(changeBeatEvents[i].Timing.Measure, changeBeatEvents[i].Timing.Tick);
                    return;
                }
                else if (smfTiming.TotalDeltaTime < changeBeatEvents[i].Timing.TotalDeltaTime)
                {
                    nearestChangeBeatEvent = changeBeatEvents[i - 1];
                    break;
                }
            }

            // 一番近い changeBeatEvents との差分を計算する
            int diffDeltaTime = smfTiming.TotalDeltaTime - nearestChangeBeatEvent.Timing.TotalDeltaTime + nearestChangeBeatEvent.Timing.Tick;
            int oneMeasureTime = (int)((nearestChangeBeatEvent.Message.Bytes[3] / Math.Pow(2, nearestChangeBeatEvent.Message.Bytes[4])) * 4 * division);

            int diffMeasure = diffDeltaTime / oneMeasureTime;
            int measure = nearestChangeBeatEvent.Timing.Measure + diffMeasure;
            int tick = diffDeltaTime - (oneMeasureTime * diffMeasure);

            smfTiming.SetMeasureTick(measure, tick);
        }


        public override string ToString()
        {
            return $"DT:{TotalDeltaTime:d8}, MT:{Measure:d3}:{Tick:d4}, {RealTime / 1000000 :f3}";
        }
    }
}