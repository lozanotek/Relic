Relic - Simple Cache Manager for .NET
=====

Relic is a simple manager/broker for a caching provider and events associated for a cache.

## Getting Started
To get started with Relic, you'll need to create a RelicManger that's associated with a Cache Provider and Relic Notifier.

```
var cacheProvider = new StaticCacheProvider();
var notifier = new DefaultRelicNotifier();

var manager = new RelicManager(notifier, cacheProvider);
```

Once you have a manager, you can associate different notifiers for add, remove, or exception events.

```
manager.ErrorHandler((item, ex) => Console.WriteLine(ex.Message));
manager.NotifyHandler(CleanConsole);
manager.NotifyHandler(RedConsole);

RelicNotifyHandler awesome = item => Console.WriteLine("I'm awesome.");
manager.NotifyHandler(awesome);


static void CleanConsole(RelicItem item) {
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("{0}:{1}", item.Key, item.Value);
}

static void RedConsole(RelicItem item) {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("{0}:{1}", item.Key, item.Value);
    Console.ForegroundColor = ConsoleColor.White;
}
```
Now you're ready to use the Relic Manager with your application!

```
for (var i = 0; i < 5000; i++) {
    manager.Set(i.ToString(), "value " + i);
}
```

Here's the full sample program

```
class Program {
    static void Main() {
        var manager = GetRelicManager();


        manager.ErrorHandler((item, ex) => Console.WriteLine(ex.Message));
	manager.NotifyHandler(CleanConsole);
	manager.NotifyHandler(RedConsole);
        
	RelicNotifyHandler awesome = item => Console.WriteLine("I'm awesome.");
	manager.NotifyHandler(awesome);

	for (var i = 0; i < 5000; i++) {
	    manager.Set(i.ToString(), "value " + i);
        }

        Console.Write("Press any key to exit...");
        Console.ReadKey(true);
    }

    static IRelicManager GetRelicManager() {
        var cacheProvider = new StaticCacheProvider();
        var notifier = new DefaultRelicNotifier();

        return new RelicManager(notifier, cacheProvider);
    }

    static void CleanConsole(RelicItem item) {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("{0}:{1}", item.Key, item.Value);
    }

    static void RedConsole(RelicItem item) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0}:{1}", item.Key, item.Value);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
```