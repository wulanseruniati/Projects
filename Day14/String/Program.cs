using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string text = String.Empty;
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 0; i < 100000; i++)
        {
            text += "a";
            text += "b";
            text = text.Replace('a','c');
        }
        stopWatch.Stop();
        System.Console.WriteLine(stopWatch.ElapsedMilliseconds);
    }
}