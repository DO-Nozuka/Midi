namespace Dono.Midi
{
    /// <summary>
    /// ## 0x8n: NoteOff<br/>
    /// ## 0x9n: NoteOn<br/>
    /// ## 0xAn: PolyphonicKeyPressure
    /// </summary>
    public class NoteState
    {
        public bool[] IsOn { get; protected set; }
        /// <summary>
        /// IsNoteOn == true : 1 - 127
        /// IsNoteOn == false: 0
        /// </summary>
        public Midi1ByteValue[] OnVelocity { get; protected set; }
        /// <summary>
        /// IsNoteOn == true : 0
        /// IsNoteOn == false: 1 - 127
        /// </summary>
        public Midi1ByteValue[] OffVelocity { get; protected set; }
        /// <summary>
        /// 0xAn: Key Pressure
        /// </summary>
        public Midi1ByteValue[] Pressure { get; internal set; }

        public NoteState()
        {
            IsOn = new bool[128];
            OnVelocity = new Midi1ByteValue[128];
            OffVelocity = new Midi1ByteValue[128];
            Pressure = new Midi1ByteValue[128];
            for (int i = 0; i < 128; i++)
            {
                IsOn[i] = false;
                OnVelocity[i] = new Midi1ByteValue(false, (int)0);
                OffVelocity[i] = new Midi1ByteValue(false, (int)100);
                Pressure[i] = new Midi1ByteValue(false, (int)0);
            }
        }
    }
}