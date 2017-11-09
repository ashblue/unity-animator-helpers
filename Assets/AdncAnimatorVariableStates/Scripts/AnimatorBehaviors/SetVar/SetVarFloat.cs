using UnityEngine;

namespace Adnc.AnimatorVariables.AnimatorBehaviors {
    public class SetVarFloat : SetVarBase {
        [SerializeField]
        private float _value;

        protected override void UpdateLogic (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetFloat(_name, _value);
        }
    }
}