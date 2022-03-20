using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.Midi
{

    public partial class MidiModule
    {
        private void dataInc(Midi1ByteValue value)
        {
            var cBits = value.Bits;
            if (cBits == 0x7F)
            {
                // NOP
            }
            else
            {
                value.SetBits((byte)(cBits + 1));
            }
        }
        private void dataInc(Midi2ByteValue value)
        {
            var cMSB = value.Msb;
            var cLSB = value.Lsb;

            if (cMSB == 0x7F && cLSB == 0x7F)
            {
                // NOP
            }
            else if (cLSB == 0x7F)
            {
                value.SetBits((byte)(cMSB + 1), 0);
            }
            else
            {
                value.SetBits(cMSB, (byte)(cLSB + 1));
            }
        }
        private void dataDec(Midi1ByteValue value)
        {
            var cBits = value.Bits;
            if (cBits == 0x00)
            {
                // NOP
            }
            else
            {
                value.SetBits((byte)(cBits - 1));
            }
        }
        private void dataDec(Midi2ByteValue value)
        {
            var cMSB = value.Msb;
            var cLSB = value.Lsb;

            if (cMSB == 0x00 && cLSB == 0x00)
            {
                // NOP
            }
            else if (cLSB == 0x00)
            {
                value.SetBits((byte)(cMSB - 1), 0x7F);
            }
            else
            {
                value.SetBits(cMSB, (byte)(cLSB - 1));
            }
        }

        public virtual void OnDataEntryMSB(MidiMessage message)
        {
            if (ChannelState[message.Channel].Parameter.IsTargetRegisterdParameter)
            {
                byte RPN_MSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.Value;
                byte RPN_LSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.Value;

                if (RPN_MSB == 0x00 && RPN_LSB == 0x00)
                {
                    ChannelState[message.Channel].Parameter.PitchBendSensitivity.SetMsb(message.Data2);
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x01)
                {
                    ChannelState[message.Channel].Parameter.MasterTuning.FineTune.SetMsb(message.Data2);
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x02)
                {
                    ChannelState[message.Channel].Parameter.MasterTuning.CoarseTune.SetBits(message.Data2);
                }
            }
            else
            {
                byte NRPN_MSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.Value;
                byte NRPN_LSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.Value;
                
                uint NRPN = ((uint)NRPN_MSB << 7) + NRPN_LSB;

                if (ChannelState[message.Channel].Parameter.NonRegisterdParameter.ContainsKey(NRPN))
                {
                    ChannelState[message.Channel].Parameter.NonRegisterdParameter[NRPN].SetMsb(message.Data2);
                }
                else
                {
                    ChannelState[message.Channel].Parameter.NonRegisterdParameter.Add(NRPN, new Midi2ByteValue(false));
                    ChannelState[message.Channel].Parameter.NonRegisterdParameter[NRPN].SetMsb(message.Data2);
                }
            }
            OnDataEntryChange(message);
        }
        public virtual void OnDataEntryLSB(MidiMessage message)
        {
            if (ChannelState[message.Channel].Parameter.IsTargetRegisterdParameter)
            {
                byte RPN_MSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.Value;
                byte RPN_LSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.Value;

                if (RPN_MSB == 0x00 && RPN_LSB == 0x00)
                {
                    ChannelState[message.Channel].Parameter.PitchBendSensitivity.SetLsb(message.Data2);
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x01)
                {
                    ChannelState[message.Channel].Parameter.MasterTuning.FineTune.SetLsb(message.Data2);
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x02)
                {
                    // NOP: CoarseTune‚Å‚ÍLSB‚ª–³Ž‹‚³‚ê‚é
                }
            }
            else
            {
                byte NRPN_MSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.Value;
                byte NRPN_LSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.Value;

                uint NRPN = ((uint)NRPN_MSB << 7) + NRPN_LSB;

                if (ChannelState[message.Channel].Parameter.NonRegisterdParameter.ContainsKey(NRPN))
                {
                    ChannelState[message.Channel].Parameter.NonRegisterdParameter[NRPN].SetLsb(message.Data2);
                }
                else
                {
                    ChannelState[message.Channel].Parameter.NonRegisterdParameter.Add(NRPN, new Midi2ByteValue(false));
                    ChannelState[message.Channel].Parameter.NonRegisterdParameter[NRPN].SetLsb(message.Data2);
                }
            }
            OnDataEntryChange(message);
        }
        public virtual void OnDataEntryChange(MidiMessage message) { }
        public virtual void OnDataIncrement(MidiMessage message)
        {
            if (ChannelState[message.Channel].Parameter.IsTargetRegisterdParameter)
            {
                byte RPN_MSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.Value;
                byte RPN_LSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.Value;

                if (RPN_MSB == 0x00 && RPN_LSB == 0x00)
                {
                    dataInc(ChannelState[message.Channel].Parameter.PitchBendSensitivity);
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x01)
                {
                    dataInc(ChannelState[message.Channel].Parameter.MasterTuning.FineTune);
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x02)
                {
                    dataInc(ChannelState[message.Channel].Parameter.MasterTuning.CoarseTune);
                }
            }
            else
            {
                byte NRPN_MSB = ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberMSB.Value;
                byte NRPN_LSB = ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberLSB.Value;
                uint NRPN = ((uint)NRPN_MSB << 7) + NRPN_LSB;

                if (ChannelState[message.Channel].Parameter.NonRegisterdParameter.ContainsKey(NRPN))
                {
                    dataInc(ChannelState[message.Channel].Parameter.NonRegisterdParameter[NRPN]);
                }
                else
                {
                    // NOP
                }
            }
        }
        public virtual void OnDataDecrement(MidiMessage message)
        {
            if (ChannelState[message.Channel].Parameter.IsTargetRegisterdParameter)
            {
                byte RPN_MSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.Value;
                byte RPN_LSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.Value;

                if (RPN_MSB == 0x00 && RPN_LSB == 0x00)
                {
                    dataDec(ChannelState[message.Channel].Parameter.PitchBendSensitivity);
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x01)
                {
                    dataDec(ChannelState[message.Channel].Parameter.MasterTuning.FineTune);
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x02)
                {
                    dataDec(ChannelState[message.Channel].Parameter.MasterTuning.CoarseTune);
                }
            }
            else
            {
                byte NRPN_MSB = ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberMSB.Value;
                byte NRPN_LSB = ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberLSB.Value;
                uint NRPN = ((uint)NRPN_MSB << 7) + NRPN_LSB;

                if (ChannelState[message.Channel].Parameter.NonRegisterdParameter.ContainsKey(NRPN))
                {
                    dataDec(ChannelState[message.Channel].Parameter.NonRegisterdParameter[NRPN]);
                }
                else
                {
                    // NOP
                }
            }
        }
        public virtual void OnNonRegisteredParameterNumberLSB(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberLSB.SetBits(message.Data2);
        }
        public virtual void OnNonRegisteredParameterNumberMSB(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberMSB.SetBits(message.Data2);
        }
        public virtual void OnRegisteredParameterNumberLSB(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.SetBits(message.Data2);
        }
        public virtual void OnRegisteredParameterNumberMSB(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.SetBits(message.Data2);
        }
    }
}
