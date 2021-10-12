using System.Collections.Generic;

namespace Dono.Midi.Runtime
{
    public class SMFScore
    {
        public SMFTrack ScoreSetupTrack;
        public List<SMFTrack> PartTracks = new List<SMFTrack>();

        public int PortNum { get; internal set; }
    }
}