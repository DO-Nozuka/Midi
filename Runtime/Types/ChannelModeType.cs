namespace Dono.Midi.Types
{
    // 0xBn n = 120-127
    public enum ChannelModeType
    {
        None = 0x00,
        AllSoundOff = 0x78,
        ResetAllControllers = 0x79,
        LocalControl = 0x7A,
        AllNotesOff = 0x7B,
        OmniModeOff = 0x7C,
        OmniModeOn = 0x7D,
        MonoModeOn = 0x7E,
        PolyModeOn = 0x7F
    }
}
