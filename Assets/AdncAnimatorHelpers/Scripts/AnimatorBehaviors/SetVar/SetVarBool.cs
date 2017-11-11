using UnityEngine;

namespace Adnc.AnimatorHelpers.AnimatorBehaviors {
    public class SetVarBool : SetVarBase {
        [SerializeField]
        private bool _value;

        protected override void UpdateLogic (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetBool(_name, _value);
        }
    }
}