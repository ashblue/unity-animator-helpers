using Adnc.AnimatorHelpers.HasParameters;
using UnityEngine;

namespace Adnc.AnimatorHelpers {
    public class AnimatorHelperRuntime : Singleton<AnimatorHelperRuntime> {
        public AnimatorParametersCollection parameters = new AnimatorParametersCollection();

        public void Cache (Animator animator) {
            parameters.SetParameters(animator.runtimeAnimatorController.name, animator);
        }
    }
}