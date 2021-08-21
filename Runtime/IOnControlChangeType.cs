﻿namespace Dono.Midi.Runtime.Types
{
    public interface IOnControlChangeType
    {
        /* 14Bit MSB */
        void OnBankSelectMSB(MidiMessage message);
        void OnModulationMSB(MidiMessage message);
        void OnBreathControllerMSB(MidiMessage message);
        void OnUndefined03MSB(MidiMessage message);
        void OnFootControllerMSB(MidiMessage message);
        void OnPortamentoTimeMSB(MidiMessage message);
        void OnDataEntryMSB(MidiMessage message);
        void OnChannelVolumeMSB(MidiMessage message);
        void OnBalanceMSB(MidiMessage message);
        void OnUndefined09MSB(MidiMessage message);
        void OnPanMSB(MidiMessage message);
        void OnExpressionControllerMSB(MidiMessage message);
        void OnEffectControl1MSB(MidiMessage message);
        void OnEffectControl2MSB(MidiMessage message);
        void OnUndefined0EMSB(MidiMessage message);
        void OnUndefined0FMSB(MidiMessage message);
        void OnGeneralPurposeController1MSB(MidiMessage message);
        void OnGeneralPurposeController2MSB(MidiMessage message);
        void OnGeneralPurposeController3MSB(MidiMessage message);
        void OnGeneralPurposeController4MSB(MidiMessage message);
        void OnUndefined14MSB(MidiMessage message);
        void OnUndefined15MSB(MidiMessage message);
        void OnUndefined16MSB(MidiMessage message);
        void OnUndefined17MSB(MidiMessage message);
        void OnUndefined18MSB(MidiMessage message);
        void OnUndefined19MSB(MidiMessage message);
        void OnUndefined1AMSB(MidiMessage message);
        void OnUndefined1BMSB(MidiMessage message);
        void OnUndefined1CMSB(MidiMessage message);
        void OnUndefined1DMSB(MidiMessage message);
        void OnUndefined1EMSB(MidiMessage message);
        void OnUndefined1FMSB(MidiMessage message);
        /* 14Bit LSB */
        void OnBankSelectLSB(MidiMessage message);
        void OnModulationWheelLSB(MidiMessage message);
        void OnBreathControllerLSB(MidiMessage message);
        void OnUndefined03LSB(MidiMessage message);
        void OnFootControllerLSB(MidiMessage message);
        void OnPortamentoTimeLSB(MidiMessage message);
        void OnDataEntryLSB(MidiMessage message);
        void OnChannelVolumeLSB(MidiMessage message);
        void OnBalanceLSB(MidiMessage message);
        void OnUndefined09LSB(MidiMessage message);
        void OnPanLSB(MidiMessage message);
        void OnExpressionControllerLSB(MidiMessage message);
        void OnEffectControl1LSB(MidiMessage message);
        void OnEffectControl2LSB(MidiMessage message);
        void OnUndefined0ELSB(MidiMessage message);
        void OnUndefined0FLSB(MidiMessage message);
        void OnGeneralPurposeController1LSB(MidiMessage message);
        void OnGeneralPurposeController2LSB(MidiMessage message);
        void OnGeneralPurposeController3LSB(MidiMessage message);
        void OnGeneralPurposeController4LSB(MidiMessage message);
        void OnUndefined14LSB(MidiMessage message);
        void OnUndefined15LSB(MidiMessage message);
        void OnUndefined16LSB(MidiMessage message);
        void OnUndefined17LSB(MidiMessage message);
        void OnUndefined18LSB(MidiMessage message);
        void OnUndefined19LSB(MidiMessage message);
        void OnUndefined1ALSB(MidiMessage message);
        void OnUndefined1BLSB(MidiMessage message);
        void OnUndefined1CLSB(MidiMessage message);
        void OnUndefined1DLSB(MidiMessage message);
        void OnUndefined1ELSB(MidiMessage message);
        void OnUndefined1FLSB(MidiMessage message);

        /* 7Bit Message */
        void OnHold(MidiMessage message);
        void OnPortamento(MidiMessage message);
        void OnSostenuto(MidiMessage message);
        void OnSoftPedal(MidiMessage message);
        void OnLegatoFootswitch(MidiMessage message);
        void OnHold2(MidiMessage message);
        void OnSoundController1(MidiMessage message);
        void OnSoundController2(MidiMessage message);
        void OnSoundController3(MidiMessage message);
        void OnSoundController4(MidiMessage message);
        void OnSoundController5(MidiMessage message);
        void OnSoundController6(MidiMessage message);
        void OnSoundController7(MidiMessage message);
        void OnSoundController8(MidiMessage message);
        void OnSoundController9(MidiMessage message);
        void OnSoundController10(MidiMessage message);
        void OnGeneralPurposeController5(MidiMessage message);
        void OnGeneralPurposeController6(MidiMessage message);
        void OnGeneralPurposeController7(MidiMessage message);
        void OnGeneralPurposeController8(MidiMessage message);
        void OnPortamentoControl(MidiMessage message);
        void OnUndefined55(MidiMessage message);
        void OnUndefined56(MidiMessage message);
        void OnUndefined57(MidiMessage message);
        void OnUndefined58(MidiMessage message);/// High Resolution Velocit(MidiMessage message);
        void OnUndefined59(MidiMessage message);
        void OnUndefined60(MidiMessage message);
        void OnEffects1Depth(MidiMessage message);
        void OnEffects2Depth(MidiMessage message);
        void OnEffects3Depth(MidiMessage message);
        void OnEffects4Depth(MidiMessage message);
        void OnEffects5Depth(MidiMessage message);
        void OnDataIncrement(MidiMessage message);
        void OnDataDecrement(MidiMessage message);
        void OnNonRegisteredParameterNumberLSB(MidiMessage message);
        void OnNonRegisteredParameterNumberMSB(MidiMessage message);
        void OnRegisteredParameterNumberLSB(MidiMessage message);
        void OnRegisteredParameterNumberMSB(MidiMessage message);
        void OnUndefined66(MidiMessage message);
        void OnUndefined67(MidiMessage message);
        void OnUndefined68(MidiMessage message);
        void OnUndefined69(MidiMessage message);
        void OnUndefined6A(MidiMessage message);
        void OnUndefined6B(MidiMessage message);
        void OnUndefined6C(MidiMessage message);
        void OnUndefined6D(MidiMessage message);
        void OnUndefined6E(MidiMessage message);
        void OnUndefined6F(MidiMessage message);
        void OnUndefined70(MidiMessage message);
        void OnUndefined71(MidiMessage message);
        void OnUndefined72(MidiMessage message);
        void OnUndefined73(MidiMessage message);
        void OnUndefined74(MidiMessage message);
        void OnUndefined75(MidiMessage message);
        void OnUndefined76(MidiMessage message);
        void OnUndefined77(MidiMessage message);
    }

}