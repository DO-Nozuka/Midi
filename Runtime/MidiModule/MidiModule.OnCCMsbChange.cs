using System;

namespace Dono.Midi
{
    public partial class MidiModule // ControlChange Msb
    {
        public Action<MidiMessage> OnBankSelectMSB = (m) => { };
        public Action<MidiMessage> OnModulationMSB = (m) => { };
        public Action<MidiMessage> OnBreathControllerMSB = (m) => { };
        public Action<MidiMessage> OnUndefined03MSB = (m) => { };
        public Action<MidiMessage> OnFootControllerMSB = (m) => { };
        public Action<MidiMessage> OnPortamentoTimeMSB = (m) => { };
        public Action<MidiMessage> OnChannelVolumeMSB = (m) => { };

        private void onBankSelectMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BankSelect.SetMsb(message.Data2);
            OnBankSelectChange(message);

            OnBankSelectMSB.Invoke(message);
        }
        private void onModulationMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Modulation.SetMsb(message.Data2);
            OnModulationChange(message);

            OnModulationMSB.Invoke(message);
        }
        private void onBreathControllerMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BreathController.SetMsb(message.Data2);
            OnBreathControllerChange(message);

            OnBreathControllerMSB.Invoke(message);
        }
        private void onUndefined03MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined03.SetMsb(message.Data2);
            OnUndefined03Change(message);

            OnUndefined03MSB.Invoke(message);
        }
        private void onFootControllerMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.FootController.SetMsb(message.Data2);
            OnFootControllerChange(message);
            OnFootControllerMSB.Invoke(message);
        }
        private void onPortamentoTimeMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.PortamentoTime.SetMsb(message.Data2);
            OnPortamentoTimeChange(message);

            OnPortamentoTimeMSB.Invoke(message);
        }
        private void onChannelVolumeMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ChannelVolume.SetMsb(message.Data2);
            OnChannelVolumeChange(message);

            OnChannelVolumeMSB.Invoke(message);
        }
        private void onBalanceMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Balance.SetMsb(message.Data2);
            OnBalanceChange(message);

            OnBalanceMSB.Invoke(message);
        }

        public Action<MidiMessage> OnBalanceMSB = (m) => { };
        public Action<MidiMessage> OnUndefined09MSB = (m) => { };
        public Action<MidiMessage> OnPanMSB = (m) => { };
        public Action<MidiMessage> OnExpressionControllerMSB = (m) => { };
        public Action<MidiMessage> OnEffectControl1MSB = (m) => { };
        public Action<MidiMessage> OnEffectControl2MSB = (m) => { };
        public Action<MidiMessage> OnUndefined0EMSB = (m) => { };
        public Action<MidiMessage> OnUndefined0FMSB = (m) => { };

        private void onUndefined09MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined09.SetMsb(message.Data2);
            OnUndefined09Change(message);

            OnUndefined09MSB.Invoke(message);
        }
        private void onPanMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Pan.SetMsb(message.Data2);
            OnPanChange(message);

            OnPanMSB.Invoke(message);
        }
        private void onExpressionControllerMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ExpressionController.SetMsb(message.Data2);
            OnExpressionControllerChange(message);

            OnExpressionControllerMSB.Invoke(message);
        }
        private void onEffectControl1MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl1.SetMsb(message.Data2);
            OnEffectControl1Change(message);

            OnEffectControl1MSB.Invoke(message);
        }
        private void onEffectControl2MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl2.SetMsb(message.Data2);
            OnEffectControl2Change(message);

            OnEffectControl2MSB.Invoke(message);
        }
        private void onUndefined0EMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0E.SetMsb(message.Data2);
            OnUndefined0EChange(message);

            OnUndefined0EMSB.Invoke(message);
        }
        private void onUndefined0FMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0F.SetMsb(message.Data2);
            OnUndefined0FChange(message);

            OnUndefined0FMSB.Invoke(message);
        }
        public Action<MidiMessage> OnGeneralPurposeController1MSB = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController2MSB = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController3MSB = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController4MSB = (m) => { };
        public Action<MidiMessage> OnUndefined14MSB = (m) => { };
        public Action<MidiMessage> OnUndefined15MSB = (m) => { };
        public Action<MidiMessage> OnUndefined16MSB = (m) => { };
        public Action<MidiMessage> OnUndefined17MSB = (m) => { };
        private void onGeneralPurposeController1MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController1.SetMsb(message.Data2);
            OnGeneralPurposeController1Change(message);

            OnGeneralPurposeController1MSB.Invoke(message);
        }
        private void onGeneralPurposeController2MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController2.SetMsb(message.Data2);
            OnGeneralPurposeController2Change(message);

            OnGeneralPurposeController2MSB.Invoke(message);
        }
        private void onGeneralPurposeController3MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController3.SetMsb(message.Data2);
            OnGeneralPurposeController3Change(message);

            OnGeneralPurposeController3MSB.Invoke(message);
        }
        private void onGeneralPurposeController4MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController4.SetMsb(message.Data2);
            OnGeneralPurposeController4Change(message);

            OnGeneralPurposeController4MSB.Invoke(message);
        }
        private void onUndefined14MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined14.SetMsb(message.Data2);
            OnUndefined14Change(message);

            OnUndefined14MSB.Invoke(message);
        }
        private void onUndefined15MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined15.SetMsb(message.Data2);
            OnUndefined15Change(message);

            OnUndefined15MSB.Invoke(message);
        }
        private void onUndefined16MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined16.SetMsb(message.Data2);
            OnUndefined16Change(message);

            OnUndefined16MSB.Invoke(message);
        }
        private void onUndefined17MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined17.SetMsb(message.Data2);
            OnUndefined17Change(message);

            OnUndefined17MSB.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined18MSB = (m) => { };
        public Action<MidiMessage> OnUndefined19MSB = (m) => { };
        public Action<MidiMessage> OnUndefined1AMSB = (m) => { };
        public Action<MidiMessage> OnUndefined1BMSB = (m) => { };
        public Action<MidiMessage> OnUndefined1CMSB = (m) => { };
        public Action<MidiMessage> OnUndefined1DMSB = (m) => { };
        public Action<MidiMessage> OnUndefined1EMSB = (m) => { };
        public Action<MidiMessage> OnUndefined1FMSB = (m) => { };
        private void onUndefined18MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined18.SetMsb(message.Data2);
            OnUndefined18Change(message);

            OnUndefined18MSB.Invoke(message);
        }
        private void onUndefined19MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined19.SetMsb(message.Data2);
            OnUndefined19Change(message);

            OnUndefined19MSB.Invoke(message);
        }
        private void onUndefined1AMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1A.SetMsb(message.Data2);
            OnUndefined1AChange(message);

            OnUndefined1AMSB.Invoke(message);
        }
        private void onUndefined1BMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1B.SetMsb(message.Data2);
            OnUndefined1BChange(message);

            OnUndefined1BMSB.Invoke(message);
        }
        private void onUndefined1CMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1C.SetMsb(message.Data2);
            OnUndefined1CChange(message);

            OnUndefined1CMSB.Invoke(message);
        }
        private void onUndefined1DMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1D.SetMsb(message.Data2);
            OnUndefined1DChange(message);

            OnUndefined1DMSB.Invoke(message);
        }
        private void onUndefined1EMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1E.SetMsb(message.Data2);
            OnUndefined1EChange(message);

            OnUndefined1EMSB.Invoke(message);
        }
        private void onUndefined1FMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1F.SetMsb(message.Data2);
            OnUndefined1FChange(message);

            OnUndefined1FMSB.Invoke(message);
        }
    }
}
