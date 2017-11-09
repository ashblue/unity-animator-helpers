using UnityEngine;

namespace Adnc.AnimatorVariables.AnimatorBehaviors {
    public class SetVarInt : SetVarBase {
        [SerializeField]
        private int _value;

        protected override void UpdateLogic (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetInteger(_name, _value);
        }
    }
}