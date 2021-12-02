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
        private int division = 0;

        public StandardMidiFile(byte[] data)
        {
            if (IsDebugMode) Debug.Log("[SMF]Start to Initialize.");

            // 初期化
            int _index = 0;

            // ヘッダーチャンク
            if (IsDebugMode) Debug.Log("[SMF]Start InitHeaderChunk.");
            InitHeaderChunk(data, ref _index, out Info);
            division = Info.Division;

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
                var samePortScore = Scores.Find((s) => s.Port == track.Port);
                switch (track.TrackType)
                {
                    case SMFTrackType.Conductor:
                        // NOP
                        break;
                    case SMFTrackType.ScoreSetup:
                        if (samePortScore == null)
                        {
                            var ssScore = new SMFScore();
                            ssScore.AddTrack(track);
                            Scores.Add(ssScore);
                        }
                        else
                        {
                            samePortScore.ScoreSetupTrack = track;
                        }
                        break;
                    case SMFTrackType.Part:
                        if (samePortScore == null)
                        {
                            var pScore = new SMFScore();
                            pScore.AddTrack(track);
                            Scores.Add(pScore);
                        }
                        else
                        {
                            samePortScore.PartTracks.Add(track);
                        }
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
                SMFTiming timing = new SMFTiming(totalDeltaTime, division);

                //イベントの取得
                int dataLength = MidiMessage.GetMessageLength(data, index, true);
                byte[] messagBytes = new byte[dataLength];
                Array.Copy(data, index, messagBytes, 0, dataLength);
                index += dataLength;

                MidiMessage message = new MidiMessage(messagBytes, true);


                smfMessages.Add(new SMFEvent(timing, message));
            }

            return new SMFTrack(smfMessages);
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
        /// <param name="name">Mark name</param>
        /// <returns>First found value</returns>
        public static float GetMarkTiming(SMFTrack conductorTrack, string name)
        {
            var messages = conductorTrack.Messages.FindAll((n) => n.Message.metaEventType == Types.MetaEventType.Marker);

            foreach (var message in messages)
            {
                string str = GetMakerNameInShiftJIS(message.Message);
                if (str == name)
                    return message.Timing.RealTime;
            }

            return 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">variable name</param>
        /// <returns>variable name(when not found, return "")</returns>
        public static string GetTextEventVariable(SMFTrack conductorTrack, string name)
        {
            var messages = conductorTrack.Messages.FindAll((n) => n.Message.metaEventType == Types.MetaEventType.TextEvent);

            foreach (var message in messages)
            {
                string str = GetTextEventInShiftJIS(message.Message);

                if (str.StartsWith($"{name}="))
                {
                    return GetTextEventInShiftJIS(message.Message).Substring(name.Length + 1);
                }
            }

            return "";
        }

        public static string GetTextEventInShiftJIS(MidiMessage message)
        {
            var dataLength = MidiMessage.GetDataLength(message.Bytes, 0, true);
            byte[] data = new byte[dataLength];
            int startIndex = message.Bytes.Length - dataLength;
            Array.Copy(message.Bytes, startIndex, data, 0, dataLength);

            return Encoding.GetEncoding("Shift_JIS").GetString(data);
        }

        public static string GetMakerNameInShiftJIS(MidiMessage message)
        {
            var dataLength = MidiMessage.GetDataLength(message.Bytes, 0, true);
            byte[] data = new byte[dataLength];
            int startIndex = message.Bytes.Length - dataLength;
            Array.Copy(message.Bytes, startIndex, data, 0, dataLength);

            return Encoding.GetEncoding("Shift_JIS").GetString(data);
        }

        public static float GetMaxBPM(SMFTrack conductorTrack)
        {
            var messages = conductorTrack.Messages.FindAll((n) => n.Message.metaEventType == Types.MetaEventType.SetTempo);

            int minUSPB = 0b11111111_11111111_11111111;
            foreach(var message in messages)
            {
                int uspb = (message.Message.Bytes[3] << 16) + (message.Message.Bytes[4] << 8) + (message.Message.Bytes[5] << 0);

                if(uspb < minUSPB)
                    minUSPB = uspb;
            }

            float maxBPM = (60_000_000) / minUSPB;
            return maxBPM;
        }

        public static float GetMinBPM(SMFTrack conductorTrack)
        {
            var messages = conductorTrack.Messages.FindAll((n) => n.Message.metaEventType == Types.MetaEventType.SetTempo);
            int maxUSPB = 0b00000000_00000000_00000000;
            foreach(var message in messages)
            {
                int uspb = (message.Message.Bytes[3] << 16) + (message.Message.Bytes[4] << 8) + (message.Message.Bytes[5] << 0);

                if(uspb > maxUSPB)
                    maxUSPB = uspb;
            }

            float minBPM = (60_000_000) / maxUSPB;
            return minBPM;
        }

        public static float GetBPM(SMFTrack conductorTrack, int totalDeltaTime)
        {
            var tempoChages = conductorTrack.Messages.FindAll((n) => n.Message.metaEventType == Types.MetaEventType.SetTempo);

            SMFEvent tempoChange = tempoChages[0];

            for (int i = 1; i < tempoChages.Count; i++)
            {
                if(tempoChages[i].Timing.TotalDeltaTime <= totalDeltaTime)
                    tempoChange = tempoChages[i];
            }

            int uspb = (tempoChange.Message.Bytes[3] << 16) + (tempoChange.Message.Bytes[4] << 8) + (tempoChange.Message.Bytes[5] << 0);
            return (60_000_000) / uspb;
        }

        public static List<SMFEvent> GetBPMChangeEvents(SMFTrack conductorTrack, int frontTotalDeltaTime, int rearTotalDeltaTime)
        {
            return conductorTrack.Messages.FindAll((n) =>
            n.Message.metaEventType == Types.MetaEventType.SetTempo 
            && frontTotalDeltaTime <= n.Timing.TotalDeltaTime && n.Timing.TotalDeltaTime < rearTotalDeltaTime);
        }
    }
}