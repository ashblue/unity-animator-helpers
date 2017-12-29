using Adnc.AnimatorHelpers.Conditions;
using Adnc.AnimatorHelpers.Variables;
using Adnc.Utility.Testing;
using Adnc.AnimatorHelpers.Editors.Testing.Utilities;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Adnc.AnimatorHelpers.Editors.Testing {
    public class TestAnimatorPlayback : TestBase {
        private const string ANIMATOR_STUB_LOC = "AnimatorTesting/AnimatorStub";

        private AnimatorPlayback _playback;
        private AnimatorStub _stub;

        [SetUp]
        public void SetupAnimatorPlayback () {
            _playback = ScriptableObject.CreateInstance<AnimatorPlayback>();

            _stub = new AnimatorStub(new GameObject("AnimatorStub"));
            _stub.AnimatorCtrl.AddParameter("bool", AnimatorControllerParameterType.Bool);
            _stub.AnimatorCtrl.AddParameter("float", AnimatorControllerParameterType.Float);
            _stub.AnimatorCtrl.AddParameter("int", AnimatorControllerParameterType.Int);
            _stub.AnimatorCtrl.AddParameter("trigger", AnimatorControllerParameterType.Trigger);

            _stub.InjectCtrl();
        }

        [TearDown]
        public void TeardownAnimatorPlayback () {
            Object.DestroyImmediate(_stub.Animator.gameObject);
            _playback = null;
            _stub = null;
        }

        [Test]
        public void StubBoolIsFalse () {
            Assert.IsFalse(_stub.Animator.GetBool("bool"));
        }

        [Test]
        public void StubFloatIsZero () {
            Assert.IsTrue(Mathf.Abs(_stub.Animator.GetFloat("float")) < 0.1f);
        }

        [Test]
        public void StubIntIsZero () {
            Assert.IsTrue(_stub.Animator.GetInteger("int") == 0);
        }

        [Test]
        public void PlaySetsAnimatorBool () {
            _playback.bools.Add(new VarBool {
                name = "bool",
                value = true
            });

            _playback.Play(_stub.Animator);

            Assert.IsTrue(_stub.Animator.GetBool("bool"));
        }

        [Test]
        public void PlaySetsAnimatorFloat () {
            _playback.floats.Add(new VarFloat {
                name = "float",
                value = 1
            });

            _playback.Play(_stub.Animator);

            Assert.AreEqual(_stub.Animator.GetFloat("float"), 1);
        }

        [Test]
        public void PlaySetsAnimatorInt () {
            _playback.ints.Add(new VarInt {
                name = "int",
                value = 1
            });

            _playback.Play(_stub.Animator);

            Assert.AreEqual(_stub.Animator.GetInteger("int"), 1);
        }

        [Test]
        public void IsConditionMetTrueWithNoAnimatorNull () {
            Assert.IsTrue(_playback.IsConditionsMet(null));
        }

        [Test]
        public void IsConditionMetIsTrueWithNoConditions () {
            _playback.conditions.RemoveAt(0);
            Assert.IsTrue(_playback.IsConditionsMet(_stub.Animator));
        }

        [Test]
        public void IsConditionMetFalseWhenConditionsNotMet () {
            _playback.conditions.RemoveAt(0);
            _playback.conditions.Add(new Condition {
                compareValues = OperatorAll.AreEqual,
                variableBool = new VarBool {
                    name = "bool",
                    value = true
                },
                variableType = ConditionVarType.Bool
            });

            Assert.IsFalse(_playback.IsConditionsMet(_stub.Animator));
        }

        [Test]
        public void IsConditionMetTrueWhenConditionsAreMet () {
            _playback.conditions.RemoveAt(0);
            _playback.conditions.Add(new Condition {
                compareValues = OperatorAll.AreEqual,
                variableBool = new VarBool {
                    name = "bool",
                    value = true
                },
                variableType = ConditionVarType.Bool
            });

            _stub.Animator.SetBool("bool", true);

            Assert.IsTrue(_playback.IsConditionsMet(_stub.Animator));
        }


    }
}
