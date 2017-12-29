using Adnc.Utility.Testing;
using Adnc.AnimatorHelpers.Editors.Testing.Utilities;
using NUnit.Framework;
using UnityEngine;

namespace Adnc.AnimatorHelpers.Editors.Testing {
    [Category("Examples")]
    public class TestAnimatorStub : TestBase {
        private GameObject _go;
        private AnimatorStub _animStub;

        [SetUp]
        public void Setup () {
            _go = new GameObject("AnimatorStub");
        }

        [TearDown]
        public void Teardown () {
            Object.DestroyImmediate(_go);
        }

        [Test]
        public void DoesNotFailCreationIfNoGameObject () {
            var stub = new AnimatorStub(null);

            Assert.IsTrue(stub.IsValid);
        }

        [Test]
        public void CreatesIfGameObjectPassedIn () {
            var stub = new AnimatorStub(_go);

            Assert.IsTrue(stub.IsValid);
        }

        [Test]
        public void AttachRuntimeController () {
            var stub = new AnimatorStub(_go);

            stub.InjectCtrl();

            Assert.AreSame(stub.Animator.runtimeAnimatorController, stub.AnimatorCtrl);
        }

        [Test]
        public void GetAnimatorParameter () {
            var stub = new AnimatorStub(_go);
            const string param = "test";

            stub.AnimatorCtrl.AddParameter(param, AnimatorControllerParameterType.Bool);
            stub.InjectCtrl();
            var result = stub.Animator.GetBool(param);

            Assert.IsFalse(result);
        }

        [Test]
        public void SetAnimatorParameter () {
            var stub = new AnimatorStub(_go);
            const string param = "test";

            stub.AnimatorCtrl.AddParameter(param, AnimatorControllerParameterType.Bool);
            stub.InjectCtrl();
            stub.Animator.SetBool(param, true);
            var result = stub.Animator.GetBool(param);

            Assert.IsTrue(result);
        }

        [Test]
        public void CreateNewLayerReturnsLayer () {
            var stub = new AnimatorStub(_go);
            var layer = stub.AddLayer("Test");

            Assert.IsNotNull(layer);
        }

        [Test]
        public void CreateNewLayerAddsAnotherLayer () {
            var stub = new AnimatorStub(_go);
            stub.AddLayer("Test");

            Assert.AreEqual(stub.AnimatorCtrl.layers.Length, 2);
        }

        [Test]
        public void CreateNewLayerSetsName () {
            var layerName = "Test";
            var stub = new AnimatorStub(_go);
            var layer = stub.AddLayer(layerName);

            Assert.AreEqual(layerName, layer.name);
        }

        [Test]
        public void CreateNewLayerSetsStateMachine () {
            var stub = new AnimatorStub(_go);
            var layer = stub.AddLayer("Test");

            Assert.IsNotNull(layer.stateMachine);
        }

        [Test]
        public void CreateNewLayerCreatesAtLeastOneState () {
            var stub = new AnimatorStub(_go);
            var layer = stub.AddLayer("Test");

            Assert.IsTrue(layer.stateMachine.states.Length >= 1);
        }

        [Test]
        public void CreateNewLayerSetsDefaultState () {
            var stub = new AnimatorStub(_go);
            var layer = stub.AddLayer("Test");

            Assert.IsNotNull(layer.stateMachine.defaultState);
        }

        [Test]
        public void PlayAdvancesToTheNextState () {
            var stub = new AnimatorStub(_go);
            var layer = stub.AnimatorCtrl.layers[0];
            const string stateName = "New State";
            var state = layer.stateMachine.AddState(stateName);
            var trans = layer.stateMachine.defaultState.AddTransition(state);

            layer.stateMachine.defaultState.AddTransition(state);
            trans.hasExitTime = true;
            stub.InjectCtrl();
            stub.Animator.Update(10);

            var stateInfo = stub.Animator.GetCurrentAnimatorStateInfo(0);
            Assert.IsTrue(stateInfo.IsName(stateName));
        }

        [Test]
        public void RuntimeControllerNameSameAsCreationName () {
            var stub = new AnimatorStub(_go);

            stub.AnimatorCtrl.name = "asdf";
            stub.InjectCtrl();

            Assert.AreEqual(stub.AnimatorCtrl.name, stub.Animator.runtimeAnimatorController.name);
            Assert.AreNotEqual(stub.Animator.gameObject.name, stub.Animator.runtimeAnimatorController.name);
        }
    }
}