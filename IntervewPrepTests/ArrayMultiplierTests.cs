using InterviewPrep;

namespace IntervewPrepTests;

public class ArrayMultiplierTests
{
    [Test]
    public void TestMultiplyByAllRecordsExceptSelf_Example()
    {
        int[] input = { 1, 2, 3, 4 };
        int[] expected = { 24, 12, 8, 6 };
        Assert.AreEqual(expected, ArrayMultiplier.MultiplyByAllRecordsExceptSelf(input));
    }
    
    [Test]
    public void TestMultiplyByAllRecordsExceptSelf_Zeros()
    {
        int[] input = { 0, 1, 2 };
        int[] expected = { 2, 0, 0 };
        Assert.AreEqual(expected, ArrayMultiplier.MultiplyByAllRecordsExceptSelf(input));
    }
    
    [Test]
    public void TestMultiplyByAllRecordsExceptSelf_Negatives()
    {
        int[] input = { -1, 2, -3, 4 };
        int[] expected = { -24, 12, -8, 6 };
        Assert.AreEqual(expected, ArrayMultiplier.MultiplyByAllRecordsExceptSelf(input));
    }
}