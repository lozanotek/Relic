namespace Relic {
    using System.Collections.Generic;

    public class StaticCacheProvider : ICacheProvider {
        static readonly IDictionary<string, object> itemTable = new Dictionary<string, object>();

        public void Set(string key, object value) {
            itemTable[key] = value;
        }

        public object Remove(string key) {
            if(!itemTable.ContainsKey(key)) {
                return null;
            }

            var item = itemTable[key];
            itemTable.Remove(key);

            return item;
        }

        public void Clear() {
            itemTable.Clear();
        }
    }
}
