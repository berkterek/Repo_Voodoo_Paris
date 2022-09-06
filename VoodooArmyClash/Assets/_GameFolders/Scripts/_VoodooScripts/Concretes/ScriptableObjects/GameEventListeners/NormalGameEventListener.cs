﻿using Voodoo.Abstracts.GameEventListeners;

namespace Voodoo.ScriptableObjects.GameEventListeners
{
    public class NormalGameEventListener : BaseGameEventListener
    {
        public event System.Action NoParameterEvent;
        public event System.Action<object> ParameterEventWithObject;

        public override void Notify()
        {
            NoParameterEvent?.Invoke();
        }

        public override void Notify(object value)
        {
            ParameterEventWithObject?.Invoke(value);
        }
    }
}