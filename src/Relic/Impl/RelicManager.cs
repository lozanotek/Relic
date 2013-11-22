namespace Relic {
    using System;

    public class RelicManager : IRelicManager {
        public IRelicNotifier Notifier { get; private set; }
        public ICacheProvider Provider { get; private set; }

        public RelicManager()
            : this(new DefaultRelicNotifier(), new StaticCacheProvider()) {
        }

        public RelicManager(IRelicNotifier notifier, ICacheProvider provider) {
            Notifier = notifier;
            Provider = provider;
        }

        public void Set(string key, object value) {
            var item = new RelicItem { Key = key, Value = value };
            try {
                Provider.Set(key, value);
                Notifier.OnChanged(item);
            }
            catch (Exception exception) {
                Notifier.OnErrored(item, exception);
            }
        }

        public void Remove(string key) {
            object value = null;
            try {
                value = Provider.Remove(key);
                Notifier.OnRemoved(new RelicItem { Key = key, Value = value });
            }
            catch (Exception exception) {
                Notifier.OnErrored(new RelicItem { Key = key, Value = value }, exception);
            }
        }
    }
}
