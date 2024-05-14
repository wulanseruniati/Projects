public static class ExtensionMethod
{   
    //creating extension method for string
    public static void Dump(this string str)
    {
        System.Console.WriteLine(str);
    }
    public static void WriteDump(this string str)
    {
        System.Console.Write(str);
    }

}