namespace Dono.Midi
{
    public class ChannelModeState
    {
        //public bool AllSoundOffFlag { get; protected set; } = false; // 0xBn 0x78 0x00
        //public bool ResetAllControlFlag { get; protected set; } = false; // 0xBn 0x79 0x00
        public bool LocalControl { get; internal set; } = true; // Off: 0xBn 0x7A 0x00, On: 0xBn 0x7A 0x7F
        //public bool AllNoteOffFlag { get; protected set; } = false; // 0xBn 0x7B 0x00
        /**** Mono/Poly, Omni On/Off ****/
        //public bool OmniOff => !OmniOn; // 0xBn 0x7C 0x00
        public bool OmniOn { get; internal set; } = false; // 0xBn 0x7D 0x00
        public bool MonoModeOn { get; internal set; } = false;
        public bool PolyModeOn => !MonoModeOn;
        public bool BasicChannel { get; internal set; }
        public bool M { get; internal set; }
        public byte MonoChMin { get; internal set; } = 0;
        public byte MonoChMax { get; internal set; } = 15;
    }
}