using System;

namespace Dono.Midi
{

    public partial class MidiModule // OnSystemRealTime
    {
        public Action<MidiMessage> OnTimingClock = (m) => { };
        public Action<MidiMessage> OnUndefinedF9 = (m) => { };
        public Action<MidiMessage> OnStart = (m) => { };
        public Action<MidiMessage> OnContinue = (m) => { };
        public Action<MidiMessage> OnStop = (m) => { };
        public Action<MidiMessage> OnUndefinedFD = (m) => { };
        public Action<MidiMessage> OnActiveSensing = (m) => { };
        public Action<MidiMessage> OnReset = (m) => { };
    }
}
