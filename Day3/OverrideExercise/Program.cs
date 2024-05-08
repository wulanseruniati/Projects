internal class Program
{
    private static void Main(string[] args)
    {
        //create new object of class employee
        Employee employee = new Employee() { name = "Wulan", height = 160 };
        employee.Walking();
        //calling override method
        double employeeWeight = employee.PredictWeight(2000.0d);
        Console.WriteLine("Your predicted weight is : " + employeeWeight);
        //implicit conversion
        ((Person)employee).Walking();

        //create new object person of class student
        Person student = new Student() { height = 100 };
        //even though the student is of Person type, but calling the overriden method
        student.Walking();
        double studentWeight = student.PredictWeight(1500.0d);
        Console.WriteLine("Your predicted weight is : " + studentWeight);

        Pensioner pensioner = new Pensioner();
        pensioner.CountingMoney();
        //calling the parent's method

        //below would generate error
        //Student person = new Person();
    }
}
