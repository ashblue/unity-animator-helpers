using System;
using UnityEngine;

namespace Adnc.AnimatorHelpers.HasParameters {
    public class AnimatorParameters {
        public readonly Parameters<AnimatorControllerParameter> parameters = new Parameters<AnimatorControllerParameter>();
        public readonly Parameters<bool> bools = new Parameters<bool>();
        public readonly Parameters<int> ints = new Parameters<int>();
        public readonly Parameters<float> floats = new Parameters<float>();
        public readonly Parameters<string> triggers = new Parameters<string>();

        public AnimatorParameters (Animator animator) {
            foreach (var p in animator.parameters) {
                parameters.Add(p.name, p);

                switch (p.type) {
                    case AnimatorControllerParameterType.Float:
                        floats.Add(p.name, p.defaultFloat);
                        break;
                    case AnimatorControllerParameterType.Int:
                        ints.Add(p.name, p.defaultInt);
                        break;
                    case AnimatorControllerParameterType.Bool:
                        bools.Add(p.name, p.defaultBool);
                        break;
                    case AnimatorControllerParameterType.Trigger:
                        triggers.Add(p.name, p.name);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}