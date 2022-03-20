using System.Collections.Generic;

namespace Dono.Midi
{
    // ## RPN/NRPN (RegisteredParameter / NonRegisterdParamater)
    public class ParameterState
    {
        /// <summary>
        /// 値の設定をRegisteredParameterにするかどうか
        /// </summary>
        public bool IsTargetRegisterdParameter { get; internal set; }
        /// <summary>
        /// MSB:0x00, LSB:0x00
        /// </summary>
        public PitchBendSensitivity PitchBendSensitivity { get; internal set; }
        /// <summary>
        /// MSB:0x00, LSB:0x01
        /// MSB:0x00, LSB:0x02
        /// </summary>
        public MasterTuning MasterTuning { get; internal set; }
        /// <summary>
        /// MSB:0x00, LSB:0x03
        /// </summary>
        public Midi1ByteValue TuningProgram { get; internal set; }
        /// <summary>
        /// MSB:0x00, LSB:0x04
        /// </summary>
        public Midi2ByteValue TuningBank { get; internal set; }

        /// <summary>
        /// NRP
        /// KeyはMidi2ByteValueのBitsを想定
        /// </summary>
        public Dictionary<uint, Midi2ByteValue> NonRegisterdParameter;

        public ParameterState()
        {
            #region ## RPN/NRPN (RegisteredParameter / NonRegisterdParamater)
            IsTargetRegisterdParameter = true;
            PitchBendSensitivity = new PitchBendSensitivity();
            MasterTuning = new MasterTuning();
            TuningProgram = new Midi1ByteValue(false);
            TuningBank = new Midi2ByteValue(false);
            NonRegisterdParameter = new Dictionary<uint, Midi2ByteValue>();
            #endregion
        }
    }
}