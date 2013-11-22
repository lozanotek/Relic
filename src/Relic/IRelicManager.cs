namespace Relic {
    public interface IRelicManager {
        IRelicNotifier Notifier { get; }

        void Set(string key, object value);
        void Remove(string key);
    }
}
