using System;

namespace Dono.Midi
{

    public partial class MidiModule // OnSystemRealTime
    {
        public Action<MidiMessage> OnTimingClock { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefinedF9 { get; private set; } = (m) => { };
        public Action<MidiMessage> OnStart { get; private set; } = (m) => { };
        public Action<MidiMessage> OnContinue { get; private set; } = (m) => { };
        public Action<MidiMessage> OnStop { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefinedFD { get; private set; } = (m) => { };
        public Action<MidiMessage> OnActiveSensing { get; private set; } = (m) => { };
        public Action<MidiMessage> OnReset { get; private set; } = (m) => { };
    }
}
