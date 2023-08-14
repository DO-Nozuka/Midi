namespace Dono.Midi
{
    public class SMFTempo
    {
        public double Bpm { get; private set; }
        public SMFBeat Beat { get; private set; }
        public SMFTempo(double bpm, int beatNu, int beatDe)
        {
            Bpm = bpm;
            Beat = new SMFBeat(beatNu, beatDe);
        }
    }
}