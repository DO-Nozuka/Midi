namespace Dono.Midi
{
    /// <summary>
    /// ピッチベンドセンシティビティは、RPN 00(MSB)00(LSB)で定義される。
    /// データエントリーのMSBは半音(100セント)単位で感度を表し、
    /// LSBは100/128セント単位で感度を表す。
    /// 例えばMSB=01, LSB=00は±1半音(計2半音)を表す。
    /// </summary>
    public class PitchBendSensitivity : Midi2ByteValue
    {
        public float Cent => Value / 128f * 100f;

        public PitchBendSensitivity(float rate) : base(true, rate)
        {
        }

        public PitchBendSensitivity(int value) : base(true, value)
        {
        }

        public PitchBendSensitivity(byte msb = 255, byte lsb = 255) : base(false, msb, lsb)
        {
        }
    }

    public class FineTune : Midi2ByteValue
    {
        public float Cent => (100f / 8192f) * Value;

        public FineTune(float rate) : base(true, rate)
        {
        }

        public FineTune(int value) : base(true, value)
        {
        }

        public FineTune(byte msb = 255, byte lsb = 255) : base(true, msb, lsb)
        {
        }
    }

    public class CoarseTune : Midi1ByteValue
    {
        public float Cent => 100f * Value;
        public CoarseTune(byte msb = 255) : base(true, msb)
        {
        }

        public CoarseTune(float rate) : base(true, rate)
        {
        }

        public CoarseTune(int value) : base(true, value)
        {
        }
    }

    public class MasterTuning
    {
        public FineTune FineTune;
        public CoarseTune CoarseTune;

        public MasterTuning()
        {
            FineTune = new FineTune();
            CoarseTune = new CoarseTune();
        }
    }
}