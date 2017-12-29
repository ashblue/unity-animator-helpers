using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adnc.AnimatorHelpers.Examples {
    public class AnimatorPlaybackExample : MonoBehaviour {
        private Animator anim;

        [SerializeField]
        private AnimatorPlayback _completeEvent;

        [SerializeField]
        private string _completeMessage = "Detected animation playback as complete";

        private void Start () {
            anim = GetComponent<Animator>();

            // To play with a coroutine that waits for the conditions
            StartCoroutine(DetectEventComplete());

            // To play without any coroutine or wait conditions
//            _completeEvent.Play(anim);
        }

        IEnumerator DetectEventComplete () {
            yield return _completeEvent.PlayCoroutine(anim);
            Debug.Log(_completeMessage);
        }
    }
}
