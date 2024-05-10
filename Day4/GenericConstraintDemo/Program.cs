internal class Program
{
    private static void Main(string[] args)
    {
        // Instantiate Generic Class with Class Constraint
        ConstraintClass<Employee> classEmployee = new ConstraintClass<Employee>();

        // Instantiate Generic Class with Struct Constraint
        ConstraintStruct<int> intClass = new ConstraintStruct<int>();
        intClass.Message = 30;
        intClass.GenericMethod(10, 20);

        //Instantiate Generic Class with new() Constraint
        ConstraintNew<Employee> newEmployee = new ConstraintNew<Employee>();

        //Instantiate Generic Class with baseclass Constraint
        ConstraintBase<BaseEmployee> newBaseEmployee = new ConstraintBase<BaseEmployee>();

        //Instantiate Generic Class with interface Constraint
        ConstraintInterface<Employee> newInterface = new ConstraintInterface<Employee>();

        //Instantiate Generic Class with T:U Constraint
        ConstraintWhere<Employee,IEmployee> newWhere = new ConstraintWhere<Employee,IEmployee>();
        
        //calling an extension method from a static class
        Dump.Cetak("Hei");
    }
}