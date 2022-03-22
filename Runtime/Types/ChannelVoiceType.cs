namespace Dono.Midi
{
    public enum ChannelVoiceType : byte
    {
        /// <summary>
        /// 該当なし
        /// </summary>
        None = 0x00,
        /// <summary>
        /// 0x8n 0xkk 0xvv
        /// kk: Note Number
        /// vv: Velocity
        /// </summary>
        NoteOff = 0x80,
        NoteOn = 0x90,
        PolyphonicKeyPressure = 0xA0,
        ControlChange = 0xB0,
        ProgramChange = 0xC0,
        ChannelPressure = 0xD0,
        PitchBendChange = 0xE0
    }
}
