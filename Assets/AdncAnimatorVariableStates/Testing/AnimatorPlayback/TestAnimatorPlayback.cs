using System.Collections;
using Adnc.AnimatorVariables.Conditions;
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
        private bool _isPlayCoroutineActive;

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

        [UnityTest]
        public IEnumerator PlayCoroutineWaitsForCondition () {
            yield return new WaitForEndOfFrame();

            _playback.conditions[0].variableType = ConditionVarType.Bool;
            _playback.conditions[0].variableBool = new VarBool {
                name = "bool",
                value = true
            };

            Assert.AreEqual(1, _playback.conditions.Count);
            Assert.IsNotNull(_playback.conditions[0].variableBool.name);

            yield return PlayCoroutineWrapper();

            Assert.IsFalse(_isPlayCoroutineActive);
        }

        IEnumerator PlayCoroutineWrapper () {
            _playback.waitForCondition = true;
            _isPlayCoroutineActive = true;

            var c = _playback.PlayCoroutine(_anim);
            _anim.SetBool("bool", true);

            yield return c;

            _isPlayCoroutineActive = false;
        }
    }
}
