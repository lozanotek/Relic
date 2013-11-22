namespace Relic {
    using System;

    public static class Extensions {
        public static T To<T>(this RelicItem item) {
            if(item == null) {
                return default(T);
            }

            return (T)Convert.ChangeType(item.Value, typeof(T));
        }

        public static void ChangedHandler(this IRelicManager manager, RelicNotifyHandler notifyHandler) {
            if(manager == null) {
                return;
            }

            var notifier = manager.Notifier;
            if(notifier == null) {
                return;
            }

            notifier.Changed += notifyHandler;
        }

		public static void RemovedHandler(this IRelicManager manager, RelicNotifyHandler notifyHandler) {
			if (manager == null) {
				return;
			}

			var notifier = manager.Notifier;
			if (notifier == null) {
				return;
			}

			notifier.Removed += notifyHandler;
		}

        public static void ErrorHandler(this IRelicManager manager, RelicErrorHandler handler) {
            if (manager == null) {
                return;
            }

            var notifier = manager.Notifier;
            if (notifier == null) {
                return;
            }

            notifier.Errored += handler;
        }
    }
}