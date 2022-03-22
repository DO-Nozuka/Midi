using System;

namespace Dono.Midi
{
    public partial class MidiModule
    {
        public Action<MidiMessage> OnMidiTimeCode { get; private set; } = (m) => { };
        public Action<MidiMessage> OnSongPosition { get; private set; } = (m) => { };
        public Action<MidiMessage> OnSongSelect { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefinedF4 { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefinedF5 { get; private set; } = (m) => { };
        public Action<MidiMessage> OnTuneRequest { get; private set; } = (m) => { };
        public Action<MidiMessage> OnEOX { get; private set; } = (m) => { };
    }
}
