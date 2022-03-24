namespace Dono.Midi
{
    public static partial class MidiUtilities
    {
        private static bool[] _isWhiteNoteTable =
        {
            //C     C#      D       D#      E       F       F#      G       G#      A       A#      B
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   //  0 - 11 ���ێ� -1, ���}�n�� -2
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 12 - 23 ���ێ�  0, ���}�n�� -1
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 24 - 35 ���ێ�  1, ���}�n��  0
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 36 - 47 ���ێ�  2, ���}�n��  1
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 48 - 59 ���ێ�  3, ���}�n��  2 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 60 - 71 ���ێ�  4, ���}�n��  3 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 72 - 83 ���ێ�  5, ���}�n��  4 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 84 - 95 ���ێ�  6, ���}�n��  5 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   // 96 -107 ���ێ�  7, ���}�n��  6 
            true,   false,  true,   false,  true,   true,   false,  true,   false,  true,   false,  true,   //108 -119 ���ێ�  8, ���}�n��  7 
            true,   false,  true,   false,  true,   true,   false,  true                                    //120 -127 ���ێ�  9, ���}�n��  8
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