namespace Dono.MidiUtilities.MidiMessage
{
    public partial class MidiMessage
    {
        /// <summary>
        /// ステータスバイト
        /// </summary>
        public byte StatusByte { get; private set; }
        public byte StatusByteUpper => (byte)(StatusByte & 0xF0);
        public byte StatusByteLower => (byte)(StatusByte & 0x0F);
        /// <summary>
        /// データバイト
        /// </summary>
        public byte[] DataBytes { get; private set; }
        /// <summary>
        /// ステータスバイトとデータバイトを含むデータ列
        /// </summary>
        private byte[] RawBytes;
        /// <summary>
        /// ステータスバイトを含まないデータバイトサイズ
        /// </summary>
        public int DataSize => DataBytes.Length;
        /// <summary>
        /// ステータスバイトタイプ
        /// </summary>
        public Type MessageType { get; private set; }

        /// <summary>
        /// byte[]にて初期化します
        /// </summary>
        /// <param name="rawBytes">ステータスバイトとデータバイトを含むデータ列</param>
        public MidiMessage(byte[] rawBytes)
        {
            RawBytes = new byte[rawBytes.Length];
            for(int i = 0; i < rawBytes.Length; i++)
            {
                RawBytes[i] = rawBytes[i];
            }

            StatusByte = rawBytes[0];
            DataBytes = new byte[rawBytes.Length - 1];
            for(int i = 0; i < rawBytes.Length - 1; i++)
            {
                DataBytes[i] = rawBytes[i + 1];
            }

            MessageType = GetStatusType(rawBytes);
        }

        
    }
}