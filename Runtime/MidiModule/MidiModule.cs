using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{
    /// <summary>
    /// Action\<MidiMessage\>�^��OnXXX����R�p�ӂ��Ă��܂��̂ŁA
    /// ���L�菇�ł��g����������
    /// 0. �C���X�^���X�̐���
    /// 1. OnXXX�Ƀ��\�b�h��o�^
    /// 2. RecieveMessage(MidiMessage message)��Midi���b�Z�[�W��n��
    /// 3. OnXXX�����s�����
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
