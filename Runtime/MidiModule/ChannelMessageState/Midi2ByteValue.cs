namespace Dono.Midi
{
    public class Midi2ByteValue
    {
        /// <summary>
        /// HasMinus == true : The range of Value is -8192 to 8191
        /// HasMinus == false: The range of Value is 0 to 16383
        /// </summary>
        public int Value { get; private set; }
        /// <summary>
        /// HasMinus == true : The range of Value is -64 to 63
        /// HasMinus == false: The range of Value is 0 to 127
        /// </summary>
        public int ValueMSB { get; private set; }
        //public int ValueLSB { get; private set; }

        /// <summary>
        /// HasMinus == true : The range of Value is -1.0f to 1.0f
        /// HasMinus == false: The range of Value is 0.0f to 1.0f
        /// </summary>
        public float Rate { get; private set; }
        public float RateMSB { get; private set; }
        
        public byte Msb { get; private set; }
        public byte Lsb { get; private set; }
        public uint Bits => (uint)Msb << 7 + Lsb;
        public readonly bool HasMinus;  // 1度決めたら変更しない

        // public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">
        /// HasMinus == true : The range of Value is -8192 to 8191
        /// HasMinus == false: The range of Value is 0 to 16383
        /// </param>
        public void SetValue(int value)
        {
            // 範囲外の処理
            if(HasMinus)
            {
                if(!(-8192 <= value) && (value <= 8191))
                {
                    value = 0;
                }
            }
            else
            {
                if(!(0 <= value) && (value <= 16383))
                {
                    value = 8192;
                }
            }

            // 強制的に 0 - 16383にする
            value += HasMinus ? 8192 : 0;

            // msbとlsbに分ける
            Lsb = (byte)(value & 0b0111_1111);
            Msb = (byte)((value >> 7) & 0b0111_1111);

            // msb/lsbより再計算
            calcAll(HasMinus, Msb, Lsb);
        }
        public void SetBits(byte msb, byte lsb)
        {
            // 範囲外の処理
            if (msb >= 128 || lsb >= 128)
            {
                msb = (byte)(HasMinus ? 64 : 0);
                lsb = 0;
            }

            // 値のセット
            this.Msb = msb;
            this.Lsb = lsb;

            // msb/lsbより再計算
            calcAll(HasMinus, Msb, Lsb);
        }

        public void SetMsb(byte msb)
        {
            // 範囲外の処理
            if (msb >= 128)
            {
                msb = (byte)(HasMinus ? 64 : 0);
            }

            // 値のセット
            this.Msb = msb;

            // msb/lsbより再計算
            calcAll(HasMinus, Msb, Lsb);
        }
        public void SetLsb(byte lsb)
        {
            // 範囲外の処理
            if (lsb >= 128)
                lsb = 0;

            // 値のセット
            this.Lsb = lsb;

            // msb/lsbより再計算
            calcAll(HasMinus, Msb, Lsb);

        }
        public void SetRate(float rate)
        {
            // 範囲外の処理
            if (HasMinus)
            {
                if (!(-1.0f <= rate && rate <= 1.0f))
                    rate = 0.0f;
            }
            else
            {
                if (!(0.0f <= rate && rate <= 1.0f))
                    rate = 0.0f;
            }

            // MSBとLSBを求める
            float tmpRate;
            if (HasMinus)
                tmpRate = (rate + 1.0f) / 2.0f;  // 0.0f - 1.0f
            else
                tmpRate = rate;                 // 0.0f - 1.0f

            // 強制的に 0 - 16383にする
            var tmpValue = (int)(tmpRate * 16383);

            // msbとlsbに分ける
            Lsb = (byte)(tmpValue & 0b0111_1111);
            Msb = (byte)((tmpValue >> 7) & 0b0111_1111);

            // msb/lsbより再計算
            calcAll(HasMinus, Msb, Lsb);
        }

        // private Methods
        private int calcValue(bool hasMinus, byte msb, byte lsb)
        {
            return ((msb << 7) + lsb) - (hasMinus ? 8192 : 0);
        }
        private float calcRate(bool hasMinus, byte msb, byte lsb) 
        {
            var val = calcValue(false, msb, lsb) / 16383f;   // 0-1.0f
            return hasMinus ? (val - 0.5f) * 2 : val;
        }
        private byte calcValueMSB(bool hasMinus, byte msb)
        {
            return (byte)(msb - (hasMinus ? 64 : 0));
        }
        private float calcRateMSB(bool hasMinus, byte msb)
        {
            var val = calcValueMSB(false, msb) / 127f;   //0 - 1.0f
            return hasMinus ? (val - 0.5f) * 2 : val;
        }
        private void calcAll(bool hasMinus, byte msb, byte lsb)
        {
            Value = calcValue(hasMinus, msb, lsb);
            Rate = calcRate(hasMinus, msb, lsb);
            ValueMSB = calcValueMSB(hasMinus, msb);
            RateMSB = calcRateMSB(hasMinus, msb);
        }

        // Constructors
        /// ture:  Output value range from  0.0 to 1.0<br/>
        /// false: Output value range from -1.0 to 1.0
        public Midi2ByteValue(bool hasMinus, byte msb = 255, byte lsb = 255)
        {
            this.HasMinus = hasMinus;
            SetBits(msb, lsb);
        }
        public Midi2ByteValue(bool hasMinus, float rate)
        {
            this.HasMinus = hasMinus;
            SetRate(rate);
        }
        public Midi2ByteValue(bool hasMinus, int value)
        {
            this.HasMinus = hasMinus;
            SetValue(value);
        }
    }
}