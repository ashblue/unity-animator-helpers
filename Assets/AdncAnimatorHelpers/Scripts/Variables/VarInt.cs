using UnityEngine;

namespace Adnc.AnimatorVariables.Variables {
    [System.Serializable]
    public class VarInt : VarBase<int> {
        [Tooltip(VALUE_TOOLTIP)]
        public int value;

        public override void SetValue (Animator animator) {
            animator.SetInteger(name, value);
        }

        public override int GetValue (Animator animator) {
            return animator.GetInteger(name);
        }
    }
}