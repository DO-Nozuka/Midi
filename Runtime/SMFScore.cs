using System.Collections.Generic;

namespace Dono.Midi.Runtime
{
    public class SMFScore
    {
        public SMFTrack ConductorTrack { get; private set; }
        public SMFTrack ScoreSetupTrack { get; private set; }
        public List<SMFTrack> PartTracks { get; private set; } = new List<SMFTrack>();

        public int Port { get; internal set; } = int.MinValue;

        public void AddTrack(SMFTrack track)
        {
            if (Port == int.MinValue)
                Port = track.Port;
            if (Port != track.Port)
                return;


            if (track.TrackType == SMFTrackType.ScoreSetup)
                ScoreSetupTrack = track;
            else
                PartTracks.Add(track);
        }

        public SMFScore(SMFTrack conductorTrack)
        {
            ConductorTrack = conductorTrack;
        }
    }
}