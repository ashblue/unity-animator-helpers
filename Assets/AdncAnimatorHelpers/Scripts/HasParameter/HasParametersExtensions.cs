using UnityEngine;

namespace Adnc.AnimatorHelpers.HasParameters {
    public static class HasParametersExtensions {
        private static AnimatorParameters GetAnimatorParameters (Animator animator) {
            var id = animator.runtimeAnimatorController.name;
            var parameters = AnimatorHelperRuntime.Instance.parameters.GetParameters(id, animator);
            return parameters;
        }

        /// <summary>
        /// Checks if this Animator has a parameter with the passed string name
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HasParameter (this Animator animator, string name) {
            if (string.IsNullOrEmpty(name)) {
                return false;
            }

            var parameters = GetAnimatorParameters(animator);

            return parameters.parameters.dic.ContainsKey(name);
        }

        /// <summary>
        /// Checks if this Animator has a bool with the passed string name
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HasBool (this Animator animator, string name) {
            if (string.IsNullOrEmpty(name)) {
                return false;
            }

            var parameters = GetAnimatorParameters(animator);

            return parameters.bools.dic.ContainsKey(name);
        }

        /// <summary>
        /// Checks if this Animator has an int with the passed string name
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HasInt (this Animator animator, string name) {
            if (string.IsNullOrEmpty(name)) {
                return false;
            }

            var parameters = GetAnimatorParameters(animator);

            return parameters.ints.dic.ContainsKey(name);
        }

        /// <summary>
        /// Checks if this Animator has a float with the passed string name
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HasFloat (this Animator animator, string name) {
            if (string.IsNullOrEmpty(name)) {
                return false;
            }

            var parameters = GetAnimatorParameters(animator);

            return parameters.floats.dic.ContainsKey(name);
        }

        /// <summary>
        /// Checks if this Animator has a trigger with the passed string name
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HasTrigger (this Animator animator, string name) {
            if (string.IsNullOrEmpty(name)) {
                return false;
            }

            var parameters = GetAnimatorParameters(animator);

            return parameters.triggers.dic.ContainsKey(name);
        }
    }
}