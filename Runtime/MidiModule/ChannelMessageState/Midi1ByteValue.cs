namespace Dono.Midi
{
    /// <summary>
    /// 内部では全てBitsを基準に計算します
    /// あらゆる値 -> Bits -> 各値を再計算
    /// </summary>
    public class Midi1ByteValue
    {
        /// <summary>
        /// HasMinus == true : The range of Value is -64 to 63
        /// HasMinus == false: The range of Value is 0 to 127
        /// </summary>
        public byte Value { get; private set; }
        public float Rate { get; private set; }

        public byte Bits { get; private set; }
        public readonly bool HasMinus;

        // public Methods
        public void SetValue(int value)
        {
            // 範囲外の処理 
            if (HasMinus)
            {
                if (!(-64 <= value) && (value < 63))
                    value = 0;
            }
            else
            {
                if (!(0 <= value) && value <= 127)
                    value = 64;
            }

            // 0 - 127にする
            Bits = (byte)(value + (HasMinus ? 64 : 0));

            // 再計算
            calcAll(HasMinus, Bits);
        }
        public void SetBits(byte bits)
        {
            if (!(0 <= bits && bits <= 127))
                bits = 0;

            Bits = bits;
            calcAll(HasMinus, Bits);
        }
        public void SetRate(float rate)
        {
            // 範囲外の処理
            if(HasMinus)
            {
                if(!(- 1.0f <= rate) && (rate < 1.0f))
                {
                    rate = 0.0f;
                }
            }
            else
            {
                if(!(0 <= rate) && (rate <= 1.0f))
                {
                    rate = 0.5f;
                }
            }

            // 0.0f - 1.0fにする
            if(HasMinus)
                rate = (rate + 1.0f) / 2.0f;
            // else rate = rate;

            // bitsに変換
            Bits = (byte)(rate * 127f);

            // 再計算
            calcAll(HasMinus, Bits);
        }

        public void IncValue()
        {
            if (Bits == 0x7F)
            {
                // NOP
            }
            else
            {
                SetBits((byte)(Bits + 1));
            }
        }
        public void DecValue()
        {
            if (Bits == 0x00)
            {
                // NOP
            }
            else
            {
                SetBits((byte)(Bits - 1));
            }
        }
        // private Methods
        private byte calcValue(bool hasMinus, byte bits)
        {
            return (byte)(bits - (hasMinus ? 64 : 0));
        }
        private float calcRate(bool hasMinus, byte bits)
        {
            var tmpRate = bits / 127f; // 0.0f - 1.0f
            if (hasMinus)
                return (tmpRate - 0.5f) * 2.0f;
            else
                return tmpRate;
        }
        private void calcAll(bool hasMinus, byte bits)
        {
            Value = calcValue(hasMinus, bits);
            Rate = calcRate(hasMinus, bits);
        }

        public Midi1ByteValue(bool hasMinus, byte msb = 255)
        {
            this.HasMinus = hasMinus;
            SetBits(msb);
        }
        public Midi1ByteValue(bool hasMinus, float rate)
        {
            this.HasMinus = hasMinus;
            SetRate(rate);
        }
        public Midi1ByteValue(bool hasMinus, int value)
        {
            this.HasMinus = hasMinus;
            SetValue(value);
        }
    }
}