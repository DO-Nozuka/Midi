namespace Dono.MidiUtilities.Runtime
{
    public partial class MidiMessage
    {
        public enum Type : byte
        {
            None,
            // Channel Voice Message
            NoteOff = 0x80,
            NoteOn = 0x90,
            PolyphonicKeyPressure = 0xA0,
            ControlChange = 0xB0,
            ProgramChange = 0xC0,
            ChannelPressure = 0xD0,
            PitchBend = 0xE0,
            // Channel Mode Message
            ChannelModeSelect = 0xB1,
            // System Message
            SystemCommonMessage = 0xF0,     // 0xF0-0xF7 
            SystemRealTimeMessage = 0xF8,   // 0xF8-0xFF リアルタイムMIDIのみ
            MetaEvent = 0xFF                //      0xFF SMFファイルのみ(データ長で判別)
        }

        /// <summary>
        /// ChannelVoiceMessageかChannelModeMessageであればTrueを返す
        /// </summary>
        /// <param name="statusByteType"></param>
        /// <returns></returns>
        private bool IsChannelMessage()
        {
            switch (MessageType)
            {
                case Type.NoteOff:
                case Type.NoteOn:
                case Type.PolyphonicKeyPressure:
                case Type.ControlChange:
                case Type.ProgramChange:
                case Type.ChannelPressure:
                case Type.PitchBend:
                case Type.ChannelModeSelect:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// ChannelVoiceMessageであればTrueを返す
        /// ※IsChannelMessageは異なることに注意して下さい
        /// </summary>
        /// <param name="statusByteType"></param>
        /// <returns></returns>
        public bool IsChannelVoiceMessage()
        {
            switch (MessageType)
            {
                case Type.NoteOff:
                case Type.NoteOn:
                case Type.PolyphonicKeyPressure:
                case Type.ControlChange:
                case Type.ProgramChange:
                case Type.ChannelPressure:
                case Type.PitchBend:
                    return true;
                default:
                    return false;
            }
        }



        //    /// <summary>
        //    /// ChannelModeMessageであればTrueを返す
        //    /// ※IsChannelMessageは異なることに注意して下さい
        //    /// </summary>
        //    /// <param name="statusByteType"></param>
        //    /// <returns></returns>
        //    public static bool IsChannelModeMessage(Type statusByteType)
        //    {
        //        switch (statusByteType)
        //        {
        //            case Type.ChannelModeSelect:
        //                return true;
        //            default:
        //                return false;
        //        }
        //    }
        //    /// <summary>
        //    /// SystemMessageであればTrueを返す
        //    /// </summary>
        //    /// <param name="statusByteType"></param>
        //    /// <returns></returns>
        //    public static bool IsSystemMessage(Type statusByteType)
        //    {
        //        switch (statusByteType)
        //        {
        //            case Type.SystemCommonMessage:
        //            case Type.SystemRealTimeMessage:
        //            case Type.SystemExclusiveMessage:
        //                return true;
        //            default:
        //                return false;
        //        }
        //    }



        /// <summary>
        /// 現在の実装では細かい所までフォーマットチェックを行っていません
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Type GetStatusType(byte[] data)
        {
            Type statusByteType = Type.None;

            //データ長の確認
            if (data.Length == 0)
                return statusByteType;

            byte StatusByte = data[0];
            byte StatusByteUpper = (byte)(StatusByte & 0b11110000);
            byte StatusByteLower = (byte)(StatusByte & 0b00001111);

            //StatusByte上位とコントロール番号からStatusByteTypeを分類
            switch (StatusByteUpper)
            {
                case 0x80:
                    statusByteType = Type.NoteOff;
                    break;
                case 0x90:
                    statusByteType = Type.NoteOn;
                    break;
                case 0xA0:
                    statusByteType = Type.PolyphonicKeyPressure;
                    break;
                case 0xC0:
                    statusByteType = Type.ProgramChange;
                    break;
                case 0xD0:
                    statusByteType = Type.ChannelPressure;
                    break;
                case 0xE0:
                    statusByteType = Type.PitchBend;
                    break;
                case 0xB0:
                    if (data.Length >= 2)
                    {
                        if (data[1] < 0x78)
                            statusByteType = Type.ControlChange;
                        else if (data[1] < 0x80)
                            statusByteType = Type.ChannelModeSelect;
                        else
                            statusByteType = Type.None;
                    }
                    else
                        statusByteType = Type.None;
                    break;
                case 0xF0:
                    if (StatusByteLower < 0x08)
                    {
                        statusByteType = Type.SystemCommonMessage;
                    }
                    else
                    {
                        if (StatusByteLower != 0x0F)
                        {
                            statusByteType = Type.SystemRealTimeMessage;
                        }
                        else
                        {
                            if (data.Length == 1)
                                statusByteType = Type.SystemRealTimeMessage;
                            else
                                statusByteType = Type.MetaEvent;
                        }
                    }
                    break;
                default:
                    statusByteType = Type.None;
                    break;
            }

            if (IsCorrectMessage(data, statusByteType))
                return statusByteType;
            else
                return Type.None;
        }
    }
}