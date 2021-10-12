using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Dono.Midi.Runtime
{
    public class StandardMidiFile
    {
        public SMFInfo Info;
        public SMFTrack ConductorTrack;
        public List<SMFScore> Scores;

        private bool IsDebugMode = true;

        public StandardMidiFile(byte[] data)
        {
            if (IsDebugMode) Debug.Log("[SMF]Start to Initialize.");

            // 初期化
            int _index = 0;

            // ヘッダーチャンク
            if (IsDebugMode) Debug.Log("[SMF]Start InitHeaderChunk.");
            InitHeaderChunk(data, ref _index, out Info);

            // Trackを全てTracksに格納する
            if (IsDebugMode) Debug.Log("[SMF]Start to load tracks.");
            List<SMFTrack> tracks = new List<SMFTrack>();
            for (int i = 0; i < Info.TrackCount; i++)
            {
                if (IsDebugMode) Debug.Log($"[SMF]Start to load Track[{i}].");
                tracks.Add(GetTrackChunk(data, ref _index));
            }

            // ConcuctorTrackを探して入れる
            if (IsDebugMode) Debug.Log($"[SMF]Start to find ConductorTrack.");
            ConductorTrack = tracks.Find(n => n.TrackType == SMFTrackType.Conductor);
            if (ConductorTrack == null) throw new FormatException();

            // TimingEventを初期化する
            if (IsDebugMode) Debug.Log($"[SMF]Start to Get TimingEvent.");
            List<SMFEvent> tempoEvents = ConductorTrack.Messages.FindAll((n) => n.Message.metaEventType == Types.MetaEventType.SetTempo);
            List<SMFEvent> changeBeatEvents = ConductorTrack.Messages.FindAll((n) => n.Message.metaEventType == Types.MetaEventType.TimeSignature);
            int division = Info.Division;
            if (IsDebugMode) Debug.Log($"[SMF]Start to InitializeTimingEvents.");
            SMFTiming.InitializeTimingEvents(tempoEvents, changeBeatEvents, division);

            // TrackのTimingを全て更新する
            if (IsDebugMode) Debug.Log($"[SMF]Start to Reset AllEvents.");
            List<SMFEvent> notTimingEvents = new List<SMFEvent>();
            foreach(var track in tracks)
            {
                notTimingEvents.AddRange(track.Messages);
            }
            notTimingEvents.RemoveAll((n) => n.Message.metaEventType == Types.MetaEventType.SetTempo || n.Message.metaEventType == Types.MetaEventType.TimeSignature);
            SMFTiming.InitializeTimes(notTimingEvents, tempoEvents, changeBeatEvents, division);

            // Scoreに分ける
            if (IsDebugMode) Debug.Log($"[SMF]Start to Separate by Score.");
            Scores = new List<SMFScore>();
            foreach (var track in tracks)
            {                
                var samePortScore = Scores.Find((s) => s.PortNum == track.Port);
                switch (track.TrackType)
                {
                    case SMFTrackType.Conductor:
                        // NOP
                        break;
                    case SMFTrackType.ScoreSetup:
                        if (samePortScore == null)
                        {
                            Scores.Add(new SMFScore());
                        }
                        else
                        {
                            samePortScore.ScoreSetupTrack = track;
                        }
                        break;
                    case SMFTrackType.Part:
                        if (samePortScore == null)
                        {
                            samePortScore = new SMFScore();
                            Scores.Add(samePortScore);
                        }
                        samePortScore.PartTracks.Add(track);
                        break;
                }
            }

            // forDebugLog
            if (!IsDebugMode) return;

            List<SMFEvent> allEvents = new List<SMFEvent>();
            foreach (var track in tracks)
            {
                StringBuilder strBuilder = new StringBuilder("");
                foreach (var @event in track.Messages)
                {
                    strBuilder.Append(@event.Timing.ToString());
                    strBuilder.Append(' ', 2);
                    strBuilder.Append(@event.Message.ToString());
                    strBuilder.Append('\n');
                }
                Debug.Log(strBuilder.ToString());
            }

            //StringBuilder sb = new StringBuilder("");
            //foreach (var @event in allEvents)
            //{
            //    sb.Append(@event.Timing.ToString());
            //    sb.Append(' ');
            //    sb.Append(@event.Message.ToString());
            //    sb.Append('\n');
            //}
            //Debug.Log(sb.ToString());


        }

        private void InitHeaderChunk(byte[] data, ref int index, out SMFInfo info)
        {
            // チャンクID
            int CHUNK_ID_LENGTH = 4;
            byte[] _chunkID = new byte[CHUNK_ID_LENGTH];
            Array.Copy(data, index, _chunkID, 0, CHUNK_ID_LENGTH);
            index += CHUNK_ID_LENGTH;

            byte[] mTrk = { (byte)'M', (byte)'T', (byte)'h', (byte)'d' };
            if (!_chunkID.SequenceEqual(mTrk)) throw new FormatException();

            // チャンクサイズ
            int CHUNK_SIZE_LENGTH = 4;
            byte[] _chunkSizeByte = new byte[CHUNK_SIZE_LENGTH];
            Array.Copy(data, index, _chunkSizeByte, 0, CHUNK_SIZE_LENGTH);
            index += CHUNK_SIZE_LENGTH;

            byte[] trueSizeByte = { 0x00, 0x00, 0x00, 0x06 };
            if (!_chunkSizeByte.SequenceEqual(trueSizeByte)) throw new FormatException();

            // フォーマット
            int MIDI_FORMAT_LENGTH = 2;
            byte[] _midiFormat = new byte[MIDI_FORMAT_LENGTH];
            Array.Copy(data, index, _midiFormat, 0, MIDI_FORMAT_LENGTH);
            index += MIDI_FORMAT_LENGTH;

            int midiFormat = (_midiFormat[0] << 8) + (_midiFormat[1] << 0);
            if (!(midiFormat == 0 || midiFormat == 1 || midiFormat == 2)) throw new FormatException();

            // トラック数
            int TRACK_COUNT_LENGTH = 2;
            byte[] _trackCount = new byte[TRACK_COUNT_LENGTH];
            Array.Copy(data, index, _trackCount, 0, TRACK_COUNT_LENGTH);
            index += TRACK_COUNT_LENGTH;

            int trackCount = (_trackCount[0] << 8) + (_trackCount[1] << 0);
            if (trackCount < 0) throw new FormatException();

            // 分解能
            int DIVISION_LENGTH = 2;
            byte[] _division = new byte[DIVISION_LENGTH];
            Array.Copy(data, index, _division, 0, DIVISION_LENGTH);
            index += DIVISION_LENGTH;

            int division = (_division[0] << 8) + (_division[1] << 0);
            if (division < 0) throw new FormatException();

            //SMFInfo
            info = new SMFInfo(midiFormat, trackCount, division);
        }
        private SMFTrack GetTrackChunk(byte[] data, ref int index)
        {
            // チャンクID
            int CHUNK_ID_LENGTH = 4;
            byte[] _chunkID = new byte[CHUNK_ID_LENGTH];
            Array.Copy(data, index, _chunkID, 0, CHUNK_ID_LENGTH);
            index += CHUNK_ID_LENGTH;

            byte[] mTrk = { (byte)'M', (byte)'T', (byte)'r', (byte)'k' };
            if (!_chunkID.SequenceEqual(mTrk)) throw new FormatException();

            // チャンクサイズ
            int CHUNK_SIZE_LENGTH = 4;
            byte[] _chunkSizeByte = new byte[CHUNK_SIZE_LENGTH];
            Array.Copy(data, index, _chunkSizeByte, 0, CHUNK_SIZE_LENGTH);
            index += CHUNK_SIZE_LENGTH;

            int chunkSize = ByteArrayToInt32(_chunkSizeByte);

            int startIndex = index;
            int totalDeltaTime = 0;
            List<SMFEvent> smfMessages = new List<SMFEvent>();
            while ((index - startIndex) < chunkSize)
            {
                //if (IsDebugMode) Debug.Log($"[SMF]Track:{index - startIndex}/{chunkSize}");
                //デルタタイムの取得
                int deltaTime = VariableLengthDataToInt32(data, ref index);
                totalDeltaTime += deltaTime;
                SMFTiming timing = new SMFTiming(totalDeltaTime);

                //イベントの取得
                int dataLength = GetMessageLength(data, index);
                byte[] messagBytes = new byte[dataLength];
                Array.Copy(data, index, messagBytes, 0, dataLength);
                index += dataLength;

                MidiMessage message = new MidiMessage(messagBytes);


                smfMessages.Add(new SMFEvent(timing, message));
            }

            return new SMFTrack(smfMessages);
        }

        public static Int32 VariableLengthDataToInt32(byte[] data, ref int index)
        {
            Int32 result = 0;
            do
            {
                result = result << 7;
                result += data[index] & 0b01111111;
                index++;
            } while (index < data.Length && ((data[index - 1] & 0b10000000) != 0));

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="big">true: ビッグエンディアン</param>
        /// <returns></returns>
        public static int ByteArrayToInt32(byte[] data, bool big = true)
        {
            if (big)
            {
                byte[] flipData = new byte[data.Length];

                //反転する
                for (int i = 0; i < data.Length; i++)
                {
                    flipData[i] = data[data.Length - i - 1];
                }

                return BitConverter.ToInt32(flipData, 0);
            }
            else
                return BitConverter.ToInt32(data, 0);
        }

        /// <summary>
        /// For SMF MidiMessage
        /// </summary>
        /// <param name="data"></param>
        /// <param name="messageLength"></param>
        /// <param name="isSMF"></param>
        /// <returns></returns>
        public static int GetMessageLength(byte[] data, int index)
        {
            int messageLength = 0;

            switch (data[index] & 0xF0)
            {
                case 0x80:
                case 0x90:
                case 0xA0:
                case 0xB0:
                case 0xE0:
                    messageLength = 3;
                    break;

                case 0xC0:
                case 0xD0:
                    messageLength = 2;
                    break;

                case 0xF0:
                    switch (data[index])
                    {
                        case 0xF0:
                            // SMF:  F0h <Length> <Data> F7h
                            // MIDI: F0h <Data> F7h
                            // <Length>は<Data>とF7hのバイト数
                            // messageLengthは全体のバイト数

                            //SMFの場合のアルゴリズム
                            int i = 1;
                            int length = VariableLengthDataToInt32(data, ref i);

                            messageLength = 1 + (i - 1) + length;
                            break;
                        case 0xF1:
                            messageLength = 2;
                            break;
                        case 0xF2:
                            messageLength = 3;
                            break;
                        case 0xF3:
                            messageLength = 2;
                            break;
                        case 0xF4:
                        case 0xF5:
                        case 0xF6:
                        case 0xF7:
                            messageLength = 1;
                            break;
                        case 0xF8:
                        case 0xF9:
                        case 0xFA:
                        case 0xFB:
                        case 0xFC:
                        case 0xFD:
                        case 0xFE:
                            messageLength = 1;
                            break;
                        case 0xFF:
                            messageLength = data[index + 2] + 3;
                            break;
                    }
                    break;
                default:
                    throw new Exception();
            }

            return messageLength;
        }
    }

    public class SMFInfo
    {
        //分解能
        //フォーマット(1以外受け付けないけど。)
        //トラック数(計算すれば出るから不要)
        public int Format { get; private set; }
        public int TrackCount { get; private set; }
        public int Division { get; private set; }


        public SMFInfo(int format, int trackCount, int division)
        {
            Format = format;
            TrackCount = trackCount;
            Division = division;
        }
    }

    public class SMFScore
    {
        public SMFTrack ScoreSetupTrack;
        public List<SMFTrack> PartTracks = new List<SMFTrack>();

        public int PortNum { get; internal set; }
    }

    public class SMFTrack
    {
        public int Channel { get; private set; } = -1;
        public string TrackName { get; private set; } = "";
        public SMFTrackType TrackType { get; private set; } = SMFTrackType.Part;
        public int Port { get; private set; } = -1;
        public List<SMFEvent> Messages { get; private set; }

        public SMFTrack(List<SMFEvent> messages, int format = 1)
        {
            if (!(format == 0 || format == 1))
                throw new FormatException();

            Messages = messages;
            

            // チャンネルの取得
            foreach(var message in messages)
            {
                if (message.Message.messageType == Types.MessageType.ChannelMode || message.Message.messageType == Types.MessageType.ChannelVoice)
                {
                    if (Channel == -1)
                    {
                        Channel = message.Message.Channel;
                    }
                    else if(Channel != message.Message.Channel) // フォーマット0でしかありえない
                    {
                        if (format == 0)
                            Channel = -2;
                        else if (format == 1)
                            throw new FormatException();
                    }
                }
            }



            // TrackNameの取得
            foreach(var message in messages)
            {
                if (message.Message.metaEventType == Types.MetaEventType.SequenceAndTrackName)
                {
                    var bytes = message.Message.Bytes;

                    int index = 2;
                    do index++;
                    while ((bytes[index-1] & 0b10000000) == 1);

                    var trackNameBytes = new byte[bytes.Length - index];
                    Array.Copy(bytes, index, trackNameBytes, 0, trackNameBytes.Length);

                    for(int i = 0; i < trackNameBytes.Length; i++)
                    {
                        TrackName.Append((char)trackNameBytes[i]);
                    }
                }
            }

            // TrackTypeの取得
            if (TrackName == "Score Setup")
                TrackType = SMFTrackType.ScoreSetup;
            else if (messages.Find((n) => n.Message.metaEventType == Types.MetaEventType.SetTempo || n.Message.metaEventType == Types.MetaEventType.TimeSignature) != null)
                TrackType = SMFTrackType.Conductor;
            else
                TrackType = SMFTrackType.Part;

            // Portの取得
            foreach (var message in messages)
            {
                if (message.Message.metaEventType == Types.MetaEventType.PortPrefix)
                {
                    Port = message.Message.Bytes[3];
                }
            }
        }
    }

    public class SMFEvent
    {
        public SMFTiming Timing { get; private set; }
        public MidiMessage Message { get; private set; }

        public SMFEvent(SMFTiming timing, MidiMessage message)
        {
            Timing = timing;
            Message = message;
        }
    }

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

        public SMFTiming(int totalDeltaTime)
        {
            TotalDeltaTime = totalDeltaTime;
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

            // 値の範囲チェック
            if (smfEvent.Timing.TotalDeltaTime < 0)
                throw new FormatException();

            // 一番近いTempoを見つける
            SMFEvent nearestTimingEvent = tempoEvents[tempoEvents.Count - 1];
            for(int i = 0; i < tempoEvents.Count; i++)
            {
                if(smfEvent.Timing.TotalDeltaTime == tempoEvents[i].Timing.TotalDeltaTime)
                {
                    // 同じ場合は計算せずに返す
                    smfEvent.Timing.RealTime = tempoEvents[i].Timing.RealTime;
                    return;
                }
                else if(smfEvent.Timing.TotalDeltaTime < tempoEvents[i].Timing.TotalDeltaTime)
                {   
                    nearestTimingEvent = tempoEvents[i-1];
                    break;
                }    
            }

            // 一番近いTempoとの差分を計算する
            var QuarterNoteLength = nearestTimingEvent.Message.QuarterNoteLength;
            float diffDeltaTime = smfEvent.Timing.TotalDeltaTime - nearestTimingEvent.Timing.TotalDeltaTime;
            float diffQuarterNoteCount = diffDeltaTime / division;
            float diffRealTime = diffQuarterNoteCount * QuarterNoteLength;

            smfEvent.Timing.RealTime = nearestTimingEvent.Timing.RealTime + diffRealTime;
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

            // 値の範囲チェック
            if (smfEvent.Timing.TotalDeltaTime < 0)
                throw new FormatException();

            // 一番近いchangeBeatEventを見つける
            SMFEvent nearestChangeBeatEvent = changeBeatEvents[changeBeatEvents.Count - 1];
            for (int i = 0; i < changeBeatEvents.Count; i++)
            {
                if (smfEvent.Timing.TotalDeltaTime == changeBeatEvents[i].Timing.TotalDeltaTime)
                {
                    // 同じ場合は計算せずに返す
                    smfEvent.Timing.SetMeasureTick(changeBeatEvents[i].Timing.Measure, changeBeatEvents[i].Timing.Tick);
                    return;
                }
                else if (smfEvent.Timing.TotalDeltaTime < changeBeatEvents[i].Timing.TotalDeltaTime)
                {
                    nearestChangeBeatEvent = changeBeatEvents[i-1];
                    break;
                }
            }

            // 一番近い changeBeatEvents との差分を計算する
            int diffDeltaTime = smfEvent.Timing.TotalDeltaTime - nearestChangeBeatEvent.Timing.TotalDeltaTime + nearestChangeBeatEvent.Timing.Tick;
            int oneMeasureTime = (int)((nearestChangeBeatEvent.Message.Bytes[3] / Math.Pow(2, nearestChangeBeatEvent.Message.Bytes[4])) * 4 * division);

            int diffMeasure = diffDeltaTime / oneMeasureTime;
            int measure = nearestChangeBeatEvent.Timing.Measure + diffMeasure;
            int tick = diffDeltaTime - (oneMeasureTime * diffMeasure);
                        
            smfEvent.Timing.SetMeasureTick(measure, tick);
        }


        public override string ToString()
        {
            return $"DT:{TotalDeltaTime:d8}, MT:{Measure:d3}:{Tick:d4}, {RealTime / 1000000 :f3}";
        }
    }

    public enum SMFTrackType
    {
        Conductor,
        ScoreSetup,
        Part
    }
}