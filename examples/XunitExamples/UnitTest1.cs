namespace XunitExamples;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

    }
    [Fact]
    public void TestSampleMethodReturns5()
    {
        var sample = new Sample();
        var result = sample.Method();
        Assert.Equal(5, result);
    }
}

public class Sample
{
    public int Method()
    {
        return 5;
    }
}
