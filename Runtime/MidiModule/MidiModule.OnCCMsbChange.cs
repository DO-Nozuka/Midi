namespace Dono.Midi
{
    public partial class MidiModule // ControlChange Msb
    {
        #region MSB Method
        public virtual void OnBankSelectMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BankSelect.SetMsb(message.Data2);
            OnBankSelectChange(message);
        }
        public virtual void OnModulationMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Modulation.SetMsb(message.Data2);
            OnModulationChange(message);
        }
        public virtual void OnBreathControllerMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BreathController.SetMsb(message.Data2);
            OnBreathControllerMSB(message);
        }
        public virtual void OnUndefined03MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined03.SetMsb(message.Data2);
            OnUndefined03Change(message);
        }
        public virtual void OnFootControllerMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.FootController.SetMsb(message.Data2);
            OnFootControllerChange(message);
        }
        public virtual void OnPortamentoTimeMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.PortamentoTime.SetMsb(message.Data2);
            OnPortamentoTimeChange(message);
        }
        public virtual void OnChannelVolumeMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ChannelVolume.SetMsb(message.Data2);
            OnChannelVolumeChange(message);
        }
        public virtual void OnBalanceMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Balance.SetMsb(message.Data2);
            OnBalanceChange(message);
        }
        public virtual void OnUndefined09MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined09.SetMsb(message.Data2);
            OnUndefined09Change(message);
        }
        public virtual void OnPanMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Pan.SetMsb(message.Data2);
            OnPanChange(message);
        }
        public virtual void OnExpressionControllerMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ExpressionController.SetMsb(message.Data2);
            OnExpressionControllerChange(message);
        }
        public virtual void OnEffectControl1MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl1.SetMsb(message.Data2);
            OnEffectControl1Change(message);
        }
        public virtual void OnEffectControl2MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl2.SetMsb(message.Data2);
            OnEffectControl2Change(message);
        }
        public virtual void OnUndefined0EMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0E.SetMsb(message.Data2);
            OnUndefined0EChange(message);
        }
        public virtual void OnUndefined0FMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0F.SetMsb(message.Data2);
            OnUndefined0FChange(message);
        }
        public virtual void OnGeneralPurposeController1MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController1.SetMsb(message.Data2);
            OnGeneralPurposeController1Change(message);
        }
        public virtual void OnGeneralPurposeController2MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController2.SetMsb(message.Data2);
            OnGeneralPurposeController2Change(message);
        }
        public virtual void OnGeneralPurposeController3MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController3.SetMsb(message.Data2);
            OnGeneralPurposeController3Change(message);
        }
        public virtual void OnGeneralPurposeController4MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController4.SetMsb(message.Data2);
            OnGeneralPurposeController4Change(message);
        }
        public virtual void OnUndefined14MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined14.SetMsb(message.Data2);
            OnUndefined14Change(message);
        }
        public virtual void OnUndefined15MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined15.SetMsb(message.Data2);
            OnUndefined15Change(message);
        }
        public virtual void OnUndefined16MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined16.SetMsb(message.Data2);
            OnUndefined16Change(message);
        }
        public virtual void OnUndefined17MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined17.SetMsb(message.Data2);
            OnUndefined17Change(message);
        }
        public virtual void OnUndefined18MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined18.SetMsb(message.Data2);
            OnUndefined18Change(message);
        }
        public virtual void OnUndefined19MSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined19.SetMsb(message.Data2);
            OnUndefined19Change(message);
        }
        public virtual void OnUndefined1AMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1A.SetMsb(message.Data2);
            OnUndefined1AChange(message);
        }
        public virtual void OnUndefined1BMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1B.SetMsb(message.Data2);
            OnUndefined1BChange(message);
        }
        public virtual void OnUndefined1CMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1C.SetMsb(message.Data2);
            OnUndefined1CChange(message);
        }
        public virtual void OnUndefined1DMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1D.SetMsb(message.Data2);
            OnUndefined1DChange(message);
        }
        public virtual void OnUndefined1EMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1E.SetMsb(message.Data2);
            OnUndefined1EChange(message);
        }
        public virtual void OnUndefined1FMSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1F.SetMsb(message.Data2);
            OnUndefined1FChange(message);
        }
        #endregion
    }
}
