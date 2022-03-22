using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule // OnOtherChannelVoiceChange
    {
        public Action<MidiMessage> OnProgramChange { get; private set; } = (m) => { };
        public Action<MidiMessage> OnChannelPressure { get; private set; } = (m) => { };
        public Action<MidiMessage> OnPitchBendChange { get; private set; } = (m) => { };

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