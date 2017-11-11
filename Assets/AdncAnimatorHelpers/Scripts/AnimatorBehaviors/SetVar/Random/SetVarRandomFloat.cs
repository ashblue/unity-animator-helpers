using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorHelpers.AnimatorBehaviors {
    public class SetVarRandomFloat : SetVarBase {
        [Tooltip("Random value generated each time this state triggers")]
        [SerializeField]
        [MinMaxFloat(0, 10)]
        private MinMaxFloat _value = new MinMaxFloat();

        protected override void UpdateLogic (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetFloat(_name, _value.GetRandom());
        }
    }
}
