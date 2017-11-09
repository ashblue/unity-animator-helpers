using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorVariables.AnimatorBehaviors {
    public class SetVarRandomInt : SetVarBase {
        [Tooltip("Random value generated each time this state triggers")]
        [SerializeField]
        [MinMaxInt(0, 10)]
        private MinMaxInt _value = new MinMaxInt();

        protected override void UpdateLogic (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetInteger(_name, _value.GetRandom());
        }
    }
}
