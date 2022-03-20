namespace Dono.Midi
{
    public class Midi1ByteControlChangeState
    {
        #region ## 1byte CC (0xBn: 64-119)
        public Midi1ByteValue Hold { get; internal set; }
        public Midi1ByteValue Portamento { get; internal set; }
        public Midi1ByteValue Sostenuto { get; internal set; }
        public Midi1ByteValue SoftPedal { get; internal set; }
        public Midi1ByteValue LegatoFootswitch { get; internal set; }
        public Midi1ByteValue Hold2 { get; internal set; }
        public Midi1ByteValue SoundController1 { get; internal set; }
        public Midi1ByteValue SoundController2 { get; internal set; }
        public Midi1ByteValue SoundController3 { get; internal set; }
        public Midi1ByteValue SoundController4 { get; internal set; }
        public Midi1ByteValue SoundController5 { get; internal set; }
        public Midi1ByteValue SoundController6 { get; internal set; }
        public Midi1ByteValue SoundController7 { get; internal set; }
        public Midi1ByteValue SoundController8 { get; internal set; }
        public Midi1ByteValue SoundController9 { get; internal set; }
        public Midi1ByteValue SoundController10 { get; internal set; }
        public Midi1ByteValue GeneralPurposeController5 { get; internal set; }
        public Midi1ByteValue GeneralPurposeController6 { get; internal set; }
        public Midi1ByteValue GeneralPurposeController7 { get; internal set; }
        public Midi1ByteValue GeneralPurposeController8 { get; internal set; }
        public Midi1ByteValue PortamentoControl { get; internal set; }
        public Midi1ByteValue Undefined55 { get; internal set; }
        public Midi1ByteValue Undefined56 { get; internal set; }
        public Midi1ByteValue Undefined57 { get; internal set; }
        public Midi1ByteValue Undefined58 { get; internal set; }
        public Midi1ByteValue Undefined59 { get; internal set; }
        public Midi1ByteValue Undefined5A { get; internal set; }
        public Midi1ByteValue Effects1Depth { get; internal set; }
        public Midi1ByteValue Effects2Depth { get; internal set; }
        public Midi1ByteValue Effects3Depth { get; internal set; }
        public Midi1ByteValue Effects4Depth { get; internal set; }
        public Midi1ByteValue Effects5Depth { get; internal set; }
        //public Midi1ByteValue DataIncrement { get; internal set; }
        //public Midi1ByteValue DataDecrement { get; internal set; }
        public Midi1ByteValue NonRegisteredParameterNumberLSB { get; internal set; }
        public Midi1ByteValue NonRegisteredParameterNumberMSB { get; internal set; }
        public Midi1ByteValue RegisteredParameterNumberLSB { get; internal set; }
        public Midi1ByteValue RegisteredParameterNumberMSB { get; internal set; }
        public Midi1ByteValue Undefined66 { get; internal set; }
        public Midi1ByteValue Undefined67 { get; internal set; }
        public Midi1ByteValue Undefined68 { get; internal set; }
        public Midi1ByteValue Undefined69 { get; internal set; }
        public Midi1ByteValue Undefined6A { get; internal set; }
        public Midi1ByteValue Undefined6B { get; internal set; }
        public Midi1ByteValue Undefined6C { get; internal set; }
        public Midi1ByteValue Undefined6D { get; internal set; }
        public Midi1ByteValue Undefined6E { get; internal set; }
        public Midi1ByteValue Undefined6F { get; internal set; }
        public Midi1ByteValue Undefined70 { get; internal set; }
        public Midi1ByteValue Undefined71 { get; internal set; }
        public Midi1ByteValue Undefined72 { get; internal set; }
        public Midi1ByteValue Undefined73 { get; internal set; }
        public Midi1ByteValue Undefined74 { get; internal set; }
        public Midi1ByteValue Undefined75 { get; internal set; }
        public Midi1ByteValue Undefined76 { get; internal set; }
        public Midi1ByteValue Undefined77 { get; internal set; }
        #endregion
        public Midi1ByteControlChangeState()
        {
            #region ## 1byte CC (0xBn: 64-119)
            Hold = new Midi1ByteValue(false);
            Portamento = new Midi1ByteValue(false);
            Sostenuto = new Midi1ByteValue(false);
            SoftPedal = new Midi1ByteValue(false);
            LegatoFootswitch = new Midi1ByteValue(false);
            Hold2 = new Midi1ByteValue(false);
            SoundController1 = new Midi1ByteValue(false);
            SoundController2 = new Midi1ByteValue(false);
            SoundController3 = new Midi1ByteValue(false);
            SoundController4 = new Midi1ByteValue(false);
            SoundController5 = new Midi1ByteValue(false);
            SoundController6 = new Midi1ByteValue(false);
            SoundController7 = new Midi1ByteValue(false);
            SoundController8 = new Midi1ByteValue(false);
            SoundController9 = new Midi1ByteValue(false);
            SoundController10 = new Midi1ByteValue(false);
            GeneralPurposeController5 = new Midi1ByteValue(false);
            GeneralPurposeController6 = new Midi1ByteValue(false);
            GeneralPurposeController7 = new Midi1ByteValue(false);
            GeneralPurposeController8 = new Midi1ByteValue(false);
            PortamentoControl = new Midi1ByteValue(false);
            Undefined55 = new Midi1ByteValue(false);
            Undefined56 = new Midi1ByteValue(false);
            Undefined57 = new Midi1ByteValue(false);
            Undefined58 = new Midi1ByteValue(false);
            Undefined59 = new Midi1ByteValue(false);
            Undefined5A = new Midi1ByteValue(false);
            Effects1Depth = new Midi1ByteValue(false);
            Effects2Depth = new Midi1ByteValue(false);
            Effects3Depth = new Midi1ByteValue(false);
            Effects4Depth = new Midi1ByteValue(false);
            Effects5Depth = new Midi1ByteValue(false);
            // DataIncrement = new Midi1ByteValue(false);
            // DataDecrement = new Midi1ByteValue(false);
            NonRegisteredParameterNumberLSB = new Midi1ByteValue(false);
            NonRegisteredParameterNumberMSB = new Midi1ByteValue(false);
            RegisteredParameterNumberLSB = new Midi1ByteValue(false);
            RegisteredParameterNumberMSB = new Midi1ByteValue(false);
            Undefined66 = new Midi1ByteValue(false);
            Undefined67 = new Midi1ByteValue(false);
            Undefined68 = new Midi1ByteValue(false);
            Undefined69 = new Midi1ByteValue(false);
            Undefined6A = new Midi1ByteValue(false);
            Undefined6B = new Midi1ByteValue(false);
            Undefined6C = new Midi1ByteValue(false);
            Undefined6D = new Midi1ByteValue(false);
            Undefined6E = new Midi1ByteValue(false);
            Undefined6F = new Midi1ByteValue(false);
            Undefined70 = new Midi1ByteValue(false);
            Undefined71 = new Midi1ByteValue(false);
            Undefined72 = new Midi1ByteValue(false);
            Undefined73 = new Midi1ByteValue(false);
            Undefined74 = new Midi1ByteValue(false);
            Undefined75 = new Midi1ByteValue(false);
            Undefined76 = new Midi1ByteValue(false);
            Undefined77 = new Midi1ByteValue(false);
            #endregion

        }
    }
}