using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{
    public partial class MidiModule
    {
        public virtual void OnMidiTimeCode(MidiMessage message) { }
        public virtual void OnSongPosition(MidiMessage message) { }
        public virtual void OnSongSelect(MidiMessage message) { }
        public virtual void OnUndefinedF4(MidiMessage message) { }
        public virtual void OnUndefinedF5(MidiMessage message) { }
        public virtual void OnTuneRequest(MidiMessage message) { }
        public virtual void OnEOX(MidiMessage message) { }
    }
}
