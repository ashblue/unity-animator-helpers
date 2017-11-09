using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorVariables.AnimatorBehaviors {
    /// <summary>
    /// Randomize the current playback position of this state's animation
    /// </summary>
    public class RandomStartTime : StateMachineBehaviour {
        public override void OnStateEnter (Animator anim, AnimatorStateInfo stateInfo, int layerIndex) {
            // Hijack the animation's playback and force it to play at an unknown time
            if (stateInfo.normalizedTime < 0.01f) {
                anim.Play(stateInfo.fullPathHash, layerIndex, Random.Range(0.01f, 1f));
            }
        }
    }
}