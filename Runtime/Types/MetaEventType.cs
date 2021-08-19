namespace Dono.MidiUtilities.Runtime.Types
{
    // FF tt len
    // tt = 0-127
    // len = 0-
    public enum MetaEventType
    {
        None = 0xFF,
        SequenceNumber = 0x00,
        TextEvent = 0x01,
        CopyrightNotice = 0x02,
        SequenceAndTrackName = 0x03,
        InstrumentName = 0x04,
        Lyric = 0x05,
        Marker = 0x06,
        CuePoint = 0x07,
        ChannelPrefix = 0x20,
        PortPrefix = 0x21,
        EndOfTrack = 0x2F,
        SetTempo = 0x51,
        SMPTEOffset = 0x54,
        TimeSignature = 0x58,
        KeySignature = 0x59,
        SequencerSpecificMetaEvent = 0x7F
    }
}
