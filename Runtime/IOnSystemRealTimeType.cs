namespace Dono.Midi.Runtime.Types
{
    public interface IOnSystemRealTimeType
    {
        void OnTimingClock(MidiMessage message);
        void OnUndefinedF9(MidiMessage message);
        void OnStart(MidiMessage message);
        void OnContinue(MidiMessage message);
        void OnStop(MidiMessage message);
        void OnUndefinedFD(MidiMessage message);
        void OnActiveSensing(MidiMessage message);
        void OnReset(MidiMessage message);
    }

}