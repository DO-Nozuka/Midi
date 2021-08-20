namespace Dono.Midi.Runtime.Types
{
    public interface IOnMetaEventType
    {
        void OnSequenceNumber(MidiMessage message);
        void OnTextEvent(MidiMessage message);
        void OnCopyrightNotice(MidiMessage message);
        void OnSequenceAndTrackName(MidiMessage message);
        void OnInstrumentName(MidiMessage message);
        void OnLyric(MidiMessage message);
        void OnMarker(MidiMessage message);
        void OnCuePoint(MidiMessage message);
        void OnChannelPrefix(MidiMessage message);
        void OnPortPrefix(MidiMessage message);
        void OnEndOfTrack(MidiMessage message);
        void OnSetTempo(MidiMessage message);
        void OnSMPTEOffset(MidiMessage message);
        void OnTimeSignature(MidiMessage message);
        void OnKeySignature(MidiMessage message);
        void OnSequencerSpecificMetaEvent(MidiMessage message);
    }

}