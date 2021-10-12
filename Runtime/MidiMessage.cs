using Dono.Midi.Runtime.Types;
using UnityEngine;
using UnityEngine.Assertions;

namespace Dono.Midi.Runtime
{
    public partial class MidiMessage
    {
        internal bool isCorrectFormat => MidiUtilities.IsCorrectFormat(Bytes);

        #region public Variables
        /// <summary>
        /// ステータスバイトとデータバイトを含むデータ列
        /// 完全性が確保される
        /// </summary>
        public byte[] Bytes { get; internal set; }

        /// <summary>
        /// データサイズ
        /// </summary>
        public int Length => DataBytes.Length;

        /// <summary>
        /// ステータスバイト
        /// </summary>
        public byte StatusByte => Bytes[0];
        public byte StatusByteUpper => (byte)(StatusByte & 0xF0);
        public byte StatusByteLower => (byte)(StatusByte & 0x0F);

        /// <summary>
        /// データバイト
        /// </summary>
        public byte[] DataBytes
        {
            get
            {
                byte[] result = new byte[Bytes.Length - 1];
                for (int i = 1; i < Bytes.Length; i++)
                {
                    result[i - 1] = Bytes[i];
                }

                return result;
            }
        }
        public byte Data1 => Bytes[1];
        public byte Data2 => Bytes[2];

        /// <summary>
        /// StatusByteの上位4ビットを下位にシフトして返します
        /// </summary>
        public byte Status => (byte)(StatusByteUpper >> 4);
        /// <summary>
        /// StatusByteの下位4ビットを返します
        /// </summary>
        public byte Channel => StatusByteLower;


        #endregion
        #region MessageTypes
        public MessageType messageType = MessageType.None;
        public ChannelVoiceType channelVoiceType = ChannelVoiceType.None;
        public ControlChangeType controlChangeType = ControlChangeType.None;
        public ChannelModeType channelModeType = ChannelModeType.None;
        public SystemCommonType systemCommonType = SystemCommonType.None;
        public SystemRealTimeType systemRealtimeType = SystemRealTimeType.None;
        public MetaEventType metaEventType = MetaEventType.None;
        #endregion


        internal MidiMessage(byte status)
        {
            byte[] bytes = { status };
            Initialize(bytes);
        }
        internal MidiMessage(byte status, byte data1)
        {
            byte[] bytes = { status, data1 };
            Initialize(bytes);
        }
        internal MidiMessage(byte status, byte data1, byte data2)
        {
            byte[] bytes = { status, data1, data2 };
            Initialize(bytes);
        }
        /// <summary>
        /// byte[]にて初期化します
        /// </summary>
        /// <param name="bytes">ステータスバイトとデータバイトを含むデータ列</param>
        internal MidiMessage(byte[] bytes)
        {
            Initialize(bytes);
        }
        internal MidiMessage(MidiMessage message)
        {
            byte[] bytes = message.Bytes;
            Initialize(bytes);
        }

        private void Initialize(byte[] bytes)
        {
            if (bytes.Length == 0)
                return;

            // データのコピー
            int messageLength = 0;

            messageLength = GetMessageLength(bytes);

            Bytes = new byte[messageLength];
            for (int i = 0; i < messageLength; i++)
            {
                Bytes[i] = bytes[i];
            }

            // Typesの更新
            if (isCorrectFormat)
            {
                UpdateMessageType();
                UpdateChannelVoiceType();
                UpdateControlChangeType();
                UpdateChannelModeType();
                UpdateSystemCommonType();
                UpdateSystemRealTimeType();
                UpdateMetaEventType();
            }
        }

        /// <summary>
        /// for MidiMessage
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int GetMessageLength(byte[] data)
        {
            int messageLength = 0;

            switch (data[0] & 0xF0)
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
                    switch (data[0])
                    {
                        case 0xF0:
                            // SMF:  F0h <Length> <Data> F7h
                            // MIDI: F0h <Data> F7h
                            // <Length>は<Data>とF7hのバイト数
                            // messageLengthは全体のバイト数
                            // システムエクスクルーシブに限り
                            // data.LengthをmessageLengthとする
                            messageLength = data.Length;
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
                        case 0xFF:
                            if(data.Length < 3)
                                messageLength = 1;
                            else
                            {
                                messageLength = data[2] + 3;
                            }
                            break;
                    }
                    break;
                default:
                    throw new System.Exception();
            }

            return messageLength;
        }

