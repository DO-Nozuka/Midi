namespace Dono.Midi
{
    public interface IOnSystemCommonType
    {
        void OnMidiTimeCode(MidiMessage message);
        void OnSongPosition(MidiMessage message);
        void OnSongSelect(MidiMessage message);
        void OnUndefinedF4(MidiMessage message);
        void OnUndefinedF5(MidiMessage message);
        void OnTuneRequest(MidiMessage message);
        void OnEOX(MidiMessage message);
    }

}