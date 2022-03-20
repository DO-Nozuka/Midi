namespace Dono.Midi
{
    public class Midi2ByteControlChangeState
    {
        #region ## 2byte CC (0xBn: 0-63)
        public Midi2ByteValue BankSelect { get; internal set; }
        public Midi2ByteValue Modulation { get; internal set; }
        public Midi2ByteValue BreathController { get; internal set; }
        public Midi2ByteValue Undefined03 { get; internal set; }
        public Midi2ByteValue FootController { get; internal set; }
        public Midi2ByteValue PortamentoTime { get; internal set; }
        // public Midi2ByteValue DataEntry { get; internal set; }
        public Midi2ByteValue ChannelVolume { get; internal set; }
        public Midi2ByteValue Balance { get; internal set; }
        public Midi2ByteValue Undefined09 { get; internal set; }
        public Midi2ByteValue Pan { get; internal set; }
        public Midi2ByteValue ExpressionController { get; internal set; }
        public Midi2ByteValue EffectControl1 { get; internal set; }
        public Midi2ByteValue EffectControl2 { get; internal set; }
        public Midi2ByteValue Undefined0E { get; internal set; }
        public Midi2ByteValue Undefined0F { get; internal set; }
        public Midi2ByteValue GeneralPurposeController1 { get; internal set; }
        public Midi2ByteValue GeneralPurposeController2 { get; internal set; }
        public Midi2ByteValue GeneralPurposeController3 { get; internal set; }
        public Midi2ByteValue GeneralPurposeController4 { get; internal set; }
        public Midi2ByteValue Undefined14 { get; internal set; }
        public Midi2ByteValue Undefined15 { get; internal set; }
        public Midi2ByteValue Undefined16 { get; internal set; }
        public Midi2ByteValue Undefined17 { get; internal set; }
        public Midi2ByteValue Undefined18 { get; internal set; }
        public Midi2ByteValue Undefined19 { get; internal set; }
        public Midi2ByteValue Undefined1A { get; internal set; }
        public Midi2ByteValue Undefined1B { get; internal set; }
        public Midi2ByteValue Undefined1C { get; internal set; }
        public Midi2ByteValue Undefined1D { get; internal set; }
        public Midi2ByteValue Undefined1E { get; internal set; }
        public Midi2ByteValue Undefined1F { get; internal set; }
        #endregion
        public Midi2ByteControlChangeState()
        {
            #region ## 2byte CC (0xBn: 0-63)
            BankSelect = new Midi2ByteValue(false);
            Modulation = new Midi2ByteValue(false);
            BreathController = new Midi2ByteValue(false);
            Undefined03 = new Midi2ByteValue(false);
            FootController = new Midi2ByteValue(false);
            PortamentoTime = new Midi2ByteValue(false);
            // DataEntry = new Midi2ByteValue(false);
            ChannelVolume = new Midi2ByteValue(false);
            Balance = new Midi2ByteValue(true);
            Undefined09 = new Midi2ByteValue(false);
            Pan = new Midi2ByteValue(true);
            ExpressionController = new Midi2ByteValue(false);
            EffectControl1 = new Midi2ByteValue(false);
            EffectControl2 = new Midi2ByteValue(false);
            Undefined0E = new Midi2ByteValue(false);
            Undefined0F = new Midi2ByteValue(false);
            GeneralPurposeController1 = new Midi2ByteValue(false);
            GeneralPurposeController2 = new Midi2ByteValue(false);
            GeneralPurposeController3 = new Midi2ByteValue(false);
            GeneralPurposeController4 = new Midi2ByteValue(false);
            Undefined14 = new Midi2ByteValue(false);
            Undefined15 = new Midi2ByteValue(false);
            Undefined16 = new Midi2ByteValue(false);
            Undefined17 = new Midi2ByteValue(false);
            Undefined18 = new Midi2ByteValue(false);
            Undefined19 = new Midi2ByteValue(false);
            Undefined1A = new Midi2ByteValue(false);
            Undefined1B = new Midi2ByteValue(false);
            Undefined1C = new Midi2ByteValue(false);
            Undefined1D = new Midi2ByteValue(false);
            Undefined1E = new Midi2ByteValue(false);
            Undefined1F = new Midi2ByteValue(false);
            #endregion

        }
    }
}