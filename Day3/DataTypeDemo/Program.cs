internal class Program
{
    private static void Main(string[] args)
    {
        //predifined value types and reference types
        byte egbyte1 = 0;
        byte egbyte2 = 255;
        Console.WriteLine($"The minimum value of byte is {egbyte1} and the maximum value is {egbyte2}.");

        sbyte egsbyte1 = -128;
        sbyte egsbyte2 = 127;
        Console.WriteLine($"The minimum value of sbyte is {egsbyte1} and the maximum value is {egsbyte2}.");

        short egshort1 = -32768;
        short egshort2 = 32767;
        Console.WriteLine($"The minimum value of short is {egshort1} and the maximum value is {egshort2}.");

        ushort egushort1 = 0;
        ushort egushort2 = 65535;
        Console.WriteLine($"The minimum value of ushort is {egushort1} and the maximum value is {egushort2}.");

        int egint1 = -2147483648;
        int egint2 = 2147483647;
        Console.WriteLine($"The minimum value of int is {egint1} and the maximum value is {egint2}.");

        //String ke Int :
        string NIK = "123";
        int nik = int.Parse(NIK);
        string NIKK = nik.ToString();
        Console.WriteLine(NIKK);
        //long untuk integer 64bit
    }
}