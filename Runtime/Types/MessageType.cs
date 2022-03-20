namespace Dono.Midi.Types
{

    public enum MessageType : byte
    {
        /// <summary>
        /// ŠY“–‚È‚µ
        /// </summary>
        None,
        /// <summary>
        /// 0x8n-0xEn 0xCC 0xVV (without CC = 0x78-0x7F)
        /// </summary>
        ChannelVoice,
        /// <summary>
        /// 0xBn 0xCC 0xVV (CC = 0x78-0x7F)
        /// </summary>
        ChannelMode,
        /// <summary>
        /// 0xF0
        /// </summary>
        SystemExclusive,
        /// <summary>
        /// 0xFs(s = 1-7)
        /// </summary>
        SystemCommon,
        /// <summary>
        /// 0xFt(t = 8-15) DataLength = 0
        /// </summary>
        SystemRealtime,
        /// <summary>
        /// 0xFF DataLength != 0, for SMF
        /// </summary>
        MetaEvent
    }
}
