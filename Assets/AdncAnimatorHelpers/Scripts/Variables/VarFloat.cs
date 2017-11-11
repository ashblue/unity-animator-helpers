using UnityEngine;

namespace Adnc.AnimatorVariables.Variables {
    [System.Serializable]
    public class VarFloat : VarBase<float> {
        [Tooltip(VALUE_TOOLTIP)]
        public float value;

        public override void SetValue (Animator animator) {
            animator.SetFloat(name, value);
        }

        public override float GetValue (Animator animator) {
            return animator.GetFloat(name);
        }
    }
}