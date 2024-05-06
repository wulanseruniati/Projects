using Hewan;

class Program()
{
    private static void Main(string[] args)
    {
        //create new object of class Bear
        Bear beruang1 = new();

        //run method1
        beruang1.Walking();

        //run method2
        string salam = beruang1.Greetings("Wulan");
        Console.WriteLine(salam);
        
        //set the property of beruang1
        beruang1.weight = 12.5;
        beruang1.height = 105.3;
        beruang1.isWid = false;

        //run method3
        double bmi = beruang1.CalculateBMI();
        Console.WriteLine("BMI beruangnya " + bmi);

        //run method4
        beruang1.Swimming();

        //run method5
        bool terimaMakanan = beruang1.AcceptingFood();
        //deciding the result
        if(terimaMakanan == true)
        {
            Console.WriteLine("Thank you for the food");
        }
        else 
        {
            Console.WriteLine("Ended up eaten by the wild bear. Try again");
        }
    }
}