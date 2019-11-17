using System;
using Adnc.AnimatorHelpers.Editors.Testing.Utilities;
using Adnc.AnimatorHelpers.HasParameters;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Adnc.AnimatorHelpers.Editors.Testing.HasParameters {
    [TestFixture(Category = "HasParameter")]
    public class TestAnimatorParametersCollection {
        private AnimatorParametersCollection _animParCol;
        private AnimatorStub _stub;

        [SetUp]
        public void Setup () {
            _animParCol = new AnimatorParametersCollection();
            _stub = new AnimatorStub();

            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                defaultBool = true,
                name = "a",
                type = AnimatorControllerParameterType.Bool
            });
        }

        [TearDown]
        public void Teardown () {
            Object.DestroyImmediate(_stub.Animator.gameObject);
            _stub = null;
        }

        [Test]
        public void SetParameterReturnsAnimatorParameters () {
            _stub.InjectCtrl();
            var ps = _animParCol.SetParameters("a", _stub.Animator);

            Assert.IsNotNull(ps);
        }

        [Test]
        public void SetParameterStoresCachedAnimator () {
            _stub.InjectCtrl();
            var ps = _animParCol.SetParameters("a", _stub.Animator);
            var psCache = _animParCol.GetParameters("a");

            Assert.AreSame(ps, psCache);
        }

        [Test]
        public void SetAnimatorEmptyStringErrors () {
            Assert.Throws<ArgumentNullException>(() => {
                _animParCol.SetParameters("", _stub.Animator);
            });
        }

        [Test]
        public void SetAnimatorNullStringErrors () {
            Assert.Throws<ArgumentNullException>(() => {
                _animParCol.SetParameters(null, _stub.Animator);
            });
        }

        [Test]
        public void SetAnimatorNullAnimatorErrors () {
            Assert.Throws<ArgumentNullException>(() => {
                _animParCol.SetParameters("a", null);
            });
        }

        [Test]
        public void GetMissingAnimatorParametersReturnsNull () {
            Assert.IsNull(_animParCol.GetParameters("a"));
        }

        [Test]
        public void GetParametersNullReturnsError () {
            Assert.Throws<ArgumentNullException>(() => {
                _animParCol.GetParameters(null);
            });
        }

        [Test]
        public void GetParametersEmptyStringReturnsError () {
            Assert.Throws<ArgumentNullException>(() => {
                _animParCol.GetParameters("");
            });
        }

        [Test]
        public void GetParametersAutoGeneratesCacheIfItDoesNotExist () {
            _stub.InjectCtrl();
            var psCache = _animParCol.GetParameters("a", _stub.Animator);

            Assert.IsNotNull(psCache);
            Assert.IsTrue(_animParCol.HasParameters("a"));
        }

        [Test]
        public void GetParametersDoesNotAutoGenerateCacheIfItExists () {
            _stub.InjectCtrl();
            var ps = _animParCol.SetParameters("a", _stub.Animator);

            Assert.AreSame(ps, _animParCol.GetParameters("a", _stub.Animator));
        }

        [Test]
        public void HasParametersReturnsTrueIfParameters () {
            _stub.InjectCtrl();
            var ps = _animParCol.SetParameters("a", _stub.Animator);

            Assert.IsTrue(_animParCol.HasParameters("a"));
        }

        [Test]
        public void HasParametersReturnsFalseIfNoParameters () {
            Assert.IsFalse(_animParCol.HasParameters("a"));
        }
    }
}
