# Unity Animator Helpers

A micro-framework for changing Unity 3D's Animator parameters with ScriptableObject(s). Designed to make going from
custom scripts to Animator parameters easy. Works with 2D or 3D projects.

## Quick Start Guide

### AnimatorPlayback Objects

How to use an AnimatorPlayback to play animations with variables.

![Preview of Playback Helper](/playback-helper-example.png)

1. Right click in the project window
1. Go to Create -> ADNC -> Animator Variables -> Animator Playback
1. Set your variables and true conditions on the object
1. Attach the object to a MonoBehavior as so `AnimatorPlayback playback;`
1. Call `playback.Play(MY_ANIMATOR);` to trigger the variables.

Example script.

```c#
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
        // _completeEvent.Play(anim);
    }

    IEnumerator DetectEventComplete () {
        yield return _completeEvent.PlayCoroutine(anim);
        Debug.Log(_completeMessage);
    }
}
```

Note that the AnimatorPlayback objects are fully unit and runtime tested
due to their level of complexity.

## Animator Behaviors

There are several animator helper scripts to assist you with Animator Behavior(s).
These are aimed at allowing you to interact with the Animator without having to write
additional scripts to tweak variables and playback.

![Preview of Playback Helper](/animator-helpers.png)

### Available Helpers

Here is a brief list of helpers. New ones will be added as the repo is updated over time.

* SetVarBool
* SetVarRandomBool
* SetVarFloat
* SetVarRandomFloat
* SetVarInt
* SetVarRandomInt
* RandomSpeed
* RandomStartTime
