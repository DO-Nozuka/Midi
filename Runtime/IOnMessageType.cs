namespace Dono.Midi.Runtime.Types
{
    public interface IOnMessageType
    {
        /// <summary>
        /// 0x8n-0xEn 0xCC 0xVV (without CC = 0x78-0x7F)
        /// </summary>
        void ChannelVoiceSplitter(MidiMessage message);
        /// <summary>
        /// 0xBn 0xCC 0xVV (CC = 0x78-0x7F)
        /// </summary>
        void ChannelModeSplitter(MidiMessage message);
        /// <summary>
        /// 0xF0
        /// </summary>
        void SystemExclusiveSplitter(MidiMessage message);
        /// <summary>
        /// 0xFs(s = 1-7)
        /// </summary>
        void SystemCommonSplitter(MidiMessage message);
        /// <summary>
        /// 0xFt(t = 8-15) DataLength = 0
        /// </summary>
        void SystemRealtimeSplitter(MidiMessage message);
        /// <summary>
        /// 0xFF DataLength != 0, for SMF
        /// </summary>
        void MetaEventSplitter(MidiMessage message);
    }

}