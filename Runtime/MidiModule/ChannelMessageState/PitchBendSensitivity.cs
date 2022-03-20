namespace Dono.Midi
{
    public class PitchBendSensitivity : Midi2ByteValue
    {
        public float Cent => Value / 128f;

        public PitchBendSensitivity(float rate) : base(true, rate)
        {
        }

        public PitchBendSensitivity(int value) : base(true, value)
        {
        }

        public PitchBendSensitivity(byte msb = 255, byte lsb = 255) : base(true, msb, lsb)
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