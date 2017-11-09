using System.Collections;
using System.Collections.Generic;
using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorVariables.AnimatorBehaviors {
    /// <summary>
    /// Basic underlying logic for triggering an action
    /// </summary>
    public abstract class AnimatorActionBase : StateMachineBehaviour {
        // Amount of time passed since starting
        private float _timePassed;

        // If update has been trigger with our logic 1x
        private bool _complete;

        // Randomized delay
        private float _delay;

        protected virtual StateMachineBehaviorEvent TriggerEvent {
            get { return StateMachineBehaviorEvent.Enter; }
        }

        protected virtual MinMaxFloat StartDelay {
            get { return new MinMaxFloat(); }
        }

        protected abstract void UpdateLogic (Animator animator, AnimatorStateInfo stateInfo, int layerIndex);

        public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            _timePassed = 0;
            _complete = false;
            _delay = StartDelay.GetRandom();

            if (TriggerEvent == StateMachineBehaviorEvent.Enter && _delay <= 0.01f) {
                UpdateLogic(animator, stateInfo, layerIndex);
                _complete = true;
            }
        }

        public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (_complete || TriggerEvent != StateMachineBehaviorEvent.Enter) {
                return;
            }

            if (_timePassed >= _delay) {
                UpdateLogic(animator, stateInfo, layerIndex);
                _complete = true;
            }

            _timePassed += Time.deltaTime;
        }

        public override void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (TriggerEvent == StateMachineBehaviorEvent.Exit) {
                UpdateLogic(animator, stateInfo, layerIndex);
                _complete = true;
            }
        }
    }
}