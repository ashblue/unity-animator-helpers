using System.Reflection;

namespace Adnc.Utility.Testing {
    public class TestBase {
        protected void CallSetup<T> (T target) {
            CallPrivateMethod(target, "Awake");
            CallPrivateMethod(target, "Start");
            CallPrivateMethod(target, "OnEnabled");
        }

        protected void CallDestroy<T> (T target) {
            CallPrivateMethod(target, "OnDisable");
            CallPrivateMethod(target, "OnDestroy");
        }

        protected void CallPrivateMethod<T> (T target, string method) {
            var type = typeof(T);
            var methodInfo = type.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance);

            if (methodInfo != null) {
                methodInfo.Invoke(target, null);
            }
        }

        protected F GetPrivateField<T, F> (T target, string field) {
            var type = typeof(T);
            var f = type.GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);

            if (f != null) {
                return (F)f.GetValue(target);
            }

            return default(F);
        }

        protected void SetPrivateField<T, V> (T target, string field, V value) {
            var type = typeof(T);
            var f = type.GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);

            if (f != null) {
                f.SetValue(target, value);
            }
        }
    }
}
