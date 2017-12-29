using UnityEditor.Animations;
using UnityEngine;

namespace Adnc.AnimatorHelpers.Editors.Testing.Utilities {
    public class AnimatorStub {
        /// <summary>
        /// Reference to the Animator attached to the passed GameObject
        /// </summary>
        public Animator Animator { get; private set; }

        /// <summary>
        /// Reference to an automatically generated AnimatorController
        /// </summary>
        public AnimatorController AnimatorCtrl { get; private set; }

        /// <summary>
        /// Is this a valid AnimatorStub?
        /// </summary>
        public bool IsValid {
            get { return Animator != null && AnimatorCtrl != null; }
        }

        /// <summary>
        /// Inject the animator stub onto a GameObject
        /// </summary>
        /// <param name="target"></param>
        public AnimatorStub (GameObject target = null) {
            if (target == null) {
                target = new GameObject("AnimatorStub");
            }

            Animator = target.AddComponent<Animator>();
            AnimatorCtrl = new AnimatorController {name = "AnimatorDefault"};

            AddLayer("Default");
        }

        /// <summary>
        /// Create new layers on the Animator with a specific name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AnimatorControllerLayer AddLayer (string name) {
            var layer = new AnimatorControllerLayer {
                name = name,
                stateMachine = new AnimatorStateMachine {
                    name = "Default"
                }
            };

            layer.stateMachine.defaultState = layer.stateMachine.AddState("Default");
            AnimatorCtrl.AddLayer(layer);

            return layer;
        }

        /// <summary>
        /// Should be called when you want to inject your AnimatorController into you Animator. WARNING! Once you
        /// do this it creates a static instance of your AnimatorController and you cannot change it.
        /// </summary>
        public void InjectCtrl () {
            Animator.runtimeAnimatorController = AnimatorCtrl;
        }

        void LogError (string error) {
            if (!Application.isPlaying) {
                return;
            }

            Debug.LogError(error);
        }
    }
}
