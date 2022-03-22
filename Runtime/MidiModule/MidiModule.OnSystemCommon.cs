using System;

namespace Dono.Midi
{
    public partial class MidiModule
    {
        public Action<MidiMessage> OnMidiTimeCode = (m) => { };
        public Action<MidiMessage> OnSongPosition = (m) => { };
        public Action<MidiMessage> OnSongSelect = (m) => { };
        public Action<MidiMessage> OnUndefinedF4 = (m) => { };
        public Action<MidiMessage> OnUndefinedF5 = (m) => { };
        public Action<MidiMessage> OnTuneRequest = (m) => { };
        public Action<MidiMessage> OnEOX = (m) => { };
    }
}
