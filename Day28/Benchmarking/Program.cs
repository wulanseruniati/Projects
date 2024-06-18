using BenchmarkDotNet.Running;

class Program
{
    static void Main()
    {
        //BenchmarkRunner.Run<StringVsStringBuilder>();       
        BenchmarkRunner.Run<Collections>();        
    }
}