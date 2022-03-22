using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{
    /// <summary>
    /// Action\<MidiMessage\>型でOnXXXが沢山用意していますので、
    /// 下記手順でお使いください
    /// 0. インスタンスの生成
    /// 1. OnXXXにメソッドを登録
    /// 2. RecieveMessage(MidiMessage message)にMidiメッセージを渡す
    /// 3. OnXXXが実行される
    /// </summary>
    public partial class MidiModule
    {
        public ChannelState[] ChannelState { get; internal set; } = new ChannelState[16];

        // ## Channel Mode Message (0xBn: 120-127)
        public ChannelModeState ChannelMode { get; internal set; } = new ChannelModeState();

        public void RecieveMessage(MidiMessage message)
        {
            AnyMessageSplitter(message);
        }

        public MidiModule()
        {
            for (int i = 0; i < 16; i++)
            {
                ChannelState[i] = new ChannelState();
            }

        }
    }
}
