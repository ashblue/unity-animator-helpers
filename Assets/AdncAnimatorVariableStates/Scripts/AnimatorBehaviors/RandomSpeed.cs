using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorVariables.AnimatorBehaviors {
    public class RandomSpeed : StateMachineBehaviour {
        private float startSpeed;

        [InfoBox("Randomize the current playback speed of the animator")]

        [Tooltip("Randomize speed range")]
        [MinMaxFloat(0, 10)]
        [SerializeField]
        private MinMaxFloat playbackSpeed = new MinMaxFloat {min = 1, max = 1};

        [Tooltip("On exiting state repair the speed")]
        [SerializeField]
        private bool restoreSpeedOnExit = true;

        // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
        public override void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex) {
            startSpeed = anim.speed;
            anim.speed = playbackSpeed.GetRandom();
        }

        public override void OnStateExit (Animator anim, AnimatorStateInfo stateInfo, int layerIndex) {
            if (restoreSpeedOnExit) {
                anim.speed = startSpeed;
            }
        }
    }
}