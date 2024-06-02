internal class Program
{
    private static void Main(string[] args)
    {
        int[] arrFirst = { 10, 20, 30 };
        int operationModifier = 5;
        int[] arrOut;

        static void OperationStart(ref int[] arrFirst, in int operationModifier, out int[] arrOut)
        {
            
            //out wajib di-inisialisasi
            for(int i=0; i<arrFirst.Length; i++)
            {
                arrFirst[i] += operationModifier;
            }
            //in ga boleh diubah2 - performa bacanya cepet
            arrOut = new int[3];
            for(int i=0; i<arrOut.Length; i++)
            {
                arrOut[i] = arrFirst[i]-operationModifier;
            }
        }
        OperationStart(ref arrFirst, in operationModifier, out arrOut);
        for (int i = 0; i < arrFirst.Length; i++)
        {
            System.Console.WriteLine(arrFirst[i]);
        }

        System.Console.WriteLine(operationModifier);
        for (int i = 0; i < arrOut.Length; i++)
        {
            System.Console.WriteLine(arrOut[i]);
        }
    }
}