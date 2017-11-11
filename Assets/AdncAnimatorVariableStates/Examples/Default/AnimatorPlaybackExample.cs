using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adnc.AnimatorVariables.Examples {
    public class AnimatorPlaybackExample : MonoBehaviour {
        [SerializeField]
        private AnimatorPlayback _completeEvent;

        [SerializeField]
        private string _completeMessage = "Detected animation playback as complete";

        private void Start () {
            StartCoroutine(DetectEventComplete());
        }

        IEnumerator DetectEventComplete () {
            var anim = GetComponent<Animator>();
            yield return _completeEvent.PlayCoroutine(anim);
            Debug.Log(_completeMessage);
        }
    }
}
