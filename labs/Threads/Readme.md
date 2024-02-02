| | |
| --------- | --------------------------- |
| Exercise Folder | Threads |
| Builds On | None |
| Time to complete | 30 minutes

---
1. Add a new console project to your solution named Multitask.
1. Create a class named DirectoryWatcher
1. Use the code below as a starting point - fill in the TODO comments
1. Modify Program.cs to create a DirectoryWatcher - run and while running, add or modify a file in the watched directory  

```C#
public class DirectoryWatcher 
{
    private string _directory;
    private Thread _watcherThread;
    public DirectoryWatcher(string directory) 
    { 
        _directory = directory;
        //TODO create a thread on Run
        //TODO make the thread a daemon
        //TODO start the thread
    }
    public void Run()
    {
        while (true)
        {
            var time = Directory.GetLastWriteTime(_directory);
            var files = Directory.GetFiles(_directory);
            foreach (var f in files)
            {
                Console.WriteLine(f);
            }
            while (time == Directory.GetLastWriteTime(_directory))
                Thread.Sleep(1000);
            Console.WriteLine("\n---------------------\n");
        }
    }
}
```
---
