using Adnc.AnimatorHelpers.Conditions;
using Adnc.AnimatorHelpers.Variables;
using Adnc.Utility.Testing;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Adnc.AnimatorHelpers.Editors.Testing {
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
            Object.DestroyImmediate(_anim.gameObject);
            _playback = null;
            _anim = null;
        }

        [Test]
        public void StubBoolIsFalse () {
            Assert.IsFalse(_anim.GetBool("bool"));
        }

        [Test]
        public void StubFloatIsZero () {
            Assert.IsTrue(Mathf.Abs(_anim.GetFloat("float")) < 0.1f);
        }

        [Test]
        public void StubIntIsZero () {
            Assert.IsTrue(_anim.GetInteger("int") == 0);
        }

        [Test]
        public void PlaySetsAnimatorBool () {
            _playback.bools.Add(new VarBool {
                name = "bool",
                value = true
            });

            _playback.Play(_anim);

            Assert.IsTrue(_anim.GetBool("bool"));
        }

        [Test]
        public void PlaySetsAnimatorFloat () {
            _playback.floats.Add(new VarFloat {
                name = "float",
                value = 1
            });

            _playback.Play(_anim);

            Assert.AreEqual(_anim.GetFloat("float"), 1);
        }

        [Test]
        public void PlaySetsAnimatorInt () {
            _playback.ints.Add(new VarInt {
                name = "int",
                value = 1
            });

            _playback.Play(_anim);

            Assert.AreEqual(_anim.GetInteger("int"), 1);
        }

        [Test]
        public void IsConditionMetTrueWithNoAnimatorNull () {
            Assert.IsTrue(_playback.IsConditionsMet(null));
        }

        [Test]
        public void IsConditionMetIsTrueWithNoConditions () {
            _playback.conditions.RemoveAt(0);
            Assert.IsTrue(_playback.IsConditionsMet(_anim));
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

            Assert.IsFalse(_playback.IsConditionsMet(_anim));
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

            _anim.SetBool("bool", true);

            Assert.IsTrue(_playback.IsConditionsMet(_anim));
        }
    }
}
