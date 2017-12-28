using UnityEngine;

namespace Adnc.AnimatorHelpers.HasParameters {
    public static class HasParametersExtensions {
        public static bool HasParameter (this Animator animator, string name) {
            var id = animator.runtimeAnimatorController.name;
            var parameters = AnimatorHelperRuntime.Instance.parameters.GetParameters(id, animator);

            return parameters.parameters.dic.ContainsKey(name);
        }

        public static bool HasBool (this Animator animator, string name) {
            var id = animator.runtimeAnimatorController.name;
            var parameters = AnimatorHelperRuntime.Instance.parameters.GetParameters(id, animator);

            return parameters.bools.dic.ContainsKey(name);
        }

        public static bool HasInt (this Animator animator, string name) {
            var id = animator.runtimeAnimatorController.name;
            var parameters = AnimatorHelperRuntime.Instance.parameters.GetParameters(id, animator);

            return parameters.ints.dic.ContainsKey(name);
        }

        public static bool HasFloat (this Animator animator, string name) {
            var id = animator.runtimeAnimatorController.name;
            var parameters = AnimatorHelperRuntime.Instance.parameters.GetParameters(id, animator);

            return parameters.floats.dic.ContainsKey(name);
        }

        public static bool HasTrigger (this Animator animator, string name) {
            var id = animator.runtimeAnimatorController.name;
            var parameters = AnimatorHelperRuntime.Instance.parameters.GetParameters(id, animator);

            return parameters.triggers.dic.ContainsKey(name);
        }
    }
}