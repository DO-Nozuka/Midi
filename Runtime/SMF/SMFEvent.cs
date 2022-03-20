namespace Dono.Midi
{
    public class SMFEvent
    {
        public SMFTiming Timing { get; private set; }
        public MidiMessage Message { get; private set; }

        public SMFEvent(SMFTiming timing, MidiMessage message)
        {
            Timing = timing;
            Message = message;
        }
    }
}