using Adnc.Utility.Testing;
using Adnc.AnimatorHelpers.Stubs;
using NUnit.Framework;
using UnityEngine;

namespace Adnc.AnimatorHelpers.Editors.Testing {
    public class TestSingleton : TestBase {
        [TearDown]
        public void ClearSingleton () {
            SingletonStub.ClearSingleton();
        }

        [Test]
        public void InstanceLazyLoadsWhenCalled () {
            Assert.IsNotNull(SingletonStub.Instance);
        }

        [Test]
        public void SingletonAlwaysReturnsSameInstance () {
            var i = SingletonStub.Instance;

            Assert.AreSame(i, SingletonStub.Instance);
        }

        [Test]
        public void InstanceIsAutoInjectedIfComponentAlreadyExists () {
            var stub = new GameObject("ForceLoad")
                .AddComponent<SingletonStub>();

            Assert.AreEqual(stub, SingletonStub.Instance);

            Object.DestroyImmediate(stub.gameObject);
        }

        [Test]
        public void PreMadeSingletonReturnsSameInstance () {
            var stub = new GameObject("ForceLoad")
                .AddComponent<SingletonStub>();
            var i = SingletonStub.Instance;

            Assert.AreSame(i, SingletonStub.Instance);

            Object.DestroyImmediate(stub.gameObject);
        }

        [Test]
        public void MultipleInstancesStillReturnsInstance () {
            var stub1 = new GameObject("ForceLoad1")
                .AddComponent<SingletonStub>();
            var stub2 = new GameObject("ForceLoad2")
                .AddComponent<SingletonStub>();

            Assert.IsNotNull(SingletonStub.Instance);

            Object.DestroyImmediate(stub1.gameObject);
            Object.DestroyImmediate(stub2.gameObject);
        }

        [Test]
        public void InstancePropertiesCanBeChangesGlobally () {
            var prop1 = SingletonStub.Instance.globalString;
            SingletonStub.Instance.globalString = "a";
            var prop2 = SingletonStub.Instance.globalString;

            Assert.AreNotEqual(prop1, prop2);
        }

        [Test]
        public void ClearSingletonWipesInstance () {
            var i = SingletonStub.Instance;

            SingletonStub.ClearSingleton();

            Assert.AreNotSame(i, SingletonStub.Instance);
        }

        [Test]
        public void OnDestroyClearsInstance () {
            var i = SingletonStub.Instance;

            CallPrivateMethod(SingletonStub.Instance, "OnDestroy");
            Object.DestroyImmediate(i.gameObject);

            Assert.AreNotSame(i, SingletonStub.Instance);
        }

        [Test]
        public void OnDestroySecondInstanceDoesNotClearInstance () {
            var stub1 = new GameObject("ForceLoad1")
                .AddComponent<SingletonStub>();
            SingletonStub.Instance.globalString = "changeToCache";
            var stub2 = new GameObject("ForceLoad2")
                .AddComponent<SingletonStub>();

            CallPrivateMethod(stub2, "OnDestroy");
            Object.DestroyImmediate(stub2.gameObject);

            Assert.AreSame(stub1, SingletonStub.Instance);

            Object.DestroyImmediate(stub1.gameObject);
        }

        [Test]
        public void LazyLoadSingletonNameMatchesComponentName () {
            Assert.AreEqual("SingletonStub", SingletonStub.Instance.name);
        }
    }
}