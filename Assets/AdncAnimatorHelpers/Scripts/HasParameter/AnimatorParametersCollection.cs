using System.Collections.Generic;
using UnityEngine;

namespace Adnc.AnimatorHelpers.HasParameters {
    public class AnimatorParametersCollection {
        private Dictionary<string, AnimatorParameters> _dic = new Dictionary<string, AnimatorParameters>();

        public AnimatorParameters SetParameters (string id, Animator animator) {
            var ap = new AnimatorParameters(animator);
            _dic.Add(id, ap);

            return ap;
        }

        public AnimatorParameters GetParameters (string id) {
            AnimatorParameters result;
            _dic.TryGetValue(id, out result);

            return result;
        }

        public AnimatorParameters GetParameters (string id, Animator setOnEmpty) {
            var result = GetParameters(id);
            if (result == null) {
                result = SetParameters(id, setOnEmpty);
            }

            return result;
        }

        public bool HasParameters (string id) {
            return _dic.ContainsKey(id);
        }
    }
}