namespace Dono.Midi
{
    public static partial class MidiUtilities
    {
        // ToRate
        public static float PitchValueToRate(int value) => value > 0 ? value / 8191f : value / 8192f;
        public static float PitchByteToRate((byte data1, byte data2) data) => PitchValueToRate(PitchByteToValue(data));
        public static float PitchMessageToRate(MidiMessage message) => PitchByteToRate((message.Data1, message.Data2));
        // ToValue
        public static int PitchRateToValue(float rate) => rate > 0 ? (int)(rate * 8191f) : (int)(rate * 8192f);
        public static int PitchByteToValue((byte data1, byte data2) data) => (data.data2 << 7) + data.data1 - 8192;
        public static int PitchMessageToValue(MidiMessage message) => PitchByteToValue((message.Data1, message.Data2));
        // ToByte
        public static (byte data1, byte data2) PitchRateToByte(float rate) => PitchValueToByte(PitchRateToValue(rate));
        public static (byte data1, byte data2) PitchValueToByte(int value)
        {
            int tmpVal = value + 8192;
            byte upper = (byte)((value + 8192) >> 7);
            byte lower = (byte)(tmpVal & 0x000000FF);
            return (lower, upper);
        }
        public static (byte data1, byte data2) PitchMessageToByte(MidiMessage message) => (message.Data1, message.Data2);
    }
}