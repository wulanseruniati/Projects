using System;
using System.Diagnostics;
using System.Text;
class Program
{
    static void Main()
    {
        StringBuilder text = new();
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 0; i < 1000000; i++)
        {
            text.Append("a");
            text.Append("b");
            text.Append("c");
        }
        stopWatch.Stop();
        System.Console.WriteLine(stopWatch.ElapsedMilliseconds);
    }
}