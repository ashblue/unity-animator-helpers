using UnityEngine;

namespace Adnc.AnimatorHelpers.AnimatorBehaviors {
    public class SetVarFloat : SetVarBase {
        [SerializeField]
        private float _value;

        protected override void UpdateLogic (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetFloat(_name, _value);
        }
    }
}