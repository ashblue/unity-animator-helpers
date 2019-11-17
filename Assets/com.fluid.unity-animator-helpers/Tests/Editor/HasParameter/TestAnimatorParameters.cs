using System;
using Adnc.AnimatorHelpers.Editors.Testing.Utilities;
using Adnc.AnimatorHelpers.HasParameters;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Adnc.AnimatorHelpers.Editors.Testing.HasParameters {
    [TestFixture(Category = "HasParameter")]
    public class TestAnimatorParameters {
        private AnimatorStub _stub;

        [SetUp]
        public void Setup () {
            _stub = new AnimatorStub();
        }

        [TearDown]
        public void Teardown () {
            Object.DestroyImmediate(_stub.Animator.gameObject);
            _stub = null;
        }

        [Test]
        public void ErrorsOnNullAnimatorConstructor () {
            Assert.Throws<ArgumentNullException>(() => { new AnimatorParameters(null); });
        }

        [Test]
        public void DoesNotCrashOnNullAnimatorParameters () {
            _stub.InjectCtrl();
            var par = new AnimatorParameters(_stub.Animator);
        }

        [Test]
        public void StoresAllParameters () {
            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "a",
                defaultBool = true,
                type = AnimatorControllerParameterType.Bool
            });

            _stub.InjectCtrl();
            var par = new AnimatorParameters(_stub.Animator);

            Assert.IsTrue(par.parameters.dic.ContainsKey("a"));
        }

        [Test]
        public void StoresAllBools () {
            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "a",
                defaultBool = true,
                type = AnimatorControllerParameterType.Bool
            });

            _stub.InjectCtrl();
            var par = new AnimatorParameters(_stub.Animator);

            Assert.IsTrue(par.bools.dic.ContainsKey("a"));
        }

        [Test]
        public void StoresAllFloats () {
            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "a",
                defaultFloat = 1,
                type = AnimatorControllerParameterType.Float
            });

            _stub.InjectCtrl();
            var par = new AnimatorParameters(_stub.Animator);

            Assert.IsTrue(par.floats.dic.ContainsKey("a"));
        }

        [Test]
        public void StoresAllInts () {
            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "a",
                defaultInt = 1,
                type = AnimatorControllerParameterType.Int
            });

            _stub.InjectCtrl();
            var par = new AnimatorParameters(_stub.Animator);

            Assert.IsTrue(par.ints.dic.ContainsKey("a"));
        }

        [Test]
        public void StoresAllTriggers () {
            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "a",
                type = AnimatorControllerParameterType.Trigger
            });

            _stub.InjectCtrl();
            var par = new AnimatorParameters(_stub.Animator);

            Assert.IsTrue(par.triggers.dic.ContainsKey("a"));
        }
    }
}
