namespace Dono.Midi.Runtime.Types
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