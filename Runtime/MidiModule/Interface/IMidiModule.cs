namespace Dono.Midi
{
    public interface IMidiModule:
        IOnMessageType,
        IOnChannelVoiceType,
        IOnChannelModeType,
        IOnSystemCommonType,
        IOnSystemRealTimeType,
        IOnMetaEventType,
        IOnControlChangeType
    {
    }
}