using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorHelpers.AnimatorBehaviors {
    public abstract class SetVarBase : AnimatorActionBase {
        [Tooltip("When to trigger the event during the state's cycle")]
        [SerializeField]
        private StateMachineBehaviorEvent _event = StateMachineBehaviorEvent.Enter;

        protected override StateMachineBehaviorEvent TriggerEvent {
            get { return _event; }
        }

        [Tooltip("Delay before firing. Only triggered if the event type is Enter")]
        [SerializeField]
        [MinMaxFloat(0, 5)] private MinMaxFloat _startDelay = new MinMaxFloat { min = 0, max = 0 };

        protected override MinMaxFloat StartDelay {
            get { return _startDelay; }
        }

        [Header("Variable")]

        [Tooltip("Name of the variable")]
        [SerializeField]
        protected string _name;
    }
}