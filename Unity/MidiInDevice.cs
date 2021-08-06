using Dono.MidiUtilities.Runtime;
using System;
using UniRx;
using UnityEngine;

namespace Dono.MidiUtilities.UnityDevice
{
    public abstract class MidiInDevice : MonoBehaviour, IObserver<MidiMessage>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(MidiMessage value)
        {
        }
    }
}