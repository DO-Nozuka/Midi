using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{
    public partial class MidiModule
    {
        public ChannelState[] ChannelState { get; internal set; } = new ChannelState[16];

        // ## Channel Mode Message (0xBn: 120-127)
        public ChannelModeState ChannelMode { get; internal set; } = new ChannelModeState();

        public MidiModule()
        {
            for (int i = 0; i < 16; i++)
            {
                ChannelState[i] = new ChannelState();
            }

        }
    }
}
