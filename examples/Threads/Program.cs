

var t = new Thread(MyThread);
t.Start();
var t2 = new Thread(MyThread);
t2.Start();
var t3 = new Thread(MyThreadParam);
t3.Start("Thread 3");

t.Join();
t2.Join();
t3.Join();

Console.WriteLine("Main thread finished");

void MyThread()
{
    for (int i = 0; i < 5; i++)
    {
        lock (Console.Out)
        {
            Console.WriteLine("MyThread: " + i);
        }
        Thread.Sleep(1000);
    }
}

void MyThreadParam(object? obj)
{
    var s = obj?.ToString() ?? "unnamed";
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"{s}: " + i);
        Thread.Sleep(1000);
    }
}