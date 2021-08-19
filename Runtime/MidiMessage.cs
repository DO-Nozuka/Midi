using Dono.Midi.Runtime.Types;

namespace Dono.Midi.Runtime
{
    public partial class MidiMessage
    {
        private bool isCorrectFormat { get; }
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
            // データのコピー
            Bytes = new byte[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                Bytes[i] = bytes[i];
            }

            // Typesの更新
            UpdateMessageType();
            UpdateChannelVoiceType();
            UpdateControlChangeType();
            UpdateChannelModeType();
            UpdateSystemCommonType();
            UpdateSystemRealTimeType();
            UpdateMetaEventType();

            //フォーマットの確認
            //MidiUtilities.IsCorrectFormat(bytes);
            throw new System.NotImplementedException();
            
        }

        private void UpdateMessageType()
        {
            throw new System.NotImplementedException();
        }

        private void UpdateChannelVoiceType()
        {
            throw new System.NotImplementedException();
        }
        private void UpdateControlChangeType()
        {
            throw new System.NotImplementedException();
        }
        private void UpdateChannelModeType()
        {
            throw new System.NotImplementedException();
        }
        private void UpdateSystemCommonType()
        {
            throw new System.NotImplementedException();
        }
        private void UpdateSystemRealTimeType()
        {
            throw new System.NotImplementedException();
        }
        private void UpdateMetaEventType()
        {
            throw new System.NotImplementedException();
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