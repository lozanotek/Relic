namespace Relic {
    public interface ICacheProvider {
        void Set(string key, object value);
        object Remove(string key);
        void Clear();
    }
}