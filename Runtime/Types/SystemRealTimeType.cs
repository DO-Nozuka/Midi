namespace Dono.MidiUtilities.Runtime.Types
{
    enum SystemRealTimeType
    {
        None  0x00,
        TimingClock = 0xF8,
        UndefinedF9 = 0xF9,
        Start = 0xFA,
        Continue = 0xFB,
        Stop = 0xFC,
        UndefinedFD = 0xFD,
        ActiveSensing = 0xFE,
        Reset = 0xFF
    }
}
