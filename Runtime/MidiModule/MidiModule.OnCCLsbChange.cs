using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule // ControlChange Lsb
    {
        public Action<MidiMessage> OnBankSelectLSB = (m) => { };
        public Action<MidiMessage> OnModulationLSB = (m) => { };
        public Action<MidiMessage> OnBreathControllerLSB = (m) => { };
        public Action<MidiMessage> OnUndefined03LSB = (m) => { };
        public Action<MidiMessage> OnFootControllerLSB = (m) => { };
        public Action<MidiMessage> OnPortamentoTimeLSB = (m) => { };
        public Action<MidiMessage> OnChannelVolumeLSB = (m) => { };

        private void onBankSelectLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BankSelect.SetMsb(message.Data2);
            onBankSelectChange(message);
            
            OnBankSelectLSB.Invoke(message);
        }
        private void onModulationLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Modulation.SetMsb(message.Data2);
            onModulationChange(message);
            
            OnModulationLSB.Invoke(message);
        }
        private void onBreathControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BreathController.SetMsb(message.Data2);
            onBreathControllerChange(message);
            
            OnBreathControllerLSB.Invoke(message);
        }
        private void onUndefined03LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined03.SetMsb(message.Data2);
            onUndefined03Change(message);
            
            OnUndefined03LSB.Invoke(message);
        }
        private void onFootControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.FootController.SetMsb(message.Data2);
            onFootControllerChange(message);
            
            OnFootControllerLSB.Invoke(message);
        }
        private void onPortamentoTimeLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.PortamentoTime.SetMsb(message.Data2);
            onPortamentoTimeChange(message);
            
            OnPortamentoTimeLSB.Invoke(message);
        }
        private void onChannelVolumeLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ChannelVolume.SetMsb(message.Data2);
            onChannelVolumeChange(message);
            
            OnChannelVolumeLSB.Invoke(message);
        }
        public Action<MidiMessage> OnBalanceLSB = (m) => { };
        public Action<MidiMessage> OnUndefined09LSB = (m) => { };
        public Action<MidiMessage> OnPanLSB = (m) => { };
        public Action<MidiMessage> OnExpressionControllerLSB = (m) => { };
        public Action<MidiMessage> OnEffectControl1LSB = (m) => { };
        public Action<MidiMessage> OnEffectControl2LSB = (m) => { };
        public Action<MidiMessage> OnUndefined0ELSB = (m) => { };
        public Action<MidiMessage> OnUndefined0FLSB = (m) => { };
        private void onBalanceLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Balance.SetMsb(message.Data2);
            onBalanceChange(message);
            
            OnBalanceLSB.Invoke(message);
        }
        private void onUndefined09LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined09.SetMsb(message.Data2);
            onUndefined09Change(message);
            
            OnUndefined09LSB.Invoke(message);
        }
        private void onPanLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Pan.SetMsb(message.Data2);
            onPanChange(message);
            
            OnPanLSB.Invoke(message);
        }
        private void onExpressionControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ExpressionController.SetMsb(message.Data2);
            onExpressionControllerChange(message);
            
            OnExpressionControllerLSB.Invoke(message);
        }
        private void onEffectControl1LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl1.SetMsb(message.Data2);
            onEffectControl1Change(message);
            
            OnEffectControl1LSB.Invoke(message);
        }
        private void onEffectControl2LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl2.SetMsb(message.Data2);
            onEffectControl2Change(message);
            
            OnEffectControl2LSB.Invoke(message);
        }
        private void onUndefined0ELSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0E.SetMsb(message.Data2);
            onUndefined0EChange(message);
            
            OnUndefined0ELSB.Invoke(message);
        }
        private void onUndefined0FLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0F.SetMsb(message.Data2);
            onUndefined0FChange(message);
            
            OnUndefined0FLSB.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController1LSB = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController2LSB = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController3LSB = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController4LSB = (m) => { };
        public Action<MidiMessage> OnUndefined14LSB = (m) => { };
        public Action<MidiMessage> OnUndefined15LSB = (m) => { };
        public Action<MidiMessage> OnUndefined16LSB = (m) => { };
        public Action<MidiMessage> OnUndefined17LSB = (m) => { };
        private void onGeneralPurposeController1LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController1.SetMsb(message.Data2);
            onGeneralPurposeController1Change(message);
            
            OnGeneralPurposeController1LSB.Invoke(message);
        }
        private void onGeneralPurposeController2LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController2.SetMsb(message.Data2);
            onGeneralPurposeController2Change(message);
            
            OnGeneralPurposeController2LSB.Invoke(message);
        }
        private void onGeneralPurposeController3LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController3.SetMsb(message.Data2);
            onGeneralPurposeController3Change(message);
            
            OnGeneralPurposeController3LSB.Invoke(message);
        }
        private void onGeneralPurposeController4LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController4.SetMsb(message.Data2);
            onGeneralPurposeController4Change(message);
            
            OnGeneralPurposeController4LSB.Invoke(message);
        }
        private void onUndefined14LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined14.SetMsb(message.Data2);
            onUndefined14Change(message);
            
            OnUndefined14LSB.Invoke(message);
        }
        private void onUndefined15LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined15.SetMsb(message.Data2);
            onUndefined15Change(message);
            
            OnUndefined15LSB.Invoke(message);
        }
        private void onUndefined16LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined16.SetMsb(message.Data2);
            onUndefined16Change(message);
            
            OnUndefined16LSB.Invoke(message);
        }
        private void onUndefined17LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined17.SetMsb(message.Data2);
            onUndefined17Change(message);
            
            OnUndefined17LSB.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined18LSB = (m) => { };
        public Action<MidiMessage> OnUndefined19LSB = (m) => { };
        public Action<MidiMessage> OnUndefined1ALSB = (m) => { };
        public Action<MidiMessage> OnUndefined1BLSB = (m) => { };
        public Action<MidiMessage> OnUndefined1CLSB = (m) => { };
        public Action<MidiMessage> OnUndefined1DLSB = (m) => { };
        public Action<MidiMessage> OnUndefined1ELSB = (m) => { };
        public Action<MidiMessage> OnUndefined1FLSB = (m) => { };
        private void onUndefined18LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined18.SetMsb(message.Data2);
            onUndefined18Change(message);
            
            OnUndefined18LSB.Invoke(message);
        }
        private void onUndefined19LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined19.SetMsb(message.Data2);
            onUndefined19Change(message);
            
            OnUndefined19LSB.Invoke(message);
        }
        private void onUndefined1ALSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1A.SetMsb(message.Data2);
            onUndefined1AChange(message);
            
            OnUndefined1ALSB.Invoke(message);
        }
        private void onUndefined1BLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1B.SetMsb(message.Data2);
            onUndefined1BChange(message);
            
            OnUndefined1BLSB.Invoke(message);
        }
        private void onUndefined1CLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1C.SetMsb(message.Data2);
            onUndefined1CChange(message);
            
            OnUndefined1CLSB.Invoke(message);
        }
        private void onUndefined1DLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1D.SetMsb(message.Data2);
            onUndefined1DChange(message);
            
            OnUndefined1DLSB.Invoke(message);
        }
        private void onUndefined1ELSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1E.SetMsb(message.Data2);
            onUndefined1EChange(message);
            
            OnUndefined1ELSB.Invoke(message);
        }
        private void onUndefined1FLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1F.SetMsb(message.Data2);
            onUndefined1FChange(message);
            
            OnUndefined1FLSB.Invoke(message);
        }
    }
}
