using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{
    public partial class MidiModule
    {
        public Action<MidiMessage> OnBankSelectChange = (m) => {};
        private void onBankSelectChange(MidiMessage message) { 
            OnBankSelectChange.Invoke(message);
        }

        public Action<MidiMessage> OnModulationChange = (m) => {};
        private void onModulationChange(MidiMessage message) { 
            OnModulationChange.Invoke(message);
        }

        public Action<MidiMessage> OnBreathControllerChange = (m) => {};
        private void onBreathControllerChange(MidiMessage message) { 
            OnBreathControllerChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined03Change = (m) => {};
        private void onUndefined03Change(MidiMessage message) { 
            OnUndefined03Change.Invoke(message);
        }

        public Action<MidiMessage> OnFootControllerChange = (m) => {};
        private void onFootControllerChange(MidiMessage message) { 
            OnFootControllerChange.Invoke(message);
        }

        public Action<MidiMessage> OnPortamentoTimeChange = (m) => {};
        private void onPortamentoTimeChange(MidiMessage message) { 
            OnPortamentoTimeChange.Invoke(message);
        }

        public Action<MidiMessage> OnChannelVolumeChange = (m) => {};
        private void onChannelVolumeChange(MidiMessage message) { 
            OnChannelVolumeChange.Invoke(message);
        }

        public Action<MidiMessage> OnBalanceChange = (m) => {};
        private void onBalanceChange(MidiMessage message) { 
            OnBalanceChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined09Change = (m) => {};
        private void onUndefined09Change(MidiMessage message) { 
            OnUndefined09Change.Invoke(message);
        }

        public Action<MidiMessage> OnPanChange = (m) => {};
        private void onPanChange(MidiMessage message) { 
            OnPanChange.Invoke(message);
        }

        public Action<MidiMessage> OnExpressionControllerChange = (m) => {};
        private void onExpressionControllerChange(MidiMessage message) { 
            OnExpressionControllerChange.Invoke(message);
        }

        public Action<MidiMessage> OnEffectControl1Change = (m) => {};
        private void onEffectControl1Change(MidiMessage message) { 
            OnEffectControl1Change.Invoke(message);
        }

        public Action<MidiMessage> OnEffectControl2Change = (m) => {};
        private void onEffectControl2Change(MidiMessage message) { 
            OnEffectControl2Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined0EChange = (m) => {};
        private void onUndefined0EChange(MidiMessage message) { 
            OnUndefined0EChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined0FChange = (m) => {};
        private void onUndefined0FChange(MidiMessage message) { 
            OnUndefined0FChange.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController1Change = (m) => {};
        private void onGeneralPurposeController1Change(MidiMessage message) { 
            OnGeneralPurposeController1Change.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController2Change = (m) => {};
        private void onGeneralPurposeController2Change(MidiMessage message) { 
            OnGeneralPurposeController2Change.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController3Change = (m) => {};
        private void onGeneralPurposeController3Change(MidiMessage message) { 
            OnGeneralPurposeController3Change.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController4Change = (m) => {};
        private void onGeneralPurposeController4Change(MidiMessage message) { 
            OnGeneralPurposeController4Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined14Change = (m) => {};
        private void onUndefined14Change(MidiMessage message) { 
            OnUndefined14Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined15Change = (m) => {};
        private void onUndefined15Change(MidiMessage message) { 
            OnUndefined15Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined16Change = (m) => {};
        private void onUndefined16Change(MidiMessage message) { 
            OnUndefined16Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined17Change = (m) => {};
        private void onUndefined17Change(MidiMessage message) { 
            OnUndefined17Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined18Change = (m) => {};
        private void onUndefined18Change(MidiMessage message) { 
            OnUndefined18Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined19Change = (m) => {};
        private void onUndefined19Change(MidiMessage message) { 
            OnUndefined19Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1AChange = (m) => {};
        private void onUndefined1AChange(MidiMessage message) { 
            OnUndefined1AChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1BChange = (m) => {};
        private void onUndefined1BChange(MidiMessage message) { 
            OnUndefined1BChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1CChange = (m) => {};
        private void onUndefined1CChange(MidiMessage message) { 
            OnUndefined1CChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1DChange = (m) => {};
        private void onUndefined1DChange(MidiMessage message) { 
            OnUndefined1DChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1EChange = (m) => {};
        private void onUndefined1EChange(MidiMessage message) { 
            OnUndefined1EChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1FChange = (m) => { };
        private void onUndefined1FChange(MidiMessage message) {
            OnUndefined1FChange.Invoke(message);
        }
    }
}
