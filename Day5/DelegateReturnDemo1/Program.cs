using System.Reflection;
internal class Program
{
    private static void Main(string[] args)
    {
        Subscriber subscriber = new Subscriber();
        MyDelegate del = new MyDelegate(subscriber.Add);
        del += subscriber.Mul;
        //mengecek del apa ada valuenya atau tidak (null) - untuk menghindari exception
        //float? result = del?.Invoke(2, 3);
        float result = del.Invoke(2, 3);
        System.Console.WriteLine(result);

        //mau ambil semua return value
        Delegate[] del1 = del.GetInvocationList();
        foreach (Delegate dg in del1)
        {
            float result1 = ((MyDelegate)dg).Invoke(2, 3);
            System.Console.WriteLine(dg.GetMethodInfo().Name + " : " + result1);
        }
        //my(); -- maaf kurang thread safety
    }
}