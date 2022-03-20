using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{
    public partial class MidiModule // OnNoteChange
    {
        public virtual void OnNoteOff(MidiMessage message)
        {
            ChannelState[message.Channel].Note.IsOn[message.Data1] = true;
            ChannelState[message.Channel].Note.OnVelocity[message.Data1].SetBits(0);
            ChannelState[message.Channel].Note.OffVelocity[message.Data1].SetBits(message.Data2);
        }
        public virtual void OnNoteOn(MidiMessage message)
        {
            ChannelState[message.Channel].Note.IsOn[message.Data1] = false;
            ChannelState[message.Channel].Note.OnVelocity[message.Data1].SetBits(message.Data2);
            ChannelState[message.Channel].Note.OffVelocity[message.Data1].SetBits(0);
        }
        public virtual void OnPolyphonicKeyPressure(MidiMessage message)
        {
            ChannelState[message.Channel].Note.Pressure[message.Data1].SetBits(message.Data2);
        }

    }
}
