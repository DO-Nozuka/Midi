using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule // ControlChange Lsb
    {
        #region LSB Method
        public virtual void OnBankSelectLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BankSelect.SetMsb(message.Data2);
            OnBankSelectChange(message);
        }
        public virtual void OnModulationLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Modulation.SetMsb(message.Data2);
            OnModulationChange(message);
        }
        public virtual void OnBreathControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BreathController.SetMsb(message.Data2);
            OnBreathControllerChange(message);
        }
        public virtual void OnUndefined03LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined03.SetMsb(message.Data2);
            OnUndefined03Change(message);
        }
        public virtual void OnFootControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.FootController.SetMsb(message.Data2);
            OnFootControllerLSB(message);
        }
        public virtual void OnPortamentoTimeLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.PortamentoTime.SetMsb(message.Data2);
            OnPortamentoTimeChange(message);
        }
        public virtual void OnChannelVolumeLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ChannelVolume.SetMsb(message.Data2);
            OnChannelVolumeChange(message);
        }
        public virtual void OnBalanceLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Balance.SetMsb(message.Data2);
            OnBalanceChange(message);
        }
        public virtual void OnUndefined09LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined09.SetMsb(message.Data2);
            OnUndefined09Change(message);
        }
        public virtual void OnPanLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Pan.SetMsb(message.Data2);
            OnPanChange(message);
        }
        public virtual void OnExpressionControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ExpressionController.SetMsb(message.Data2);
            OnExpressionControllerChange(message);
        }
        public virtual void OnEffectControl1LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl1.SetMsb(message.Data2);
            OnEffectControl1Change(message);
        }
        public virtual void OnEffectControl2LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl2.SetMsb(message.Data2);
            OnEffectControl2Change(message);
        }
        public virtual void OnUndefined0ELSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0E.SetMsb(message.Data2);
            OnUndefined0EChange(message);
        }
        public virtual void OnUndefined0FLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0F.SetMsb(message.Data2);
            OnUndefined0FChange(message);
        }
        public virtual void OnGeneralPurposeController1LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController1.SetMsb(message.Data2);
            OnGeneralPurposeController1Change(message);
        }
        public virtual void OnGeneralPurposeController2LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController2.SetMsb(message.Data2);
            OnGeneralPurposeController2Change(message);
        }
        public virtual void OnGeneralPurposeController3LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController3.SetMsb(message.Data2);
            OnGeneralPurposeController3Change(message);
        }
        public virtual void OnGeneralPurposeController4LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController4.SetMsb(message.Data2);
            OnGeneralPurposeController4Change(message);
        }
        public virtual void OnUndefined14LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined14.SetMsb(message.Data2);
            OnUndefined14Change(message);
        }
        public virtual void OnUndefined15LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined15.SetMsb(message.Data2);
            OnUndefined15Change(message);
        }
        public virtual void OnUndefined16LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined16.SetMsb(message.Data2);
            OnUndefined16Change(message);
        }
        public virtual void OnUndefined17LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined17.SetMsb(message.Data2);
            OnUndefined17Change(message);
        }
        public virtual void OnUndefined18LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined18.SetMsb(message.Data2);
            OnUndefined18Change(message);
        }
        public virtual void OnUndefined19LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined19.SetMsb(message.Data2);
            OnUndefined19Change(message);
        }
        public virtual void OnUndefined1ALSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1A.SetMsb(message.Data2);
            OnUndefined1AChange(message);
        }
        public virtual void OnUndefined1BLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1B.SetMsb(message.Data2);
            OnUndefined1BChange(message);
        }
        public virtual void OnUndefined1CLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1C.SetMsb(message.Data2);
            OnUndefined1CChange(message);
        }
        public virtual void OnUndefined1DLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1D.SetMsb(message.Data2);
            OnUndefined1DChange(message);
        }
        public virtual void OnUndefined1ELSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1E.SetMsb(message.Data2);
            OnUndefined1EChange(message);
        }
        public virtual void OnUndefined1FLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1F.SetMsb(message.Data2);
            OnUndefined1FChange(message);
        }
        #endregion
    }
}
