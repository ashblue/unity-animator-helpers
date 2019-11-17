using Adnc.AnimatorHelpers.Editors.Testing.Utilities;
using Adnc.AnimatorHelpers.HasParameters;
using NUnit.Framework;
using UnityEngine;

namespace Adnc.AnimatorHelpers.Editors.Testing.HasParameters {
    [TestFixture(Category = "HasParameter")]
    public class TestHasParametersExtensions {
        private AnimatorStub _stub;
        private AnimatorHelperRuntime _runtime;

        [SetUp]
        public void Setup () {
            _runtime = new GameObject("AnimatorRuntime").AddComponent<AnimatorHelperRuntime>();
            _stub = new AnimatorStub();

            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "bool",
                type = AnimatorControllerParameterType.Bool
            });

            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "float",
                type = AnimatorControllerParameterType.Float
            });

            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "int",
                type = AnimatorControllerParameterType.Int
            });

            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "trigger",
                type = AnimatorControllerParameterType.Trigger
            });
        }

        [TearDown]
        public void Teardown () {
            Object.DestroyImmediate(_stub.Animator.gameObject);
            _stub = null;

            Object.DestroyImmediate(_runtime.gameObject);
            AnimatorHelperRuntime.ClearSingleton();
            _runtime = null;
        }

        [Test]
        public void HasParameterDoesNotFailOnMultipleIdenticalKeyNames () {
            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "bool",
                type = AnimatorControllerParameterType.Float
            });

            _stub.InjectCtrl();

            Assert.IsTrue(_stub.Animator.HasParameter("bool"));
        }

        [Test]
        public void HasParameterWorksWithPreCaching () {
            _stub.InjectCtrl();
            AnimatorHelperRuntime.Instance.Cache(_stub.Animator);
            var id = _stub.Animator.runtimeAnimatorController.name;

            Assert.IsTrue(AnimatorHelperRuntime.Instance.parameters.HasParameters(id));
            Assert.IsTrue(_stub.Animator.HasParameter("bool"));
        }

        // @TODO Move cahce test onto a AnimatorHelperRuntime testing class
        [Test]
        public void HasParameterGetsTheSameParameterCacheAcrossAnimatorControllers () {
            _stub.InjectCtrl();
            _stub.Animator.HasParameter("bool");

            var clone = Object.Instantiate(_stub.Animator.gameObject).GetComponent<Animator>();
            var id = clone.runtimeAnimatorController.name;

            Assert.IsTrue(AnimatorHelperRuntime.Instance.parameters.HasParameters(id));

            Assert.IsTrue(clone.HasParameter("bool"));

            Object.DestroyImmediate(clone.gameObject);
        }

        [Test]
        public void HasParameterReturnsTrue () {
            _stub.InjectCtrl();

            Assert.IsTrue(_stub.Animator.HasParameter("bool"));
        }

        [Test]
        public void HasParameterReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasParameter("asdf"));
        }

        [Test]
        public void HasParameterEmptyReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasParameter(""));
        }

        [Test]
        public void HasParameterNullReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasParameter(null));
        }

        [Test]
        public void HasBoolReturnsTrue () {
            _stub.InjectCtrl();

            Assert.IsTrue(_stub.Animator.HasBool("bool"));
        }

        [Test]
        public void HasBoolReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasBool("asdf"));
        }

        [Test]
        public void HasBoolEmptyReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasBool(""));
        }

        [Test]
        public void HasBoolNullReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasBool(null));
        }

        [Test]
        public void HasFloatReturnsTrue () {
            _stub.InjectCtrl();

            Assert.IsTrue(_stub.Animator.HasFloat("float"));
        }

        [Test]
        public void HasFloatReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasFloat("asdf"));
        }

        [Test]
        public void HasFloatEmptyReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasFloat(""));
        }

        [Test]
        public void HasFloatNullReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasFloat(null));
        }

        [Test]
        public void HasIntReturnsTrue () {
            _stub.InjectCtrl();

            Assert.IsTrue(_stub.Animator.HasInt("int"));
        }

        [Test]
        public void HasIntReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasInt("asdf"));
        }

        [Test]
        public void HasIntEmptyReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasInt(""));
        }

        [Test]
        public void HasIntNullReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasInt(null));
        }

        [Test]
        public void HasTriggerReturnsTrue () {
            _stub.InjectCtrl();

            Assert.IsTrue(_stub.Animator.HasTrigger("trigger"));
        }

        [Test]
        public void HasTriggerReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasTrigger("asdf"));
        }

        [Test]
        public void HasTriggerEmptyReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasTrigger(""));
        }

        [Test]
        public void HasTriggerNullReturnsFalse () {
            _stub.InjectCtrl();

            Assert.IsFalse(_stub.Animator.HasTrigger(null));
        }
    }
}
