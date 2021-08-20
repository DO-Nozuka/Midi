namespace Dono.Midi.Runtime.Types
{
    public interface IOnChannelVoiceType
    {
        void OnNoteOff(MidiMessage message);
        void OnNoteOn(MidiMessage message);
        void OnPolyphonicKeyPressure(MidiMessage message);
        void OnControlChange(MidiMessage message);
        void OnProgramChange(MidiMessage message);
        void OnChannelPressure(MidiMessage message);
        void OnPitchBendChange(MidiMessage message);
    }
}