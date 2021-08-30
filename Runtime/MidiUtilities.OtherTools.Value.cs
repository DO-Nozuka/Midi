namespace Dono.Midi.Runtime
{
    public static partial class MidiUtilities
    {
        public static float Convert14BitToRate(int value, bool unsigned = false)
        {
            if (unsigned)
                return value / 16383f;
            else
                return value > 0 ? value / 8191f : value / 8192f;
        }

        public static float Convert7BitToRate(int value, bool unsigned = false)
        {
            if (unsigned)
                return value / 255f;
            else
                return value > 0 ? value / 127f : value / 128f;
        }

        public static float ConvertRateTo14Bit(float value, bool unsigned = false)
        {
            if (unsigned)
                return value * 16383f;
            else
                return value > 0 ? value * 8191f : value * 8192f;
        }

        public static float ConvertRateTo7Bit(float value, bool unsigned = false)
        {
            if (unsigned)
                return value * 255f;
            else
                return value > 0 ? value * 127f : value * 128f;
        }
    }
}