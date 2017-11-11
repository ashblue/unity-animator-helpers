using UnityEngine;

namespace Adnc.AnimatorVariables.Variables {
    [System.Serializable]
    public class VarTrigger : VarBase<bool> {
        public override void SetValue (Animator animator) {
            animator.SetTrigger(name);
        }

        public override bool GetValue (Animator animator) {
            // Always returns true since the trigger doesn't have a value
            return true;
        }
    }
}