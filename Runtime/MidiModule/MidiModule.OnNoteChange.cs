using System;

namespace Dono.Midi
{
    public partial class MidiModule // OnNoteChange
    {
        public Action<MidiMessage> OnNoteOff = (m) => { };
        public Action<MidiMessage> OnNoteOn = (m) => { };
        public Action<MidiMessage> OnPolyphonicKeyPressure = (m) => { };

        /// <summary>
        /// NoteOn / NoteOff
        /// </summary>
        public Action<MidiMessage> OnNoteOnOff = (m) => { };
        /// <summary>
        /// NoteOn / NoteOff / PolyphonicKeyPressure
        /// </summary>
        public Action<MidiMessage> OnAnyNote = (m) => { };


        private void onNoteOff(MidiMessage message)
        {
            ChannelState[message.Channel].Note.IsOn[message.Data1] = true;
            ChannelState[message.Channel].Note.OnVelocity[message.Data1].SetBits(0);
            ChannelState[message.Channel].Note.OffVelocity[message.Data1].SetBits(message.Data2);

            OnNoteOff.Invoke(message);
            OnNoteOnOff.Invoke(message);
            OnAnyNote.Invoke(message);
        }
        private void onNoteOn(MidiMessage message)
        {
            ChannelState[message.Channel].Note.IsOn[message.Data1] = false;
            ChannelState[message.Channel].Note.OnVelocity[message.Data1].SetBits(message.Data2);
            ChannelState[message.Channel].Note.OffVelocity[message.Data1].SetBits(0);

            OnNoteOn.Invoke(message);
            OnNoteOnOff.Invoke(message);
            OnAnyNote.Invoke(message);
        }
        private void onPolyphonicKeyPressure(MidiMessage message)
        {
            ChannelState[message.Channel].Note.Pressure[message.Data1].SetBits(message.Data2);

            OnPolyphonicKeyPressure.Invoke(message);
            OnNoteOnOff.Invoke(message);
            OnAnyNote.Invoke(message);
        }

    }
}
