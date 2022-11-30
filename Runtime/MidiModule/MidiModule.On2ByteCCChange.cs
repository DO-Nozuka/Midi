using System;

namespace Dono.Midi
{
    public partial class MidiModule
    {
        public Action<MidiMessage> OnBankSelectChange = (m) => { };
        private void onBankSelectChange(MidiMessage message)
        {
            if(message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.BankSelect.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.BankSelect.SetLsb(message.Data2);

            OnBankSelectChange.Invoke(message);
        }

        public Action<MidiMessage> OnModulationChange = (m) => { };
        private void onModulationChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Modulation.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Modulation.SetLsb(message.Data2);

            OnModulationChange.Invoke(message);
        }

        public Action<MidiMessage> OnBreathControllerChange = (m) => { };
        private void onBreathControllerChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.BreathController.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.BreathController.SetLsb(message.Data2);

            OnBreathControllerChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined03Change = (m) => { };
        private void onUndefined03Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined03.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined03.SetLsb(message.Data2);

            OnUndefined03Change.Invoke(message);
        }

        public Action<MidiMessage> OnFootControllerChange = (m) => { };
        private void onFootControllerChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.FootController.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.FootController.SetLsb(message.Data2);

            OnFootControllerChange.Invoke(message);
        }

        public Action<MidiMessage> OnPortamentoTimeChange = (m) => { };
        private void onPortamentoTimeChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.PortamentoTime.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.PortamentoTime.SetLsb(message.Data2);

            OnPortamentoTimeChange.Invoke(message);
        }

        public Action<MidiMessage> OnChannelVolumeChange = (m) => { };
        private void onChannelVolumeChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.ChannelVolume.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.ChannelVolume.SetLsb(message.Data2);

            OnChannelVolumeChange.Invoke(message);
        }

        public Action<MidiMessage> OnBalanceChange = (m) => { };
        private void onBalanceChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Balance.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Balance.SetLsb(message.Data2);

            OnBalanceChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined09Change = (m) => { };
        private void onUndefined09Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined09.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined09.SetLsb(message.Data2);

            OnUndefined09Change.Invoke(message);
        }

        public Action<MidiMessage> OnPanChange = (m) => { };
        private void onPanChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Pan.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Pan.SetLsb(message.Data2);

            OnPanChange.Invoke(message);
        }

        public Action<MidiMessage> OnExpressionControllerChange = (m) => { };
        private void onExpressionControllerChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.ExpressionController.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.ExpressionController.SetLsb(message.Data2);

            OnExpressionControllerChange.Invoke(message);
        }

        public Action<MidiMessage> OnEffectControl1Change = (m) => { };
        private void onEffectControl1Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.EffectControl1.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.EffectControl1.SetLsb(message.Data2);

            OnEffectControl1Change.Invoke(message);
        }

        public Action<MidiMessage> OnEffectControl2Change = (m) => { };
        private void onEffectControl2Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.EffectControl2.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.EffectControl2.SetLsb(message.Data2);

            OnEffectControl2Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined0EChange = (m) => { };
        private void onUndefined0EChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined0E.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined0E.SetLsb(message.Data2);

            OnUndefined0EChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined0FChange = (m) => { };
        private void onUndefined0FChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined0F.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined0F.SetLsb(message.Data2);

            OnUndefined0FChange.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController1Change = (m) => { };
        private void onGeneralPurposeController1Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.GeneralPurposeController1.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.GeneralPurposeController1.SetLsb(message.Data2);

            OnGeneralPurposeController1Change.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController2Change = (m) => { };
        private void onGeneralPurposeController2Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.GeneralPurposeController2.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.GeneralPurposeController2.SetLsb(message.Data2);

            OnGeneralPurposeController2Change.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController3Change = (m) => { };
        private void onGeneralPurposeController3Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.GeneralPurposeController3.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.GeneralPurposeController3.SetLsb(message.Data2);

            OnGeneralPurposeController3Change.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController4Change = (m) => { };
        private void onGeneralPurposeController4Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.GeneralPurposeController4.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.GeneralPurposeController4.SetLsb(message.Data2);

            OnGeneralPurposeController4Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined14Change = (m) => { };
        private void onUndefined14Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined14.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined14.SetLsb(message.Data2);

            OnUndefined14Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined15Change = (m) => { };
        private void onUndefined15Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined15.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined15.SetLsb(message.Data2);

            OnUndefined15Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined16Change = (m) => { };
        private void onUndefined16Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined16.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined16.SetLsb(message.Data2);

            OnUndefined16Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined17Change = (m) => { };
        private void onUndefined17Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined17.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined17.SetLsb(message.Data2);

            OnUndefined17Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined18Change = (m) => { };
        private void onUndefined18Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined18.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined18.SetLsb(message.Data2);

            OnUndefined18Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined19Change = (m) => { };
        private void onUndefined19Change(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined19.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined19.SetLsb(message.Data2);

            OnUndefined19Change.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1AChange = (m) => { };
        private void onUndefined1AChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined1A.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined1A.SetLsb(message.Data2);

            OnUndefined1AChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1BChange = (m) => { };
        private void onUndefined1BChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined1B.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined1B.SetLsb(message.Data2);

            OnUndefined1BChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1CChange = (m) => { };
        private void onUndefined1CChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined1C.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined1C.SetLsb(message.Data2);

            OnUndefined1CChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1DChange = (m) => { };
        private void onUndefined1DChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined1D.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined1D.SetLsb(message.Data2);

            OnUndefined1DChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1EChange = (m) => { };
        private void onUndefined1EChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined1E.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined1E.SetLsb(message.Data2);

            OnUndefined1EChange.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined1FChange = (m) => { };
        private void onUndefined1FChange(MidiMessage message)
        {
            if (message.IsCCMsb)
                ChannelState[message.Channel].DoubleCC.Undefined1F.SetMsb(message.Data2);
            else
                ChannelState[message.Channel].DoubleCC.Undefined1F.SetLsb(message.Data2);

            OnUndefined1FChange.Invoke(message);
        }
    }
}
