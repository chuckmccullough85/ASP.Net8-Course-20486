using MyTuple = (int x, int y);
using MyAlias = MyClass;

var t = new MyTuple(1, 2);
var m = new MyAlias();



var pc = new PrimaryCtor("PrimaryCtor");
Console.WriteLine(pc);




class MyClass {}

class PrimaryCtor (string name)
{
    public override string ToString() => $"Name: {name}";
}