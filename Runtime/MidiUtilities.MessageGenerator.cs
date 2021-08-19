using Dono.Midi.Runtime;
using Dono.Midi.Runtime.Types;

namespace Dono.MidiRuntime
{
    public static partial class MidiUtilities
    {

        public static MidiMessage GenerateMidiMessage(byte[] message) {throw new System.NotImplementedException();}
        public static MidiMessage GenerateMidiMessage(byte status, byte data1, byte data2) {throw new System.NotImplementedException();}
        public static MidiMessage GenerateChannelVoiceMessage(byte data1, byte data2) {throw new System.NotImplementedException();}
        public static MidiMessage GenerateControlChangeMessage(ControlChangeType ccType, byte value) {throw new System.NotImplementedException();}
        public static MidiMessage GenerateChannelModeMessage(ChannelModeType cmType) {throw new System.NotImplementedException();}
        public static MidiMessage GenerateSystemCommonMessage(SystemCommonType scType, byte data1, byte data2) {throw new System.NotImplementedException();}
        public static MidiMessage GenerateSystemRealTimeMessage(SystemRealTimeType srType) {throw new System.NotImplementedException();}
    }
}