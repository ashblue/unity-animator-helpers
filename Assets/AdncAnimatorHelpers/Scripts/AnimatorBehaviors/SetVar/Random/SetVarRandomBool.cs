using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorVariables.AnimatorBehaviors {
    public class SetVarRandomBool : SetVarBase {
        protected override void UpdateLogic (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetBool(_name, Random.value > 0.5f);
        }
    }
}
