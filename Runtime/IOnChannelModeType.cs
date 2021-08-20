namespace Dono.Midi.Runtime.Types
{
    public interface IOnChannelModeType
    {
        void OnAllSoundOff(MidiMessage message);
        void OnResetAllControllers(MidiMessage message);
        void OnLocalControl(MidiMessage message);
        void OnAllNotesOff(MidiMessage message);
        void OnOmniModeOff(MidiMessage message);
        void OnOmniModeOn(MidiMessage message);
        void OnMonoModeOn(MidiMessage message);
        void OnPolyModeOn(MidiMessage message);
    }

}