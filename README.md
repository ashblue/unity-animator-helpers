# Unity Animator Helpers

Ever had to handle complex animations that require multiple frames such as jump, attack, or receiving damage? Generally this results in messy Animator variables and repeated code. Unity Animator Helpers provides a micro-framework to create modular animations that can be visually programmed and modularly shared between GameObjects.

* Create animator variable changes from a ScriptableObject with visual programming
* Share animator playback variable changes between GameObject(s)
* Wait for multiple animator variable changes from a coroutine or loop
* Pre-made library of common Animator Behaviors for visually programming the Animator with variable changes and randomization  

## Quickstart

### AnimatorPlayback Objects

How to use the `AnimatorPlayback` object to play animations with variables.

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

#### Features
   
   * AnimatorPlayback objects to easily detect animation completion conditions
   * Pre-built library on AnimatorBehavior(s) for complex animation playback
   * Animator extensions that add missing functionality to Unity's Animator component
   * Animator unit testing helper (for editor only tests)
   * Unit tested

### Installation

Unity Animator Helpers is used through [Unity's Package Manager](https://docs.unity3d.com/Manual/CustomPackages.html). In order to use it you'll need to add the following lines to your `Packages/manifest.json` file. After that you'll be able to visually control what specific version of Unity Animator Helpers you're using from the package manager window in Unity. This has to be done so your Unity editor can connect to NPM's package registry.

```json
{
  "scopedRegistries": [
    {
      "name": "NPM",
      "url": "https://registry.npmjs.org",
      "scopes": [
        "com.fluid"
      ]
    }
  ],
  "dependencies": {
    "com.fluid.unity-animator-helpers": "2.0.0"
  }
}
```

### Releases

Archives of specific versions and release notes are available on the [releases page](https://github.com/ashblue/unity-animator-helpers/releases).

#### Nightly Builds

To access nightly builds of the `develop` branch that are package manager friendly, you'll need to manually edit your `Packages/manifest.json` as so. 

```json
{
    "dependencies": {
      "com.fluid.unity-animator-helpers": "https://github.com/ashblue/unity-animator-helpers.git#nightly"
    }
}
```

Note that to get a newer nightly build you must delete this line and any related lock data in the manifest, let Unity rebuild, then add it back. As Unity locks the commit hash for Git urls as packages.

### Development Environment

If you wish to run to run the development environment you'll need to install the latest [node.js](https://nodejs.org/en/). Then run the following from the root once.

`npm install`

If you wish to create a build run `npm run build` from the root and it will populate the `dist` folder.

#### Making Commits

All commits should be made using [Commitizen](https://github.com/commitizen/cz-cli) (which is automatically installed when running `npm install`). Commits are automatically compiled to version numbers on release so this is very important. PRs that don't have Commitizen based commits will be rejected.

To make a commit type the following into a terminal from the root

```bash
npm run commit
```

## Other Helper Libraries

### Animator Behaviors

There are several animator helper scripts to assist you with Animator Behavior(s).
These are aimed at allowing you to interact with the Animator without having to write
additional scripts to tweak variables and playback.

![Preview of Playback Helper](/animator-helpers.png)

#### Available Helpers

Here is a brief list of helpers. New ones will be added as the repo is updated over time.

* SetVarBool
* SetVarRandomBool
* SetVarFloat
* SetVarRandomFloat
* SetVarInt
* SetVarRandomInt
* RandomSpeed
* RandomStartTime

See documentation on methods (in code) for complete details.

### Animator Extensions

Unity Animator Helpers extends the pre-existing functionality of Unity3D's built in `Animator` component with static
extensions. This doesn't hurt or break any existing functionality. For example you could do the following to check if 
you have a particular bool parameter.

```c#
public class AnimatorExtensionExample : MonoBehaviour {
    private Animator anim;
    
    public string hasAnimatorBool = "myBool";
    
    private void Start () {
        anim = GetComponent<Animator>();
        
        Debug.LogFormat("Animator has bool {0}: {1}", hasAnimatorBool, anim.HasBool(hasAnimatorBool));
    }
}
``` 

#### Available Animator extensions

* HasParameter(name)
* HasBool(name)
* HasFloat(name)
* HasInt(name)
* HasTrigger(name)

See documentation on methods (in code) for complete details.

### Extension Caching 
Animator extensions perform some caching to make lookups instant. This only happens on the first extension
call per unique `AnimatorController`. While this generally shouldn't cause performance problems and is almost instant. 
You may need to call `AnimatorHelperRuntime.Instance.Cache(Animator)` on `Start` or `Awake` if your `Animator(s)` 
have over 300 parameters. Please note that your `AnimatorController` object (what you pass into the Animator via 
inspector) must be uniquely named in order for the caching to work correctly.

### Animator Unit Test Helper

This library provides an `AnimatorStub` (editor only) class that makes testing animations via pure code super simple.
All you need to do is the following.

```c#
using Adnc.AnimatorHelpers.Editors.Testing.Utilities;
using NUnit.Framework;
using UnityEngine;

public class TestAnimatorStub {
    private AnimatorStub _stub;
    
    [SetUp]
    public void Setup () {
        _stub = new AnimatorStub();
    }

    [TearDown]
    public void Teardown () {
        // The stub is attached to a GameObject, so it must be destroyed manually
        Object.DestroyImmediate(_stub.Animator.gameObject);
    }
    
    [Test]
    public void MyTest () {
        // Setup your AnimatorController as desired
        stub.AnimatorCtrl.AddParameter("myBool", AnimatorControllerParameterType.Bool);
        
        // Inject a runtime version of the AnimatorController with all of your settings
        stub.InjectCtrl();
        
        // Test as normal
        // stub.Animator.Update(10); // If you need to simulate time
        Assert.IsTrue(stub.Animator.HasBool("myBool));
    }
}
```

---

This project was generated with [Oyster Package Generator](https://github.com/ashblue/oyster-package-generator).
