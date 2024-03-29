﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dono.Midi
{
    public class SMFTrack
    {
        public int Channel { get; private set; } = -1;
        public string TrackName { get; private set; } = "";
        public SMFTrackType TrackType { get; private set; } = SMFTrackType.Part;
        public int Port { get; private set; } = -1;
        public List<SMFEvent> Messages { get; private set; }

        public SMFTrack(List<SMFEvent> messages, int format = 1)
        {
            if (!(format == 0 || format == 1))
                throw new FormatException();

            Messages = messages;


            // チャンネルの取得
            foreach (var message in messages)
            {
                if (message.Message.messageType == MessageType.ChannelMode || message.Message.messageType == MessageType.ChannelVoice)
                {
                    if (Channel == -1)
                    {
                        Channel = message.Message.Channel;
                    }
                    else if (Channel != message.Message.Channel) // フォーマット0でしかありえない
                    {
                        if (format == 0)
                            Channel = -2;
                        else if (format == 1)
                            throw new FormatException();
                    }
                }
            }

            // TrackNameの取得
            foreach (var message in messages)
            {
                if (message.Message.metaEventType == MetaEventType.SequenceAndTrackName)
                {
                    var bytes = message.Message.Bytes;
                    int index = 2;
                    int dataLength = StandardMidiFile.VariableLengthDataToInt32(bytes, ref index);

                    var trackNameBytes = new byte[dataLength];
                    Array.Copy(bytes, index, trackNameBytes, 0, dataLength);


                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    TrackName = Encoding.GetEncoding("Shift_JIS").GetString(trackNameBytes);
                }
            }

            // TrackTypeの取得
            if (TrackName == "Score Setup" || TrackName == "Partitura Setup")
                TrackType = SMFTrackType.ScoreSetup;
            else if (messages.Find((n) => n.Message.metaEventType == MetaEventType.SetTempo || n.Message.metaEventType == MetaEventType.TimeSignature) != null)
                TrackType = SMFTrackType.Conductor;
            else
                TrackType = SMFTrackType.Part;

            // Portの取得
            foreach (var message in messages)
            {
                if (message.Message.metaEventType == MetaEventType.PortPrefix)
                {
                    Port = message.Message.Bytes[3];
                }
            }
        }

    }
}