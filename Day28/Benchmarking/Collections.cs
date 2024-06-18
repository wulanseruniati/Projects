using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class Collections
{
    public int[,] MyArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }; // This creates a 3x3 array with predefined values
    
    public int[][] MyJaggedArray = new int[][]
    {
        new int[] { 1, 2, 3 },
        new int[] { 4, 5, 6 },
        new int[] { 7, 8, 9 }
    };

    public (int, int, int)[] MyTupleArray = {
        (1, 2, 3),
        (4, 5, 6),
        (7, 8, 9)
    };

    [Benchmark]
    public int AccessIntArray()
    {
        return MyArray[1, 1];
    }

    [Benchmark]
    public int AccessJaggedArray()
    {
        return MyJaggedArray[1][1];
    }

    [Benchmark]
    public (int, int, int) AccessTupleArray()
    {
        return MyTupleArray[1];
    }

    [Benchmark]
    public int ForeachIntArray()
    {
        int sum = 0;
        foreach (var item in MyArray)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public int ForeachJaggedArray()
    {
        int sum = 0;
        foreach (var array in MyJaggedArray)
        {
            foreach (var item in array)
            {
                sum += item;
            }
        }
        return sum;
    }

    [Benchmark]
    public int ForeachTupleArray()
    {
        int sum = 0;
        foreach (var tuple in MyTupleArray)
        {
            sum += tuple.Item1 + tuple.Item2 + tuple.Item3;
        }
        return sum;
    }
}