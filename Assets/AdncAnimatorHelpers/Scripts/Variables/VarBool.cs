using UnityEngine;

namespace Adnc.AnimatorVariables.Variables {
    [System.Serializable]
    public class VarBool : VarBase<bool> {
        [Tooltip(VALUE_TOOLTIP)]
        public bool value;

        public override void SetValue (Animator animator) {
            animator.SetBool(name, value);
        }

        public override bool GetValue (Animator animator) {
            return animator.GetBool(name);
        }
    }
}