using System.Collections.Generic;

namespace Adnc.AnimatorHelpers.HasParameters {
    public class Parameters<V> {
        public readonly List<KeyValue<V>> list = new List<KeyValue<V>>();
        public readonly Dictionary<string, KeyValue<V>> dic = new Dictionary<string, KeyValue<V>>();

        public void Add (string key, V value) {
            var kv = new KeyValue<V> {
                key = key,
                value = value
            };

            list.Add(kv);
            dic.Add(key, kv);
        }
    }
}