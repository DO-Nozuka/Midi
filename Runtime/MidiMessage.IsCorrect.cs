namespace Dono.Midi.Runtime
{
    /// <summary>
    /// MidiMessage.IsCorrect
    /// for check format
    /// </summary>
    public partial class MidiMessage
    {
        ///// <summary>
        ///// "data"が"messageType"の形式になっているかを確認します
        ///// </summary>
        ///// <param name="data"></param>
        ///// <param name="messageType"></param>
        ///// <returns></returns>
        //public static bool IsCorrectMessage(byte[] data, Type messageType = Type.None)
        //{
        //    switch(messageType)
        //    {
        //        case Type.NoteOff:                  return IsNoteOffMessage(data);
        //        case Type.NoteOn:                   return IsNoteOnMessage(data);
        //        case Type.PolyphonicKeyPressure:    return IsPolyphonicKeyPressureMessage(data);
        //        case Type.ControlChange:            return IsControlChangeMessage(data);
        //        case Type.ProgramChange:            return IsProgramChangeMessage(data);
        //        case Type.ChannelPressure:          return IsChannelPressureMessage(data);
        //        case Type.PitchBend:                return IsPitchBendMessage(data);
        //        case Type.ChannelModeSelect:        return IsChannelModeSelectMessage(data);
        //        case Type.SystemCommonMessage:      return IsSystemCommonMessage(data);
        //        case Type.SystemRealTimeMessage:    return IsSystemRealTimeMessage(data);
        //        case Type.MetaEvent:                return IsMetaEventMessage(data);
        //        default:    //StatusByteType.None  

        //            return false;
        //    }
        //}

        ////Channel Voice Message
        //public static bool IsNoteOffMessage(byte[] data) { return IsCorrectChannelMessageFormat(data, 3, 0x80); }                
        //public static bool IsNoteOnMessage(byte[] data) { return IsCorrectChannelMessageFormat(data, 3, 0x90); }
        //public static bool IsPolyphonicKeyPressureMessage(byte[] data) { return IsCorrectChannelMessageFormat(data, 3, 0xA0); }
        //public static bool IsControlChangeMessage(byte[] data) { return IsCorrectChannelMessageFormat(data, 3, 0xB0); }
        //public static bool IsProgramChangeMessage(byte[] data) { return IsCorrectChannelMessageFormat(data, 2, 0xC0); }
        //public static bool IsChannelPressureMessage(byte[] data) { return IsCorrectChannelMessageFormat(data, 2, 0xD0); }
        //public static bool IsPitchBendMessage(byte[] data) { return IsCorrectChannelMessageFormat(data, 3, 0xE0); }
        ////Channel Mode Message
        //public static bool IsChannelModeSelectMessage(byte[] data) { return IsCorrectChannelMessageFormat(data, 3, 0xB0); }
        ////System Message
        ////public static bool IsSystemExclusiveMessage(byte[] data) 
        ////{
        ////    //ステータスバイト
        ////    if (data[0] != 0xF0)
        ////        return false;

        ////    //データバイト
        ////    for(int i = 1; i < data.Length - 1; i++)
        ////    {
        ////        if ((data[i] & 0b10000000) != 0)
        ////            return false;
        ////    }

        ////    //EOX(End of eXclusive)
        ////    if (data[data.Length - 1] != 0xF7)
        ////        return false;

        ////    return true;
        ////}
        //public static bool IsSystemCommonMessage(byte[] data)
        //{
        //    switch(data[0])
        //    {
        //        case 0xF1:  return IsCorrectChannelMessageFormat(data, 2, 0xF0);
        //        case 0xF2:  return IsCorrectChannelMessageFormat(data, 3, 0xF0);
        //        case 0xF3:  return IsCorrectChannelMessageFormat(data, 2, 0xF0);
        //        case 0xF4:  return IsCorrectChannelMessageFormat(data, 1, 0xF0); //(未定義;予約済)
        //        case 0xF5:  return IsCorrectChannelMessageFormat(data, 1, 0xF0); //(未定義;予約済)
        //        case 0xF6:  return IsCorrectChannelMessageFormat(data, 1, 0xF0);
        //        case 0xF7:  return IsCorrectChannelMessageFormat(data, 1, 0xF0);
        //        default:    return false;
        //    }
        //}
        //public static bool IsSystemRealTimeMessage(byte[] data)
        //{
        //    switch (data[0])
        //    {
        //        case 0xF8: return IsCorrectChannelMessageFormat(data, 1, 0xF0);
        //        case 0xF9: return IsCorrectChannelMessageFormat(data, 1, 0xF0);
        //        case 0xFA: return IsCorrectChannelMessageFormat(data, 1, 0xF0);
        //        case 0xFB: return IsCorrectChannelMessageFormat(data, 1, 0xF0); //(未定義;予約済)
        //        case 0xFC: return IsCorrectChannelMessageFormat(data, 1, 0xF0); //(未定義;予約済)
        //        case 0xFD: return IsCorrectChannelMessageFormat(data, 1, 0xF0);
        //        case 0xFE: return IsCorrectChannelMessageFormat(data, 1, 0xF0);
        //        case 0xFF: return IsCorrectChannelMessageFormat(data, 1, 0xF0);
        //        default: return false;
        //    }
        //}
        //public static bool IsMetaEventMessage(byte[] data)
        //{
        //    throw new global::System.NotImplementedException();
        //}

        ////ツールのツール
        //private static bool IsCorrectChannelMessageFormat(byte[] data, byte correctDataLength, byte statusMask)
        //{
        //    //データ長の確認
        //    if (data.Length != correctDataLength)
        //        return false;

        //    //ステータスバイトのフォーマット確認
        //    if ((data[0] & 0b11110000) != statusMask)
        //        return false;

        //    //データバイトのフォーマット確認(先頭が0であること)
        //    for (int i = 1; i < data.Length; i++)
        //    {
        //        if ((data[i] & 0b10000000) != 0)
        //            return false;
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value1"></param>
        ///// <param name="value2"></param>
        ///// <returns></returns>
        //public static int GetPitchBendValue(byte value1, byte value2) => (value2 << 7) + value1 - 8192;
        //public static float GetPitchBendRate(byte value1, byte value2)
        //{
        //    var value = GetPitchBendValue(value1, value2);
        //    return value > 0 ? value / 8191f : value / 8192f;
        //}
    }
}
