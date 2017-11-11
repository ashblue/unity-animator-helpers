using System.Collections;
using Adnc.AnimatorVariables.Variables;
using Adnc.Utility.Testing;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Adnc.AnimatorVariables.Testing {
    public class TestAnimatorPlayback : TestBase {
        private const string ANIMATOR_STUB_LOC = "AnimatorTesting/AnimatorStub";

        private AnimatorPlayback _playback;
        private Animator _anim;

        [SetUp]
        public void SetupAnimatorPlayback () {
            _playback = ScriptableObject.CreateInstance<AnimatorPlayback>();
            var stub = Resources.Load<GameObject>(ANIMATOR_STUB_LOC);
            _anim = Object.Instantiate(stub).GetComponent<Animator>();
        }

        [TearDown]
        public void TeardownAnimatorPlayback () {
            Object.Destroy(_anim.gameObject);
            _playback = null;
            _anim = null;
        }

        [UnityTest]
        public IEnumerator PlaySetsAnimatorTrigger () {
            _playback.triggers.Add(new VarTrigger {
                name = "trigger"
            });

            _playback.Play(_anim);

            yield return new WaitForEndOfFrame();

            Assert.IsFalse(_anim.GetCurrentAnimatorStateInfo(0).IsName("New State"));
        }
    }
}
