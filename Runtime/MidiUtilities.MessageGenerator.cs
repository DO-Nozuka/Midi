using Dono.Midi.Runtime.Types;

namespace Dono.Midi.Runtime
{
    public static partial class MidiUtilities
    {

        public static MidiMessage GenerateMidiMessage(byte[] message)
        {
            var midiMessage = new MidiMessage(message);
            if (midiMessage.isCorrectFormat)
                return midiMessage;
            else
                return null;
        }
        public static MidiMessage GenerateMidiMessage(byte status)
        {
            var midiMessage = new MidiMessage(status);
            if (midiMessage.isCorrectFormat)
                return midiMessage;
            else
                return null;
        }
        public static MidiMessage GenerateMidiMessage(byte status, byte data1)
        {
            var midiMessage = new MidiMessage(status, data1);
            if (midiMessage.isCorrectFormat)
                return midiMessage;
            else
                return null;
        }
        public static MidiMessage GenerateMidiMessage(byte status, byte data1, byte data2)
        {
            var midiMessage = new MidiMessage(status, data1, data2);
            if (midiMessage.isCorrectFormat)
                return midiMessage;
            else
                return null;
        }

        public static MidiMessage GenerateNoteOffMessage(byte noteNumber, byte velocity, byte channel = 0)
        {
            return GenerateMidiMessage((byte)(0x80 & channel), noteNumber, velocity);
        }
        public static MidiMessage GenerateNoteOnMessage(byte noteNumber, byte velocity, byte channel = 0)
        {
            return GenerateMidiMessage((byte)(0x90 & channel), noteNumber, velocity);
        }

        public static MidiMessage GenerateChannelVoiceMessage(ChannelVoiceType channelVoiceType, byte data1, byte data2, byte channel = 0)
        {
            if (channelVoiceType == ChannelVoiceType.None)
                return null;
            return GenerateMidiMessage((byte)((byte)channelVoiceType & channel), data1, data2);
        }
        public static MidiMessage GenerateControlChangeMessage(ControlChangeType ccType, byte value, byte channel = 0) 
        {
            if (ccType == ControlChangeType.None)
                return null;
            return GenerateMidiMessage((byte)(0xB0 & channel), value, channel);
        }
        public static MidiMessage GenerateChannelModeMessage(ChannelModeType cmType, byte channel = 0, byte value = 0)
        {
            if (cmType == ChannelModeType.None)
                return null;
            return GenerateMidiMessage((byte)(0xB0 + channel), (byte)cmType, value);
        }
        public static MidiMessage GenerateSystemCommonMessage(SystemCommonType scType, byte data1 = 0xFF, byte data2 = 0xFF)
        {
            if (scType == SystemCommonType.None)
                return null;

            if (data1 > 0x7F)
                return GenerateMidiMessage((byte)scType);
            else if (data1 <= 0x7F && data2 > 0x7F)
                return GenerateMidiMessage((byte)scType, data1);
            else if (data1 <= 0x7F && data2 <= 0x7F)
                return GenerateMidiMessage((byte)scType, data1, data2);

            return null;
        }
        public static MidiMessage GenerateSystemRealTimeMessage(SystemRealTimeType srType)
        {
            return GenerateMidiMessage((byte)srType);
        }
    }
}