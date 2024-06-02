internal class Program
{
    private static void Main(string[] args)
    {
        //create new object of class employee
        Employee employee = new Employee() { name = "Wulan" };
        employee.Walking();

        //create new object person of class student
        Person student = new Student();
        student.Walking();

        //create new object student of class student
        Student student2 = new Student();
        student2.Walking();

        Pensioner pensioner = new Pensioner();
        pensioner.CountingMoney();

        //below would generate error
        //Student person = new Person();
    }
}
