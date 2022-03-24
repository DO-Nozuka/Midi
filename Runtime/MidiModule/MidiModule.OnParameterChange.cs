using System;

namespace Dono.Midi
{

    public partial class MidiModule
    {
        public Action<MidiMessage> OnDataEntryMSB = (m) => { };
        public Action<MidiMessage> OnDataEntryLSB = (m) => { };
        public Action<MidiMessage> OnDataIncrement = (m) => { };
        public Action<MidiMessage> OnDataDecrement = (m) => { };

        /// <summary>
        /// OnDataEntryMSB / OnDataEntryLSB / OnDataIncrement / OnDataDecrement
        /// </summary>
        public Action<MidiMessage> OnDataEntryChange = (m) => { };

        public Action<MidiMessage> OnNonRegisteredParameterNumberLSB = (m) => { };
        public Action<MidiMessage> OnNonRegisteredParameterNumberMSB = (m) => { };
        public Action<MidiMessage> OnRegisteredParameterNumberLSB = (m) => { };
        public Action<MidiMessage> OnRegisteredParameterNumberMSB = (m) => { };

        private void onDataEntryMSB(MidiMessage message)
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

            OnDataEntryMSB.Invoke(message);
            OnDataEntryChange.Invoke(message);
        }
        private void onDataEntryLSB(MidiMessage message)
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
                    // NOP: CoarseTuneではLSBが無視される
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

            OnDataEntryLSB.Invoke(message);
            OnDataEntryChange.Invoke(message);
        }
        private void onDataIncrement(MidiMessage message)
        {
            if (ChannelState[message.Channel].Parameter.IsTargetRegisterdParameter)
            {
                byte RPN_MSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.Value;
                byte RPN_LSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.Value;

                if (RPN_MSB == 0x00 && RPN_LSB == 0x00)
                {
                    ChannelState[message.Channel].Parameter.PitchBendSensitivity.IncValue();
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x01)
                {
                    ChannelState[message.Channel].Parameter.MasterTuning.FineTune.IncValue();
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x02)
                {
                    ChannelState[message.Channel].Parameter.MasterTuning.CoarseTune.IncValue();
                }
            }
            else
            {
                byte NRPN_MSB = ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberMSB.Value;
                byte NRPN_LSB = ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberLSB.Value;
                uint NRPN = ((uint)NRPN_MSB << 7) + NRPN_LSB;

                if (ChannelState[message.Channel].Parameter.NonRegisterdParameter.ContainsKey(NRPN))
                {
                    ChannelState[message.Channel].Parameter.NonRegisterdParameter[NRPN].IncValue();
                }
                else
                {
                    // NOP
                }
            }

            OnDataIncrement.Invoke(message);
            OnDataEntryChange.Invoke(message);
        }
        private void onDataDecrement(MidiMessage message)
        {
            if (ChannelState[message.Channel].Parameter.IsTargetRegisterdParameter)
            {
                byte RPN_MSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.Value;
                byte RPN_LSB = ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.Value;

                if (RPN_MSB == 0x00 && RPN_LSB == 0x00)
                {
                    ChannelState[message.Channel].Parameter.PitchBendSensitivity.DecValue();
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x01)
                {
                    ChannelState[message.Channel].Parameter.MasterTuning.FineTune.DecValue();
                }
                else if (RPN_MSB == 0x00 && RPN_LSB == 0x02)
                {
                    ChannelState[message.Channel].Parameter.MasterTuning.CoarseTune.DecValue();
                }
            }
            else
            {
                byte NRPN_MSB = ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberMSB.Value;
                byte NRPN_LSB = ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberLSB.Value;
                uint NRPN = ((uint)NRPN_MSB << 7) + NRPN_LSB;

                if (ChannelState[message.Channel].Parameter.NonRegisterdParameter.ContainsKey(NRPN))
                {
                    ChannelState[message.Channel].Parameter.NonRegisterdParameter[NRPN].DecValue();
                }
                else
                {
                    // NOP
                }
            }

            OnDataDecrement.Invoke(message);
            OnDataEntryChange.Invoke(message);
        }
        private void onNonRegisteredParameterNumberLSB(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberLSB.SetBits(message.Data2);
            OnNonRegisteredParameterNumberLSB.Invoke(message);
        }
        private void onNonRegisteredParameterNumberMSB(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.NonRegisteredParameterNumberMSB.SetBits(message.Data2);
            OnNonRegisteredParameterNumberMSB.Invoke(message);
        }
        private void onRegisteredParameterNumberLSB(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.RegisteredParameterNumberLSB.SetBits(message.Data2);
            OnRegisteredParameterNumberLSB.Invoke(message);
        }
        private void onRegisteredParameterNumberMSB(MidiMessage message)
        {
            ChannelState[message.Channel].SingleCC.RegisteredParameterNumberMSB.SetBits(message.Data2);
            OnRegisteredParameterNumberMSB.Invoke(message);
        }
    }
}