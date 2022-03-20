namespace Dono.Midi
{
    public static partial class MidiUtilities
    {
        /// <summary>
        /// Convert 14BitData to Rate with Option.
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unsignedBit">
        /// true:  Input value range from     0 to 16383
        /// false: Input value range from -8192 to  8191<br/>
        /// </param>
        /// <param name="unsignedRate">
        /// ture:  Output value range from  0.0 to 1.0<br/>
        /// false: Output value range from -1.0 to 1.0
        /// </param>
        /// <returns></returns>
        public static float Convert14BitToRate(int value, bool unsignedBit = true, bool unsignedRate = true)
        {
            float result = 0;
            int sValue = 0;

            if (unsignedBit)
                sValue = value - 8192;
            else
                sValue = value;

            float sRate = sValue > 0 ? sValue / 8191f : sValue / 8192f;

            if (unsignedRate)
                result = (sRate + 1.0f) / 2.0f;
            else
                result = sRate;

            return result;
        }


        public static float Convert7BitToRate(int value, bool unsignedBit = true, bool unsignedRate = true)
        {
            float result = 0;
            int sValue = 0;

            if (unsignedBit)
                sValue = value - 128;
            else
                sValue = value;

            float sRate = sValue > 0 ? sValue / 127f : sValue / 128f;

            if (unsignedRate)
                result = (sRate + 1.0f) / 2.0f;
            else
                result = sRate;

            return result;
        }

        public static int ConvertRateTo14Bit(float value, bool unsignedRate = true, bool unsignedBit = true)
        {
            int result = 0;
            float sValue = 0;

            if (unsignedRate)
                sValue = (value - 0.5f) * 2;
            else
                sValue = value;

            int sBit = sValue > 0 ? (int)(sValue * 8191) : (int)(sValue * 8192);

            if (unsignedBit)
                result = sBit + 8192;
            else
                result = sBit;

            return result;
        }

        public static int ConvertRateTo7Bit(float value, bool unsignedRate = true, bool unsignedBit = true)
        {
            int result = 0;
            float sValue = 0;

            if (unsignedRate)
                sValue = (value - 0.5f) * 2;
            else
                sValue = value;

            int sBit = sValue > 0 ? (int)(sValue * 127) : (int)(sValue * 128);

            if (unsignedBit)
                result = sBit + 128;
            else
                result = sBit;

            return result;
        }
    }
}