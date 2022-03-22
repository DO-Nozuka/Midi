using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule // ControlChange Lsb
    {
        public Action<MidiMessage> OnBankSelectLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnModulationLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnBreathControllerLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined03LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnFootControllerLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnPortamentoTimeLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnChannelVolumeLSB { get; private set; } = (m) => { };

        private void onBankSelectLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BankSelect.SetMsb(message.Data2);
            OnBankSelectChange(message);
            
            OnBankSelectLSB.Invoke(message);
        }
        private void onModulationLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Modulation.SetMsb(message.Data2);
            OnModulationChange(message);
            
            OnModulationLSB.Invoke(message);
        }
        private void onBreathControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.BreathController.SetMsb(message.Data2);
            OnBreathControllerChange(message);
            
            OnBreathControllerLSB.Invoke(message);
        }
        private void onUndefined03LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined03.SetMsb(message.Data2);
            OnUndefined03Change(message);
            
            OnUndefined03LSB.Invoke(message);
        }
        private void onFootControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.FootController.SetMsb(message.Data2);
            OnFootControllerLSB(message);
            
            OnFootControllerLSB.Invoke(message);
        }
        private void onPortamentoTimeLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.PortamentoTime.SetMsb(message.Data2);
            OnPortamentoTimeChange(message);
            
            OnPortamentoTimeLSB.Invoke(message);
        }
        private void onChannelVolumeLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ChannelVolume.SetMsb(message.Data2);
            OnChannelVolumeChange(message);
            
            OnChannelVolumeLSB.Invoke(message);
        }
        public Action<MidiMessage> OnBalanceLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined09LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnPanLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnExpressionControllerLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnEffectControl1LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnEffectControl2LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined0ELSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined0FLSB { get; private set; } = (m) => { };
        private void onBalanceLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Balance.SetMsb(message.Data2);
            OnBalanceChange(message);
            
            OnBalanceLSB.Invoke(message);
        }
        private void onUndefined09LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined09.SetMsb(message.Data2);
            OnUndefined09Change(message);
            
            OnUndefined09LSB.Invoke(message);
        }
        private void onPanLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Pan.SetMsb(message.Data2);
            OnPanChange(message);
            
            OnPanLSB.Invoke(message);
        }
        private void onExpressionControllerLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.ExpressionController.SetMsb(message.Data2);
            OnExpressionControllerChange(message);
            
            OnExpressionControllerLSB.Invoke(message);
        }
        private void onEffectControl1LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl1.SetMsb(message.Data2);
            OnEffectControl1Change(message);
            
            OnEffectControl1LSB.Invoke(message);
        }
        private void onEffectControl2LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.EffectControl2.SetMsb(message.Data2);
            OnEffectControl2Change(message);
            
            OnEffectControl2LSB.Invoke(message);
        }
        private void onUndefined0ELSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0E.SetMsb(message.Data2);
            OnUndefined0EChange(message);
            
            OnUndefined0ELSB.Invoke(message);
        }
        private void onUndefined0FLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined0F.SetMsb(message.Data2);
            OnUndefined0FChange(message);
            
            OnUndefined0FLSB.Invoke(message);
        }

        public Action<MidiMessage> OnGeneralPurposeController1LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController2LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController3LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnGeneralPurposeController4LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined14LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined15LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined16LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined17LSB { get; private set; } = (m) => { };
        private void onGeneralPurposeController1LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController1.SetMsb(message.Data2);
            OnGeneralPurposeController1Change(message);
            
            OnGeneralPurposeController1LSB.Invoke(message);
        }
        private void onGeneralPurposeController2LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController2.SetMsb(message.Data2);
            OnGeneralPurposeController2Change(message);
            
            OnGeneralPurposeController2LSB.Invoke(message);
        }
        private void onGeneralPurposeController3LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController3.SetMsb(message.Data2);
            OnGeneralPurposeController3Change(message);
            
            OnGeneralPurposeController3LSB.Invoke(message);
        }
        private void onGeneralPurposeController4LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.GeneralPurposeController4.SetMsb(message.Data2);
            OnGeneralPurposeController4Change(message);
            
            OnGeneralPurposeController4LSB.Invoke(message);
        }
        private void onUndefined14LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined14.SetMsb(message.Data2);
            OnUndefined14Change(message);
            
            OnUndefined14LSB.Invoke(message);
        }
        private void onUndefined15LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined15.SetMsb(message.Data2);
            OnUndefined15Change(message);
            
            OnUndefined15LSB.Invoke(message);
        }
        private void onUndefined16LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined16.SetMsb(message.Data2);
            OnUndefined16Change(message);
            
            OnUndefined16LSB.Invoke(message);
        }
        private void onUndefined17LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined17.SetMsb(message.Data2);
            OnUndefined17Change(message);
            
            OnUndefined17LSB.Invoke(message);
        }

        public Action<MidiMessage> OnUndefined18LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined19LSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined1ALSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined1BLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined1CLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined1DLSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined1ELSB { get; private set; } = (m) => { };
        public Action<MidiMessage> OnUndefined1FLSB { get; private set; } = (m) => { };
        private void onUndefined18LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined18.SetMsb(message.Data2);
            OnUndefined18Change(message);
            
            OnUndefined18LSB.Invoke(message);
        }
        private void onUndefined19LSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined19.SetMsb(message.Data2);
            OnUndefined19Change(message);
            
            OnUndefined19LSB.Invoke(message);
        }
        private void onUndefined1ALSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1A.SetMsb(message.Data2);
            OnUndefined1AChange(message);
            
            OnUndefined1ALSB.Invoke(message);
        }
        private void onUndefined1BLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1B.SetMsb(message.Data2);
            OnUndefined1BChange(message);
            
            OnUndefined1BLSB.Invoke(message);
        }
        private void onUndefined1CLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1C.SetMsb(message.Data2);
            OnUndefined1CChange(message);
            
            OnUndefined1CLSB.Invoke(message);
        }
        private void onUndefined1DLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1D.SetMsb(message.Data2);
            OnUndefined1DChange(message);
            
            OnUndefined1DLSB.Invoke(message);
        }
        private void onUndefined1ELSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1E.SetMsb(message.Data2);
            OnUndefined1EChange(message);
            
            OnUndefined1ELSB.Invoke(message);
        }
        private void onUndefined1FLSB(MidiMessage message)
        {
            ChannelState[message.Channel].DoubleCC.Undefined1F.SetMsb(message.Data2);
            OnUndefined1FChange(message);
            
            OnUndefined1FLSB.Invoke(message);
        }
    }
}
