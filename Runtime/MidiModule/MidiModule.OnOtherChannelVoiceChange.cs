using System;

namespace Dono.Midi
{

    public partial class MidiModule // OnOtherChannelVoiceChange
    {
        public Action<MidiMessage> OnProgramChange = (m) => { };
        public Action<MidiMessage> OnChannelPressure = (m) => { };
        public Action<MidiMessage> OnPitchBendChange = (m) => { };

        private void onProgramChange(MidiMessage message)
        {
            ChannelState[message.Channel].Program.SetBits(message.Data1);

            OnProgramChange.Invoke(message);
        }
        private void onChannelPressure(MidiMessage message)
        {
            ChannelState[message.Channel].ChannelPressure.SetBits(message.Data1);

            OnChannelPressure.Invoke(message);
        }
        private void onPitchBendChange(MidiMessage message)
        {
            ChannelState[message.Channel].PitchBend.SetBits(message.Data1, message.Data2);

            OnPitchBendChange.Invoke(message);
        }
    }
}