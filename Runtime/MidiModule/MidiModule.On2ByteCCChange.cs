using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{
    public partial class MidiModule
    {
        public virtual void OnBankSelectChange(MidiMessage message) { }
        public virtual void OnModulationChange(MidiMessage message) { }
        public virtual void OnBreathControllerChange(MidiMessage message) { }
        public virtual void OnUndefined03Change(MidiMessage message) { }
        public virtual void OnFootControllerChange(MidiMessage message) { }
        public virtual void OnPortamentoTimeChange(MidiMessage message) { }
        public virtual void OnChannelVolumeChange(MidiMessage message) { }
        public virtual void OnBalanceChange(MidiMessage message) { }
        public virtual void OnUndefined09Change(MidiMessage message) { }
        public virtual void OnPanChange(MidiMessage message) { }
        public virtual void OnExpressionControllerChange(MidiMessage message) { }
        public virtual void OnEffectControl1Change(MidiMessage message) { }
        public virtual void OnEffectControl2Change(MidiMessage message) { }
        public virtual void OnUndefined0EChange(MidiMessage message) { }
        public virtual void OnUndefined0FChange(MidiMessage message) { }
        public virtual void OnGeneralPurposeController1Change(MidiMessage message) { }
        public virtual void OnGeneralPurposeController2Change(MidiMessage message) { }
        public virtual void OnGeneralPurposeController3Change(MidiMessage message) { }
        public virtual void OnGeneralPurposeController4Change(MidiMessage message) { }
        public virtual void OnUndefined14Change(MidiMessage message) { }
        public virtual void OnUndefined15Change(MidiMessage message) { }
        public virtual void OnUndefined16Change(MidiMessage message) { }
        public virtual void OnUndefined17Change(MidiMessage message) { }
        public virtual void OnUndefined18Change(MidiMessage message) { }
        public virtual void OnUndefined19Change(MidiMessage message) { }
        public virtual void OnUndefined1AChange(MidiMessage message) { }
        public virtual void OnUndefined1BChange(MidiMessage message) { }
        public virtual void OnUndefined1CChange(MidiMessage message) { }
        public virtual void OnUndefined1DChange(MidiMessage message) { }
        public virtual void OnUndefined1EChange(MidiMessage message) { }
        public virtual void OnUndefined1FChange(MidiMessage message) { }
    }
}
