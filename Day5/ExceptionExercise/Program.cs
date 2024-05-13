public static class Program
{
    public static void Main()
    {
        try {
            ExceptionMaker();
        }
        catch (DivideByZeroException e1) {
            System.Console.WriteLine(e1.Message);
        }
        catch (FormatException e2) {
            System.Console.WriteLine(e2.Message);
        }
        catch (Exception e) {
            System.Console.WriteLine(e.Message);
        }
        finally {
            System.Console.WriteLine("Finally!");
        }
        //kedua
        try {
            ExceptionMaker2();
        }
        catch (DivideByZeroException e1) {
            System.Console.WriteLine(e1.Message);
        }
        catch (FormatException e2) {
            System.Console.WriteLine(e2.Message);
        }
        catch (Exception e) {
            System.Console.WriteLine(e.Message);
        }
        //kedua
        try {
            ExceptionMaker3();
        }
        catch (DivideByZeroException e1) {
            System.Console.WriteLine(e1.Message);
        }
        catch (FormatException e2) {
            System.Console.WriteLine(e2.Message);
        }
        catch (Exception e) {
            System.Console.WriteLine(e.Message);
        }
    }

    public static void ExceptionMaker() {
        int x = 10, y = 0;
        System.Console.WriteLine(x/y);
    }

    public static void ExceptionMaker2() {
        string a = "naa27";
        int intA = int.Parse(a);
    }

    public static void ExceptionMaker3() {
        bool flag = true;
        char ch = Convert.ToChar(flag);
    }
}