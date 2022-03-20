namespace Dono.Midi
{
    /// <summary>
    /// Midi音源モジュール共通の情報
    /// </summary>
    public class ChannelState
    {
        // ## 0x8n: NoteOff
        // ## 0x9n: NoteOn
        // ## 0xAn: PolyphonicKeyPressure
        public NoteState Note { get; internal set; }
        // ## Control Change(0xBn: 0-119)
        public Midi2ByteControlChangeState DoubleCC { get; internal set; }
        public Midi1ByteControlChangeState SingleCC { get; internal set; }
        public ParameterState Parameter { get; internal set; }
        /// <summary>
        /// ProgramChange (0xCn)
        /// </summary>
        public Midi1ByteValue Program { get; internal set; } = new Midi1ByteValue(false);
        public Midi1ByteValue ChannelPressure { get; internal set; } = new Midi1ByteValue(false);
        public Midi2ByteValue PitchBend { get; internal set; } = new Midi2ByteValue(true); // 0xEn 0xll 0xhh  0b00hh_hhhh_hlll_llll

        public void ResetAll()
        {
            // TODO: 再確保しない様にする
            Note = new NoteState();
            DoubleCC = new Midi2ByteControlChangeState();
            SingleCC = new Midi1ByteControlChangeState();
            Parameter = new ParameterState();
            Program = new Midi1ByteValue(false);
            ChannelPressure = new Midi1ByteValue(false);
            PitchBend = new Midi2ByteValue(true);
        }

        public ChannelState()
        {
            Note = new NoteState();
            DoubleCC = new Midi2ByteControlChangeState();
            SingleCC = new Midi1ByteControlChangeState();
            Parameter = new ParameterState();
            Program = new Midi1ByteValue(false);
            ChannelPressure = new Midi1ByteValue(false);
            PitchBend = new Midi2ByteValue(true);
        }
    }
}