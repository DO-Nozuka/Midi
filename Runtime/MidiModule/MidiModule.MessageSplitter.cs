using System;

namespace Dono.Midi
{

    public partial class MidiModule // MessageSplitter
    {
        public Action<MidiMessage> OnAny = (m) => { };
        public Action<MidiMessage> OnChannelVoice = (m) => { };
        public Action<MidiMessage> OnChannelMode = (m) => { };
        public Action<MidiMessage> OnSystemExclusive = (m) => { };
        public Action<MidiMessage> OnSystemCommon = (m) => { };
        public Action<MidiMessage> OnSystemRealtime = (m) => { };
        public Action<MidiMessage> OnMetaEvent = (m) => { };
        public Action<MidiMessage> OnControlChange = (m) => { };


        private void AnyMessageSplitter(MidiMessage message)
        {
            switch (message.messageType)
            {
                case MessageType.ChannelVoice:
                    channelVoiceSplitter(message);
                    break;
                case MessageType.ChannelMode:
                    channelModeSplitter(message);
                    break;
                case MessageType.SystemExclusive:
                    systemExclusiveSplitter(message);
                    break;
                case MessageType.SystemCommon:
                    systemCommonSplitter(message);
                    break;
                case MessageType.SystemRealtime:
                    systemRealtimeSplitter(message);
                    break;
                case MessageType.MetaEvent:
                    metaEventSplitter(message);
                    break;
            }
            OnAny.Invoke(message);
        }
        private void channelVoiceSplitter(MidiMessage message)
        {
            switch (message.channelVoiceType)
            {
                case ChannelVoiceType.NoteOff:
                    onNoteOff(message);
                    break;
                case ChannelVoiceType.NoteOn:
                    onNoteOn(message);
                    break;
                case ChannelVoiceType.PolyphonicKeyPressure:
                    onPolyphonicKeyPressure(message);
                    break;
                case ChannelVoiceType.ControlChange:
                    controlChangeSplitter(message);
                    break;
                case ChannelVoiceType.ProgramChange:
                    onProgramChange(message);
                    break;
                case ChannelVoiceType.ChannelPressure:
                    onChannelPressure(message);
                    break;
                case ChannelVoiceType.PitchBendChange:
                    onPitchBendChange(message);
                    break;
            }
            OnChannelVoice.Invoke(message);
        }
        private void channelModeSplitter(MidiMessage message)
        {
            switch (message.channelModeType)
            {
                case ChannelModeType.AllSoundOff:
                    onAllSoundOff(message);
                    break;
                case ChannelModeType.ResetAllControllers:
                    onResetAllControllers(message);
                    break;
                case ChannelModeType.LocalControl:
                    onLocalControl(message);
                    break;
                case ChannelModeType.AllNotesOff:
                    onAllNotesOff(message);
                    break;
                case ChannelModeType.OmniModeOff:
                    onOmniModeOff(message);
                    break;
                case ChannelModeType.OmniModeOn:
                    onOmniModeOn(message);
                    break;
                case ChannelModeType.MonoModeOn:
                    onMonoModeOn(message);
                    break;
                case ChannelModeType.PolyModeOn:
                    onPolyModeOn(message);
                    break;
            }
            OnChannelMode.Invoke(message);
        }
        private void systemExclusiveSplitter(MidiMessage message)
        {
            OnSystemExclusive.Invoke(message);
        }
        private void systemCommonSplitter(MidiMessage message)
        {
            switch (message.systemCommonType)
            {
                case SystemCommonType.MidiTimeCode:
                    OnMidiTimeCode(message);
                    break;
                case SystemCommonType.SongPosition:
                    OnSongPosition(message);
                    break;
                case SystemCommonType.SongSelect:
                    OnSongSelect(message);
                    break;
                case SystemCommonType.UndefinedF4:
                    OnUndefinedF4(message);
                    break;
                case SystemCommonType.UndefinedF5:
                    OnUndefinedF5(message);
                    break;
                case SystemCommonType.TuneRequest:
                    OnTuneRequest(message);
                    break;
                case SystemCommonType.EOX:
                    OnEOX(message);
                    break;
            }
            OnSystemCommon.Invoke(message);
        }
        private void systemRealtimeSplitter(MidiMessage message)
        {
            switch (message.systemRealtimeType)
            {
                case SystemRealTimeType.TimingClock:
                    OnTimingClock(message);
                    break;
                case SystemRealTimeType.UndefinedF9:
                    OnUndefinedF9(message);
                    break;
                case SystemRealTimeType.Start:
                    OnStart(message);
                    break;
                case SystemRealTimeType.Continue:
                    OnContinue(message);
                    break;
                case SystemRealTimeType.Stop:
                    OnStop(message);
                    break;
                case SystemRealTimeType.UndefinedFD:
                    OnUndefinedFD(message);
                    break;
                case SystemRealTimeType.ActiveSensing:
                    OnActiveSensing(message);
                    break;
                case SystemRealTimeType.Reset:
                    OnReset(message);
                    break;
            }
            OnSystemRealtime.Invoke(message);
        }
        private void metaEventSplitter(MidiMessage message)
        {
            switch (message.metaEventType)
            {
                case MetaEventType.SequenceNumber:
                    OnSequenceNumber(message);
                    break;
                case MetaEventType.TextEvent:
                    OnTextEvent(message);
                    break;
                case MetaEventType.CopyrightNotice:
                    OnCopyrightNotice(message);
                    break;
                case MetaEventType.SequenceAndTrackName:
                    OnSequenceAndTrackName(message);
                    break;
                case MetaEventType.InstrumentName:
                    OnInstrumentName(message);
                    break;
                case MetaEventType.Lyric:
                    OnLyric(message);
                    break;
                case MetaEventType.Marker:
                    OnMarker(message);
                    break;
                case MetaEventType.CuePoint:
                    OnCuePoint(message);
                    break;
                case MetaEventType.ChannelPrefix:
                    OnChannelPrefix(message);
                    break;
                case MetaEventType.PortPrefix:
                    OnPortPrefix(message);
                    break;
                case MetaEventType.EndOfTrack:
                    OnEndOfTrack(message);
                    break;
                case MetaEventType.SetTempo:
                    OnSetTempo(message);
                    break;
                case MetaEventType.SMPTEOffset:
                    OnSMPTEOffset(message);
                    break;
                case MetaEventType.TimeSignature:
                    OnTimeSignature(message);
                    break;
                case MetaEventType.KeySignature:
                    OnKeySignature(message);
                    break;
                case MetaEventType.SequencerSpecificMetaEvent:
                    OnSequencerSpecificMetaEvent(message);
                    break;
            }
            OnMetaEvent.Invoke(message);
        }
        private void controlChangeSplitter(MidiMessage message)
        {
            switch (message.controlChangeType)
            {
                case ControlChangeType.BankSelectMSB:
                    onBankSelectMSB(message);
                    break;
                case ControlChangeType.ModulationMSB:
                    onModulationMSB(message);
                    break;
                case ControlChangeType.BreathControllerMSB:
                    onBreathControllerMSB(message);
                    break;
                case ControlChangeType.Undefined03MSB:
                    onUndefined03MSB(message);
                    break;
                case ControlChangeType.FootControllerMSB:
                    onFootControllerMSB(message);
                    break;
                case ControlChangeType.PortamentoTimeMSB:
                    onPortamentoTimeMSB(message);
                    break;
                case ControlChangeType.DataEntryMSB:
                    onDataEntryMSB(message);
                    break;
                case ControlChangeType.ChannelVolumeMSB:
                    onChannelVolumeMSB(message);
                    break;
                case ControlChangeType.BalanceMSB:
                    onBalanceMSB(message);
                    break;
                case ControlChangeType.Undefined09MSB:
                    onUndefined09MSB(message);
                    break;
                case ControlChangeType.PanMSB:
                    onPanMSB(message);
                    break;
                case ControlChangeType.ExpressionControllerMSB:
                    onExpressionControllerMSB(message);
                    break;
                case ControlChangeType.EffectControl1MSB:
                    onEffectControl1MSB(message);
                    break;
                case ControlChangeType.EffectControl2MSB:
                    onEffectControl2MSB(message);
                    break;
                case ControlChangeType.Undefined0EMSB:
                    onUndefined0EMSB(message);
                    break;
                case ControlChangeType.Undefined0FMSB:
                    onUndefined0FMSB(message);
                    break;
                case ControlChangeType.GeneralPurposeController1MSB:
                    onGeneralPurposeController1MSB(message);
                    break;
                case ControlChangeType.GeneralPurposeController2MSB:
                    onGeneralPurposeController2MSB(message);
                    break;
                case ControlChangeType.GeneralPurposeController3MSB:
                    onGeneralPurposeController3MSB(message);
                    break;
                case ControlChangeType.GeneralPurposeController4MSB:
                    onGeneralPurposeController4MSB(message);
                    break;
                case ControlChangeType.Undefined14MSB:
                    onUndefined14MSB(message);
                    break;
                case ControlChangeType.Undefined15MSB:
                    onUndefined15MSB(message);
                    break;
                case ControlChangeType.Undefined16MSB:
                    onUndefined16MSB(message);
                    break;
                case ControlChangeType.Undefined17MSB:
                    onUndefined17MSB(message);
                    break;
                case ControlChangeType.Undefined18MSB:
                    onUndefined18MSB(message);
                    break;
                case ControlChangeType.Undefined19MSB:
                    onUndefined19MSB(message);
                    break;
                case ControlChangeType.Undefined1AMSB:
                    onUndefined1AMSB(message);
                    break;
                case ControlChangeType.Undefined1BMSB:
                    onUndefined1BMSB(message);
                    break;
                case ControlChangeType.Undefined1CMSB:
                    onUndefined1CMSB(message);
                    break;
                case ControlChangeType.Undefined1DMSB:
                    onUndefined1DMSB(message);
                    break;
                case ControlChangeType.Undefined1EMSB:
                    onUndefined1EMSB(message);
                    break;
                case ControlChangeType.Undefined1FMSB:
                    onUndefined1FMSB(message);
                    break;
                case ControlChangeType.BankSelectLSB:
                    onBankSelectLSB(message);
                    break;
                case ControlChangeType.ModulationWheelLSB:
                    onModulationLSB(message);
                    break;
                case ControlChangeType.BreathControllerLSB:
                    onBreathControllerLSB(message);
                    break;
                case ControlChangeType.Undefined03LSB:
                    onUndefined03LSB(message);
                    break;
                case ControlChangeType.FootControllerLSB:
                    onFootControllerLSB(message);
                    break;
                case ControlChangeType.PortamentoTimeLSB:
                    onPortamentoTimeLSB(message);
                    break;
                case ControlChangeType.DataEntryLSB:
                    onDataEntryLSB(message);
                    break;
                case ControlChangeType.ChannelVolumeLSB:
                    onChannelVolumeLSB(message);
                    break;
                case ControlChangeType.BalanceLSB:
                    onBalanceLSB(message);
                    break;
                case ControlChangeType.Undefined09LSB:
                    onUndefined09LSB(message);
                    break;
                case ControlChangeType.PanLSB:
                    onPanLSB(message);
                    break;
                case ControlChangeType.ExpressionControllerLSB:
                    onExpressionControllerLSB(message);
                    break;
                case ControlChangeType.EffectControl1LSB:
                    onEffectControl1LSB(message);
                    break;
                case ControlChangeType.EffectControl2LSB:
                    onEffectControl2LSB(message);
                    break;
                case ControlChangeType.Undefined0ELSB:
                    onUndefined0ELSB(message);
                    break;
                case ControlChangeType.Undefined0FLSB:
                    onUndefined0FLSB(message);
                    break;
                case ControlChangeType.GeneralPurposeController1LSB:
                    onGeneralPurposeController1LSB(message);
                    break;
                case ControlChangeType.GeneralPurposeController2LSB:
                    onGeneralPurposeController2LSB(message);
                    break;
                case ControlChangeType.GeneralPurposeController3LSB:
                    onGeneralPurposeController3LSB(message);
                    break;
                case ControlChangeType.GeneralPurposeController4LSB:
                    onGeneralPurposeController4LSB(message);
                    break;
                case ControlChangeType.Undefined14LSB:
                    onUndefined14LSB(message);
                    break;
                case ControlChangeType.Undefined15LSB:
                    onUndefined15LSB(message);
                    break;
                case ControlChangeType.Undefined16LSB:
                    onUndefined16LSB(message);
                    break;
                case ControlChangeType.Undefined17LSB:
                    onUndefined17LSB(message);
                    break;
                case ControlChangeType.Undefined18LSB:
                    onUndefined18LSB(message);
                    break;
                case ControlChangeType.Undefined19LSB:
                    onUndefined19LSB(message);
                    break;
                case ControlChangeType.Undefined1ALSB:
                    onUndefined1ALSB(message);
                    break;
                case ControlChangeType.Undefined1BLSB:
                    onUndefined1BLSB(message);
                    break;
                case ControlChangeType.Undefined1CLSB:
                    onUndefined1CLSB(message);
                    break;
                case ControlChangeType.Undefined1DLSB:
                    onUndefined1DLSB(message);
                    break;
                case ControlChangeType.Undefined1ELSB:
                    onUndefined1ELSB(message);
                    break;
                case ControlChangeType.Undefined1FLSB:
                    onUndefined1FLSB(message);
                    break;
                case ControlChangeType.Hold:
                    onHold(message);
                    break;
                case ControlChangeType.Portamento:
                    onPortamento(message);
                    break;
                case ControlChangeType.Sostenuto:
                    onSostenuto(message);
                    break;
                case ControlChangeType.SoftPedal:
                    onSoftPedal(message);
                    break;
                case ControlChangeType.LegatoFootswitch:
                    onLegatoFootswitch(message);
                    break;
                case ControlChangeType.Hold2:
                    onHold2(message);
                    break;
                case ControlChangeType.SoundController1:
                    onSoundController1(message);
                    break;
                case ControlChangeType.SoundController2:
                    onSoundController2(message);
                    break;
                case ControlChangeType.SoundController3:
                    onSoundController3(message);
                    break;
                case ControlChangeType.SoundController4:
                    onSoundController4(message);
                    break;
                case ControlChangeType.SoundController5:
                    onSoundController5(message);
                    break;
                case ControlChangeType.SoundController6:
                    onSoundController6(message);
                    break;
                case ControlChangeType.SoundController7:
                    onSoundController7(message);
                    break;
                case ControlChangeType.SoundController8:
                    onSoundController8(message);
                    break;
                case ControlChangeType.SoundController9:
                    onSoundController9(message);
                    break;
                case ControlChangeType.SoundController10:
                    onSoundController10(message);
                    break;
                case ControlChangeType.GeneralPurposeController5:
                    onGeneralPurposeController5(message);
                    break;
                case ControlChangeType.GeneralPurposeController6:
                    onGeneralPurposeController6(message);
                    break;
                case ControlChangeType.GeneralPurposeController7:
                    onGeneralPurposeController7(message);
                    break;
                case ControlChangeType.GeneralPurposeController8:
                    onGeneralPurposeController8(message);
                    break;
                case ControlChangeType.PortamentoControl:
                    onPortamentoControl(message);
                    break;
                case ControlChangeType.Undefined55:
                    onUndefined55(message);
                    break;
                case ControlChangeType.Undefined56:
                    onUndefined56(message);
                    break;
                case ControlChangeType.Undefined57:
                    onUndefined57(message);
                    break;
                case ControlChangeType.Undefined58:
                    onUndefined58(message);
                    break;
                case ControlChangeType.Undefined59:
                    onUndefined59(message);
                    break;
                case ControlChangeType.Undefined5A:
                    onUndefined5A(message);
                    break;
                case ControlChangeType.Effects1Depth:
                    onEffects1Depth(message);
                    break;
                case ControlChangeType.Effects2Depth:
                    onEffects2Depth(message);
                    break;
                case ControlChangeType.Effects3Depth:
                    onEffects3Depth(message);
                    break;
                case ControlChangeType.Effects4Depth:
                    onEffects4Depth(message);
                    break;
                case ControlChangeType.Effects5Depth:
                    onEffects5Depth(message);
                    break;
                case ControlChangeType.DataIncrement:
                    onDataIncrement(message);
                    break;
                case ControlChangeType.DataDecrement:
                    onDataDecrement(message);
                    break;
                case ControlChangeType.NonRegisteredParameterNumberLSB:
                    onNonRegisteredParameterNumberLSB(message);
                    break;
                case ControlChangeType.NonRegisteredParameterNumberMSB:
                    onNonRegisteredParameterNumberMSB(message);
                    break;
                case ControlChangeType.RegisteredParameterNumberLSB:
                    onRegisteredParameterNumberLSB(message);
                    break;
                case ControlChangeType.RegisteredParameterNumberMSB:
                    onRegisteredParameterNumberMSB(message);
                    break;
                case ControlChangeType.Undefined66:
                    onUndefined66(message);
                    break;
                case ControlChangeType.Undefined67:
                    onUndefined67(message);
                    break;
                case ControlChangeType.Undefined68:
                    onUndefined68(message);
                    break;
                case ControlChangeType.Undefined69:
                    onUndefined69(message);
                    break;
                case ControlChangeType.Undefined6A:
                    onUndefined6A(message);
                    break;
                case ControlChangeType.Undefined6B:
                    onUndefined6B(message);
                    break;
                case ControlChangeType.Undefined6C:
                    onUndefined6C(message);
                    break;
                case ControlChangeType.Undefined6D:
                    onUndefined6D(message);
                    break;
                case ControlChangeType.Undefined6E:
                    onUndefined6E(message);
                    break;
                case ControlChangeType.Undefined6F:
                    onUndefined6F(message);
                    break;
                case ControlChangeType.Undefined70:
                    onUndefined70(message);
                    break;
                case ControlChangeType.Undefined71:
                    onUndefined71(message);
                    break;
                case ControlChangeType.Undefined72:
                    onUndefined72(message);
                    break;
                case ControlChangeType.Undefined73:
                    onUndefined73(message);
                    break;
                case ControlChangeType.Undefined74:
                    onUndefined74(message);
                    break;
                case ControlChangeType.Undefined75:
                    onUndefined75(message);
                    break;
                case ControlChangeType.Undefined76:
                    onUndefined76(message);
                    break;
                case ControlChangeType.Undefined77:
                    onUndefined77(message);
                    break;
            }
            OnControlChange.Invoke(message);
        }

    }
}
