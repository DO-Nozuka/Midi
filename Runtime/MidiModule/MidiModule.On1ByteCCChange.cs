using System;

namespace Dono.Midi
{
    public partial class MidiModule //On1ByteCCChange
    {
        public Action<MidiMessage> OnHold { get; private set; } = (m) => { };
        private void onHold(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Hold.SetBits(message.Data2);

            OnHold.Invoke(message);
        }
        public Action<MidiMessage> OnPortamento {get; private set;} = (m) => {};
        private void onPortamento(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Portamento.SetBits(message.Data2);

            OnPortamento.Invoke(message);
        }
        public Action<MidiMessage> OnSostenuto {get; private set;} = (m) => {};
        private void onSostenuto(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Sostenuto.SetBits(message.Data2);

            OnSostenuto.Invoke(message);
        }
        public Action<MidiMessage> OnSoftPedal {get; private set;} = (m) => {};
        private void onSoftPedal(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoftPedal.SetBits(message.Data2);

            OnSoftPedal.Invoke(message);
        }
        public Action<MidiMessage> OnLegatoFootswitch {get; private set;} = (m) => {};
        private void onLegatoFootswitch(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.LegatoFootswitch.SetBits(message.Data2);

            OnLegatoFootswitch.Invoke(message);
        }
        public Action<MidiMessage> OnHold2 {get; private set;} = (m) => {};
        private void onHold2(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Hold2.SetBits(message.Data2);

            OnHold2.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController1 {get; private set;} = (m) => {};
        private void onSoundController1(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController1.SetBits(message.Data2);

            OnSoundController1.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController2 {get; private set;} = (m) => {};
        private void onSoundController2(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController2.SetBits(message.Data2);

            OnSoundController2.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController3 {get; private set;} = (m) => {};
        private void onSoundController3(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController3.SetBits(message.Data2);

            OnSoundController3.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController4 {get; private set;} = (m) => {};
        private void onSoundController4(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController4.SetBits(message.Data2);

            OnSoundController4.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController5 {get; private set;} = (m) => {};
        private void onSoundController5(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController5.SetBits(message.Data2);

            OnSoundController5.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController6 {get; private set;} = (m) => {};
        private void onSoundController6(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController6.SetBits(message.Data2);

            OnSoundController6.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController7 {get; private set;} = (m) => {};
        private void onSoundController7(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController7.SetBits(message.Data2);

            OnSoundController7.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController8 {get; private set;} = (m) => {};
        private void onSoundController8(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController8.SetBits(message.Data2);

            OnSoundController8.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController9 {get; private set;} = (m) => {};
        private void onSoundController9(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController9.SetBits(message.Data2);

            OnSoundController9.Invoke(message);
        }
        public Action<MidiMessage> OnSoundController10 {get; private set;} = (m) => {};
        private void onSoundController10(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.SoundController10.SetBits(message.Data2);

            OnSoundController10.Invoke(message);
        }
        public Action<MidiMessage> OnGeneralPurposeController5 {get; private set;} = (m) => {};
        private void onGeneralPurposeController5(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.GeneralPurposeController5.SetBits(message.Data2);

            OnGeneralPurposeController5.Invoke(message);
        }
        public Action<MidiMessage> OnGeneralPurposeController6 {get; private set;} = (m) => {};
        private void onGeneralPurposeController6(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.GeneralPurposeController6.SetBits(message.Data2);

            OnGeneralPurposeController6.Invoke(message);
        }
        public Action<MidiMessage> OnGeneralPurposeController7 {get; private set;} = (m) => {};
        private void onGeneralPurposeController7(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.GeneralPurposeController7.SetBits(message.Data2);

            OnGeneralPurposeController7.Invoke(message);
        }
        public Action<MidiMessage> OnGeneralPurposeController8 {get; private set;} = (m) => {};
        private void onGeneralPurposeController8(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.GeneralPurposeController8.SetBits(message.Data2);

            OnGeneralPurposeController8.Invoke(message);
        }
        public Action<MidiMessage> OnPortamentoControl {get; private set;} = (m) => {};
        private void onPortamentoControl(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.PortamentoControl.SetBits(message.Data2);

            OnPortamentoControl.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined55 {get; private set;} = (m) => {};
        private void onUndefined55(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined55.SetBits(message.Data2);

            OnUndefined55.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined56 {get; private set;} = (m) => {};
        private void onUndefined56(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined56.SetBits(message.Data2);

            OnUndefined56.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined57 {get; private set;} = (m) => {};
        private void onUndefined57(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined57.SetBits(message.Data2);

            OnUndefined57.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined58 {get; private set;} = (m) => {};
        private void onUndefined58(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined58.SetBits(message.Data2);

            OnUndefined58.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined59 {get; private set;} = (m) => {};
        private void onUndefined59(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined59.SetBits(message.Data2);

            OnUndefined59.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined5A {get; private set;} = (m) => {};
        private void onUndefined5A(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined5A.SetBits(message.Data2);

            OnUndefined5A.Invoke(message);
        }
        public Action<MidiMessage> OnEffects1Depth {get; private set;} = (m) => {};
        private void onEffects1Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects1Depth.SetBits(message.Data2);

            OnEffects1Depth.Invoke(message);
        }
        public Action<MidiMessage> OnEffects2Depth {get; private set;} = (m) => {};
        private void onEffects2Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects2Depth.SetBits(message.Data2);

            OnEffects2Depth.Invoke(message);
        }
        public Action<MidiMessage> OnEffects3Depth {get; private set;} = (m) => {};
        private void onEffects3Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects3Depth.SetBits(message.Data2);

            OnEffects3Depth.Invoke(message);
        }
        public Action<MidiMessage> OnEffects4Depth {get; private set;} = (m) => {};
        private void onEffects4Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects4Depth.SetBits(message.Data2);

            OnEffects4Depth.Invoke(message);
        }
        public Action<MidiMessage> OnEffects5Depth {get; private set;} = (m) => {};
        private void onEffects5Depth(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Effects5Depth.SetBits(message.Data2);

            OnEffects5Depth.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined66 {get; private set;} = (m) => {};
        private void onUndefined66(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined66.SetBits(message.Data2);

            OnUndefined66.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined67 {get; private set;} = (m) => {};
        private void onUndefined67(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined67.SetBits(message.Data2);

            OnUndefined67.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined68 {get; private set;} = (m) => {};
        private void onUndefined68(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined68.SetBits(message.Data2);

            OnUndefined68.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined69 {get; private set;} = (m) => {};
        private void onUndefined69(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined69.SetBits(message.Data2);

            OnUndefined69.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined6A {get; private set;} = (m) => {};
        private void onUndefined6A(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6A.SetBits(message.Data2);

            OnUndefined6A.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined6B {get; private set;} = (m) => {};
        private void onUndefined6B(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6B.SetBits(message.Data2);

            OnUndefined6B.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined6C {get; private set;} = (m) => {};
        private void onUndefined6C(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6C.SetBits(message.Data2);

            OnUndefined6C.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined6D {get; private set;} = (m) => {};
        private void onUndefined6D(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6D.SetBits(message.Data2);

            OnUndefined6D.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined6E {get; private set;} = (m) => {};
        private void onUndefined6E(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6E.SetBits(message.Data2);

            OnUndefined6E.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined6F {get; private set;} = (m) => {};
        private void onUndefined6F(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined6F.SetBits(message.Data2);

            OnUndefined6F.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined70 {get; private set;} = (m) => {};
        private void onUndefined70(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined70.SetBits(message.Data2);

            OnUndefined70.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined71 {get; private set;} = (m) => {};
        private void onUndefined71(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined71.SetBits(message.Data2);

            OnUndefined71.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined72 {get; private set;} = (m) => {};
        private void onUndefined72(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined72.SetBits(message.Data2);

            OnUndefined72.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined73 {get; private set;} = (m) => {};
        private void onUndefined73(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined73.SetBits(message.Data2);

            OnUndefined73.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined74 {get; private set;} = (m) => {};
        private void onUndefined74(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined74.SetBits(message.Data2);

            OnUndefined74.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined75 {get; private set;} = (m) => {};
        private void onUndefined75(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined75.SetBits(message.Data2);

            OnUndefined75.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined76 {get; private set;} = (m) => {};
        private void onUndefined76(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined76.SetBits(message.Data2);

            OnUndefined76.Invoke(message);
        }
        public Action<MidiMessage> OnUndefined77 {get; private set;} = (m) => {};
        private void onUndefined77(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.Undefined77.SetBits(message.Data2);

            OnUndefined77.Invoke(message);
        }
    }
}
