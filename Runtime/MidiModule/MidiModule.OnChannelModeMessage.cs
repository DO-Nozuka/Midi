using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule // OnChannelModeMessage
    {
        public virtual void OnAllSoundOff(MidiMessage message)
        {
            OnAllNotesOff(message);
        }
        public virtual void OnResetAllControllers(MidiMessage message)
        {
            OnAllNotesOff(message);
            // ChannelState
            for(int i = 0; i < ChannelState.Length; i++)
            {
                ChannelState[i].ResetAll();
            }
        }
        public virtual void OnLocalControl(MidiMessage message)
        {
            if (message.Data2 == 0x00)
            ChannelMode.LocalControl = false;
            else if (message.Data2 == 0x7F)
            ChannelMode.LocalControl = true;
        }
        public virtual void OnAllNotesOff(MidiMessage message)
        {
            for (int channel = 0; channel < 16; channel++)
            {
                for (int note = 0; note < 128; note++)
                {
                    ChannelState[channel].Note.IsOn[note] = false;
                    ChannelState[channel].Note.OnVelocity[note].SetValue(0);
                    ChannelState[channel].Note.OffVelocity[note].SetValue(100);
                    ChannelState[channel].Note.Pressure[note].SetValue(0);
                }
            }
        }
        public virtual void OnOmniModeOff(MidiMessage message)
        {
            ChannelMode.OmniOn = false;
        }
        public virtual void OnOmniModeOn(MidiMessage message)
        {
            ChannelMode.OmniOn = true;
        }
        public virtual void OnMonoModeOn(MidiMessage message)
        {
            ChannelMode.MonoModeOn = true;
            ChannelMode.MonoChMin = message.Channel;
            if (message.Data2 == 0)
                ChannelMode.MonoChMax = 15;
            else
            {
                ChannelMode.MonoChMax = (byte)(ChannelMode.MonoChMin + message.Data2);
                if (ChannelMode.MonoChMax > 15)
                    ChannelMode.MonoChMax = 15;
            }
        }
        public virtual void OnPolyModeOn(MidiMessage message)
        {
            ChannelMode.MonoModeOn = false;
        }
    }
}