        private void UpdateMessageType()
        {
            // ChannelModeMessage
            if (Status == 0x0B && Length == 3)//if Length <= 1, Can't read Data1
            {
                if (0x78 <= Data1 && Data1 <= 0x7F)
                {
                    messageType = MessageType.ChannelMode;
                    return;
                }
            }
            // ChannelVoice
            if (0x80 <= StatusByte && StatusByte <= 0xEF)
            {
                messageType = MessageType.ChannelVoice;
                return;
            }
            // SystemExclusive
            if (StatusByte == 0xF0)
            {
                messageType = MessageType.SystemExclusive;
                return;
            }
            // SystemCommon
            if (0xF1 <= StatusByte && StatusByte <= 0xF7)
            {
                messageType = MessageType.SystemCommon;
                return;
            }
            // SystemRealTime
            if (0xF8 <= StatusByte && StatusByte <= 0xFF && Bytes.Length == 1)
            {
                messageType = MessageType.SystemRealtime;
                return;
            }
            // MetaEvent
            if (StatusByte == 0xFF && Bytes.Length > 1)
            {
                messageType = MessageType.MetaEvent;
                return;
            }
            // else
            messageType = MessageType.None;
            return;
        }
        private void UpdateChannelVoiceType()
        {
            if (messageType == MessageType.ChannelVoice)
                channelVoiceType = (ChannelVoiceType)(StatusByte & 0xF0);
            else
                channelVoiceType = ChannelVoiceType.None;
        }
        private void UpdateControlChangeType()
        {
            if (messageType == MessageType.ChannelVoice && channelVoiceType == ChannelVoiceType.ControlChange)
                controlChangeType = (ControlChangeType)Data1;
            else
                controlChangeType = ControlChangeType.None;
        }
        private void UpdateChannelModeType()
        {
            if (messageType == MessageType.ChannelMode)
                channelModeType = (ChannelModeType)Data1;
            else
                channelModeType = ChannelModeType.None;
        }
        private void UpdateSystemCommonType()
        {
            if (messageType == MessageType.SystemCommon)
                systemCommonType = (SystemCommonType)StatusByte;
            else
                systemCommonType = SystemCommonType.None;
        }
        private void UpdateSystemRealTimeType()
        {
            if (messageType == MessageType.SystemRealtime)
                systemRealtimeType = (SystemRealTimeType)StatusByte;
            else
                systemRealtimeType = SystemRealTimeType.None;
        }
        private void UpdateMetaEventType()
        {
            if (messageType == MessageType.MetaEvent)
            {
                switch ((MetaEventType)Data1)
                {
                    case MetaEventType.SequenceNumber:
                        metaEventType = MetaEventType.SequenceNumber;
                        break;
                    case MetaEventType.TextEvent:
                        metaEventType = MetaEventType.TextEvent;
                        break;
                    case MetaEventType.CopyrightNotice:
                        metaEventType = MetaEventType.CopyrightNotice;
                        break;
                    case MetaEventType.SequenceAndTrackName:
                        metaEventType = MetaEventType.SequenceAndTrackName;
                        break;
                    case MetaEventType.InstrumentName:
                        metaEventType = MetaEventType.InstrumentName;
                        break;
                    case MetaEventType.Lyric:
                        metaEventType = MetaEventType.Lyric;
                        break;
                    case MetaEventType.Marker:
                        metaEventType = MetaEventType.Marker;
                        break;
                    case MetaEventType.CuePoint:
                        metaEventType = MetaEventType.CuePoint;
                        break;
                    case MetaEventType.ChannelPrefix:
                        metaEventType = MetaEventType.ChannelPrefix;
                        break;
                    case MetaEventType.PortPrefix:
                        metaEventType = MetaEventType.PortPrefix;
                        break;
                    case MetaEventType.EndOfTrack:
                        metaEventType = MetaEventType.EndOfTrack;
                        break;
                    case MetaEventType.SetTempo:
                        metaEventType = MetaEventType.SetTempo;
                        break;
                    case MetaEventType.SMPTEOffset:
                        metaEventType = MetaEventType.SMPTEOffset;
                        break;
                    case MetaEventType.TimeSignature:
                        metaEventType = MetaEventType.TimeSignature;
                        break;
                    case MetaEventType.KeySignature:
                        metaEventType = MetaEventType.KeySignature;
                        break;
                    case MetaEventType.SequencerSpecificMetaEvent:
                        metaEventType = MetaEventType.SequencerSpecificMetaEvent;
                        break;
                    default:
                        metaEventType = MetaEventType.None;
                        break;
                }
            }   
            else
            {
                metaEventType = MetaEventType.None;
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Bytes.Length; i++)
            {
                str += $"0x{Bytes[i]:X2}";
                if (i != (Bytes.Length - 1))
                    str += " ";
            }
            return str;
        }
    }
}