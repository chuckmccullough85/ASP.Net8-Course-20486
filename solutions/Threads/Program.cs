

using Threads;

var t = new DirectoryWatcher(@"c:\development");

Console.WriteLine("Press Enter to stop watching");
Console.ReadLine();