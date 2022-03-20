using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule // OnSystemRealTime
    {    
        public virtual void OnTimingClock(MidiMessage message) { }
        public virtual void OnUndefinedF9(MidiMessage message) { }
        public virtual void OnStart(MidiMessage message) { }
        public virtual void OnContinue(MidiMessage message) { }
        public virtual void OnStop(MidiMessage message) { }
        public virtual void OnUndefinedFD(MidiMessage message) { }
        public virtual void OnActiveSensing(MidiMessage message) { }
        public virtual void OnReset(MidiMessage message) { }
    }
}
