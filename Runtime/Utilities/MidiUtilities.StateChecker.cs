namespace Dono.Midi
{
    public static partial class MidiUtilities
    {
        private static bool[] _isWhiteNoteTable =
        {
            //C     C#      D       D#      E       F       F#      G       G#      A       A#      B
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   //  0 - 11 国際式 -1, ヤマハ式 -2
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 12 - 23 国際式  0, ヤマハ式 -1
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 24 - 35 国際式  1, ヤマハ式  0
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 36 - 47 国際式  2, ヤマハ式  1
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 48 - 59 国際式  3, ヤマハ式  2 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 60 - 71 国際式  4, ヤマハ式  3 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 72 - 83 国際式  5, ヤマハ式  4 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 84 - 95 国際式  6, ヤマハ式  5 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 96 -107 国際式  7, ヤマハ式  6 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   //108 -119 国際式  8, ヤマハ式  7 
            true,   false,  true,   false,  true,   true,   false,  true                                    //120 -127 国際式  9, ヤマハ式  8
        };

        public static bool IsWhiteNote(byte note) => _isWhiteNoteTable[note];
        public static bool IsBlackNote(byte note) => !_isWhiteNoteTable[note];

        public static bool IsWhiteNote(MidiMessage message)
        {
            if (message.channelVoiceType == ChannelVoiceType.NoteOff || message.channelVoiceType == ChannelVoiceType.NoteOn)
                return IsWhiteNote(message.Data1);
            else
                return false;
        }
        public static bool IsBlackNote(MidiMessage message)
        {
            if (message.channelVoiceType == ChannelVoiceType.NoteOff || message.channelVoiceType == ChannelVoiceType.NoteOn)
                return IsBlackNote(message.Data1);
            else
                return false;
        }
    }
}