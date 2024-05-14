internal class Program
{    private static void Main(string[] args)
    {
        Func<int, int, int> Addition = AddNumbers;
        System.Console.WriteLine(Addition(2,3));
        Action<int,int> Addition2 = AddNumber;
        Addition2(2,5);        
        //anonymous method
        Func<int,int,int> addFunc2 = delegate(int x, int y) { return x+y; };
        System.Console.WriteLine(addFunc2(3,5));
        //func with lambda
        Func<int> getRandomNumber = () => new Random().Next(1,100);
        System.Console.WriteLine(getRandomNumber());
        //lambda
        Func<int,int,int> addFunc = (x,y) => x+y;
        System.Console.WriteLine(addFunc(1,2));
        //anonymous method
        Action<int,int> printAnonymous = delegate(int x, int y) { System.Console.WriteLine(x+y);};
        printAnonymous(10,12);
        //action with lambda
        Action<int> printAction = (i) => System.Console.WriteLine(i);
        printAction(10);
    }

    static int AddNumbers(int param1, int param2)
    {
        return param1 + param2;
    }

    static void AddNumber(int param1, int param2) {
        System.Console.WriteLine(param1 + param2);
    }
}