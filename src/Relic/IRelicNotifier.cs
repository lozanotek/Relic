namespace Relic {
    using System;

    public interface IRelicNotifier {
        event RelicNotifyHandler Changed;
        event RelicNotifyHandler Removed;
        event RelicErrorHandler Errored;

        void OnErrored(RelicItem item, Exception exception);
        void OnChanged(RelicItem item);
        void OnRemoved(RelicItem item);
    }
}
