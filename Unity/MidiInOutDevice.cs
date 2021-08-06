using Dono.MidiUtilities.Runtime;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Dono.MidiUtilities.UnityDevice
{
    public abstract class MidiInOutDevice : MonoBehaviour, IObserver<MidiMessage>
    {
        [SerializeField] private List<IObserver<MidiMessage>> MidiOutPort;

        private Subject<MidiMessage> subject;

        private void Start()
        {
            if (MidiOutPort != null)
            {
                for (int i = 0; i < MidiOutPort.Count; i++)
                {
                    subject.Subscribe(MidiOutPort[i]);
                }
            }
        }

        public void OnNext(MidiMessage value) => subject.OnNext(value);
        public void OnCompleted() => subject.OnCompleted();
        public void OnError(Exception error) => subject.OnError(error);
    }
}