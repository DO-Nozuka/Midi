namespace Dono.Midi
{
    public class SMFBeat
    {
        /// <summary>
        /// Numerator: 分子
        /// </summary>
        public int Nu { get; private set; }
        /// <summary>
        /// Denominator: 分母
        /// </summary>
        public int De { get; private set; }

        public SMFBeat(int nu, int de)
        {
            this.Nu = nu;
            this.De = de;
        }
    }
}