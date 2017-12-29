using Adnc.AnimatorHelpers.HasParameters;
using UnityEngine;
using Adnc.Utility.Singletons;

namespace Adnc.AnimatorHelpers {
    public class AnimatorHelperRuntime : SingletonBase<AnimatorHelperRuntime> {
        public AnimatorParametersCollection parameters = new AnimatorParametersCollection();

        public void Cache (Animator animator) {
            parameters.SetParameters(animator.runtimeAnimatorController.name, animator);
        }
    }
}