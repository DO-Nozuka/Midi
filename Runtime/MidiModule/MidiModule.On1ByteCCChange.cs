using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{
    public partial class MidiModule //On1ByteCCChange
    {
        public virtual void OnHold(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Hold.SetBits(message.Data2);
        }
        public virtual void OnPortamento(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Portamento.SetBits(message.Data2);
        }
        public virtual void OnSostenuto(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Sostenuto.SetBits(message.Data2);
        }
        public virtual void OnSoftPedal(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoftPedal.SetBits(message.Data2);
        }
        public virtual void OnLegatoFootswitch(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.LegatoFootswitch.SetBits(message.Data2);
        }
        public virtual void OnHold2(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Hold2.SetBits(message.Data2);
        }
        public virtual void OnSoundController1(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController1.SetBits(message.Data2);
        }
        public virtual void OnSoundController2(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController2.SetBits(message.Data2);
        }
        public virtual void OnSoundController3(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController3.SetBits(message.Data2);
        }
        public virtual void OnSoundController4(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController4.SetBits(message.Data2);
        }
        public virtual void OnSoundController5(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController5.SetBits(message.Data2);
        }
        public virtual void OnSoundController6(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController6.SetBits(message.Data2);
        }
        public virtual void OnSoundController7(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController7.SetBits(message.Data2);
        }
        public virtual void OnSoundController8(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController8.SetBits(message.Data2);
        }
        public virtual void OnSoundController9(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController9.SetBits(message.Data2);
        }
        public virtual void OnSoundController10(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController10.SetBits(message.Data2);
        }
        public virtual void OnGeneralPurposeController5(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.GeneralPurposeController5.SetBits(message.Data2);
        }
        public virtual void OnGeneralPurposeController6(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.GeneralPurposeController6.SetBits(message.Data2);
        }
        public virtual void OnGeneralPurposeController7(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.GeneralPurposeController7.SetBits(message.Data2);
        }
        public virtual void OnGeneralPurposeController8(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.GeneralPurposeController8.SetBits(message.Data2);
        }
        public virtual void OnPortamentoControl(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.PortamentoControl.SetBits(message.Data2);
        }
        public virtual void OnUndefined55(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined55.SetBits(message.Data2);
        }
        public virtual void OnUndefined56(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined56.SetBits(message.Data2);
        }
        public virtual void OnUndefined57(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined57.SetBits(message.Data2);
        }
        public virtual void OnUndefined58(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined58.SetBits(message.Data2);
        }
        public virtual void OnUndefined59(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined59.SetBits(message.Data2);
        }
        public virtual void OnUndefined5A(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined5A.SetBits(message.Data2);
        }
        public virtual void OnEffects1Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects1Depth.SetBits(message.Data2);
        }
        public virtual void OnEffects2Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects2Depth.SetBits(message.Data2);
        }
        public virtual void OnEffects3Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects3Depth.SetBits(message.Data2);
        }
        public virtual void OnEffects4Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects4Depth.SetBits(message.Data2);
        }
        public virtual void OnEffects5Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects5Depth.SetBits(message.Data2);
        }
        public virtual void OnUndefined66(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined66.SetBits(message.Data2);
        }
        public virtual void OnUndefined67(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined67.SetBits(message.Data2);
        }
        public virtual void OnUndefined68(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined68.SetBits(message.Data2);
        }
        public virtual void OnUndefined69(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined69.SetBits(message.Data2);
        }
        public virtual void OnUndefined6A(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6A.SetBits(message.Data2);
        }
        public virtual void OnUndefined6B(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6B.SetBits(message.Data2);
        }
        public virtual void OnUndefined6C(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6C.SetBits(message.Data2);
        }
        public virtual void OnUndefined6D(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6D.SetBits(message.Data2);
        }
        public virtual void OnUndefined6E(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6E.SetBits(message.Data2);
        }
        public virtual void OnUndefined6F(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6F.SetBits(message.Data2);
        }
        public virtual void OnUndefined70(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined70.SetBits(message.Data2);
        }
        public virtual void OnUndefined71(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined71.SetBits(message.Data2);
        }
        public virtual void OnUndefined72(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined72.SetBits(message.Data2);
        }
        public virtual void OnUndefined73(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined73.SetBits(message.Data2);
        }
        public virtual void OnUndefined74(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined74.SetBits(message.Data2);
        }
        public virtual void OnUndefined75(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined75.SetBits(message.Data2);
        }
        public virtual void OnUndefined76(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined76.SetBits(message.Data2);
        }
        public virtual void OnUndefined77(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined77.SetBits(message.Data2);
        }
    }
}
