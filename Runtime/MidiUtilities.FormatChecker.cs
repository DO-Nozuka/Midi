namespace Dono.Midi.Runtime
{
    public static partial class MidiUtilities
    {
        public static bool IsCorrectFormat(byte[] bytes)
        {
            if (!IsCorrectDataFormat(bytes))
                return false;

            if (!IsCorrectMessageFormat(bytes))
                return false;

            return true;
        }

        /// <summary>
        /// 0b1xxxxxxx 0b0xxxxxxx ... のフォーマットになっているかどうか
        /// フォーマットが正しい場合true, 正しくない場合false, データ長が0の場合もfalse
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static bool IsCorrectDataFormat(byte[] bytes)
        {
            if (bytes == null)
                return false;
            if (bytes.Length == 0)
                return false;
            if ((bytes[0] & 0b10000000) != 0b10000000)
                return false;
            if (bytes[0] == 0xF0 || bytes[0] == 0xFF)
            {
                // TODO とりあえず先頭2バイトだけチェック、それ以降はisSMFで場合分けが必要
                if (bytes.Length < 3)
                    return false;
                if ((bytes[1] & 0b10000000) != 0b00000000)
                    return false;
            }
            else
            {
                for (int i = 1; i < bytes.Length; i++)
                {
                    if ((bytes[i] & 0b10000000) != 0b00000000)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// "data"が"messageType"の形式になっているかを確認します
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        private static bool IsCorrectMessageFormat(byte[] message)
        {
            if (0x80 <= message[0] && message[0] <= 0xAF)
            {
                return message.Length == 3;
            }
            if (message[0] <= 0xBF)
            {
                if (message.Length == 3)
                {
                    if (message[1] <= 0x77)
                        return true;
                    else //if(message[1] <= 7F) //Channel Mode Message
                    {
                        switch (message[1])
                        {
                            case 0x78: return message[2] == 0;
                            case 0x79: return message[2] == 0;
                            case 0x7A: return message[2] == 0 || message[2] == 0xFF;
                            case 0x7B: return message[2] == 0;
                            case 0x7C: return message[2] == 0;
                            case 0x7D: return message[2] == 0;
                            case 0x7E: return message[2] <= 16;
                            case 0x7F: return message[2] == 0;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            if (message[0] <= 0xDF)
            {
                return message.Length == 2;
            }
            if (message[0] <= 0xEF)
            {
                return message.Length == 3;
            }
            if (message[0] == 0xF0)
            {
                //SystemExclusive
                throw new System.Exception();
            }
            if (message[0] <= 0xF7)
            {
                switch (message[0])
                {
                    case 0xF1: return message.Length == 2;
                    case 0xF2: return message.Length == 3;
                    case 0xF3: return message.Length == 2;
                    case 0xF4: return false;   //Undefined
                    case 0xF5: return false;   //Undefined
                    case 0xF6: return message.Length == 1;
                    case 0xF7: return message.Length == 1;
                }
            }
            if (message[0] <= 0xFE)
            {
                switch (message[0])
                {
                    case 0xF8: return message.Length == 1;
                    case 0xF9: return false;   //Undefined
                    case 0xFA: return message.Length == 1;
                    case 0xFB: return message.Length == 1;
                    case 0xFC: return message.Length == 1;
                    case 0xFD: return false;   //Undefined
                    case 0xFE: return message.Length == 1;
                }
            }
            if (message[0] == 0xFF)
            {
                if (message.Length == 1) // System Reset
                    return true;
                if (message.Length >= 2) //Meta Event (not check what it mean)
                    return true;
            }
            return false;
        }
    }
}