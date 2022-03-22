using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule // OnChannelModeMessage
    {
        public Action<MidiMessage> OnAllSoundOff = (m) => { };
        public Action<MidiMessage> OnResetAllControllers = (m) => { };
        public Action<MidiMessage> OnLocalControl = (m) => { };
        public Action<MidiMessage> OnAllNotesOff = (m) => { };
        public Action<MidiMessage> OnOmniModeOff = (m) => { };
        public Action<MidiMessage> OnOmniModeOn = (m) => { };
        public Action<MidiMessage> OnMonoModeOn = (m) => { };
        public Action<MidiMessage> OnPolyModeOn = (m) => { };
        

        private void onAllSoundOff(MidiMessage message)
        {
            allNotesOff();
            OnAllSoundOff.Invoke(message);
        }
        private void onResetAllControllers(MidiMessage message)
        {
            allNotesOff();

            // ChannelState
            for(int i = 0; i < ChannelState.Length; i++)
            {
                ChannelState[i].ResetAll();
            }

            OnResetAllControllers.Invoke(message);
        }
        private void onLocalControl(MidiMessage message)
        {
            if (message.Data2 == 0x00)
                ChannelMode.LocalControl = false;
            else if (message.Data2 == 0x7F)
                ChannelMode.LocalControl = true;

            OnLocalControl.Invoke(message);
        }
        private void onAllNotesOff(MidiMessage message)
        {
            allNotesOff();
            OnAllNotesOff.Invoke(message);
        }
        private void onOmniModeOff(MidiMessage message)
        {
            ChannelMode.OmniOn = false;
            OnOmniModeOff.Invoke(message);
        }
        private void onOmniModeOn(MidiMessage message)
        {
            ChannelMode.OmniOn = true;
            OnOmniModeOn.Invoke(message);
        }
        private void onMonoModeOn(MidiMessage message)
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

            OnMonoModeOn.Invoke(message);
        }
        private void onPolyModeOn(MidiMessage message)
        {
            ChannelMode.MonoModeOn = false;
            OnPolyModeOn.Invoke(message);
        }
        
        private void allNotesOff()
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
    }
}
