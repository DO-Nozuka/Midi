using Dono.Midi.Runtime;

namespace Dono.MidiRuntime
{
    public static partial class MidiUtilities
    {
        //ToRate>>
        public static float PitchValueToRate(int value)
        {
            throw new System.NotImplementedException();
        }
        public static float PitchByteToRate((byte data1, byte data2) data) { throw new System.NotImplementedException();}
        public static float PitchMessageToRate(MidiMessage message) { throw new System.NotImplementedException();}
        //ToValue>>
        public static int PitchRateToValue(float rate) { throw new System.NotImplementedException();}
        public static int PitchByteToValue((byte data1, byte data2) data) { throw new System.NotImplementedException();}
        public static int PitchMessageToValue(MidiMessage message) { throw new System.NotImplementedException();}
        //ToByte>>
        public static (byte data1, byte data2) PitchRateToByte(float rate) { throw new System.NotImplementedException();}
        public static (byte data1, byte data2) PitchValueToByte(int value) { throw new System.NotImplementedException();}
        public static (byte data1, byte data2) PitchMessageToByte(MidiMessage message) { throw new System.NotImplementedException();}
        //ToMidiMessage>>
        public static MidiMessage PitchValueToMessage(int value) { throw new System.NotImplementedException();}
        public static MidiMessage PitchRateToMessage(float rate) { throw new System.NotImplementedException();}
        public static MidiMessage PitchByteToMessage((byte data1, byte data2) data) { throw new System.NotImplementedException();}
    }
}