namespace Relic {
    using System;

    public class DefaultRelicNotifier : IRelicNotifier {
        public event RelicNotifyHandler Changed;
        public event RelicNotifyHandler Removed;
        public event RelicErrorHandler Errored;

        public void OnErrored(RelicItem item, Exception exception) {
            var tempHandler = Errored;
            if (tempHandler == null) {
                return;
            }

            var handlerList = tempHandler.GetInvocationList();
            foreach (RelicErrorHandler handler in handlerList) {
                try {
                    handler.BeginInvoke(item, exception, null, this);
                }
                catch {
                }
            }
        }

        public void OnChanged(RelicItem item) {
            ExecuteHandlers(item, Changed);
        }

        public void OnRemoved(RelicItem item) {
            ExecuteHandlers(item, Removed);
        }

        private void ExecuteHandlers(RelicItem item, RelicNotifyHandler tempNotifyHandler) {
            if (tempNotifyHandler == null) {
                return;
            }

            var handlerList = tempNotifyHandler.GetInvocationList();
            foreach (RelicNotifyHandler handler in handlerList) {
                try {
                    handler(item);
                }
                catch (Exception exception) {
                    OnErrored(item, exception);
                }
            }
        }
    }
}