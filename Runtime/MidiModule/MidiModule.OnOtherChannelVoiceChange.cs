using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule // OnOtherChannelVoiceChange
    {
        public virtual void OnProgramChange(MidiMessage message)
        {
            ChannelState[message.Channel].Program.SetBits(message.Data1);
        }
        public virtual void OnChannelPressure(MidiMessage message)
        {
            ChannelState[message.Channel].ChannelPressure.SetBits(message.Data1);
        }
        public virtual void OnPitchBendChange(MidiMessage message)
        {
            ChannelState[message.Channel].PitchBend.SetBits(message.Data1, message.Data2);
        }
    }
}
