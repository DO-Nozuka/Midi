namespace Dono.Midi.Types
{
    // 0xFs s=1-7
    public enum SystemCommonType
    {
        None = 0x00,
        MidiTimeCode = 0xF1,
        SongPosition = 0xF2,
        SongSelect = 0xF3,
        UndefinedF4 = 0xF4,
        UndefinedF5 = 0xF5,
        TuneRequest = 0xF6,
        EOX = 0xF7
    }
}
