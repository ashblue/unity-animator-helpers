using System.Linq;
using UnityEngine;

namespace Adnc.AnimatorHelpers {
    // @SRC http://wiki.unity3d.com/index.php/Singleton
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        private static T _instance;

        private static string SingletonName {
            get { return typeof(T).Name; }
        }

        public static T Instance {
            get {
                if (_instance != null) {
                    return _instance;
                }

                var instances = FindObjectsOfType(typeof(T));
                if (instances.Length >= 1) {
                    if (Application.isPlaying) {
                        Debug.AssertFormat(
                            instances.Length == 1,
                            "{1} {0} singletons detected. There should only ever be one present",
                            SingletonName,
                            instances.Length);
                    }

                    _instance = (T)instances[0];
                    return _instance;
                }

                var singleton = new GameObject(SingletonName);
                _instance = singleton.AddComponent<T>();

                // Only add DontDestroyOnLoad if the user fails to manually implement the component in a scene
                // Thereby giving the user more control over the singleton lifecycle
                if (Application.isPlaying) {
                    DontDestroyOnLoad(singleton);
                }

                return _instance;
            }
        }

        protected virtual void OnDestroy () {
            if (_instance == this) {
                _instance = null;
            }
        }

        /// <summary>
        /// Test friendly method to prevent persisting singletons with editor tests
        /// </summary>
        public static void ClearSingleton () {
            if (Application.isPlaying || _instance == null) {
                return;
            }

            DestroyImmediate(_instance.gameObject);
            _instance = null;
        }
    }
}