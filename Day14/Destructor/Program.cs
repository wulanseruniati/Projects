class Car {
    public Car() {
        System.Console.WriteLine("Constructor");
    }
    ~Car() {
        System.Console.WriteLine("Destructor");
    }
}
class Program
{
    static void Main()
    {
        //Car car = new();
        InstanceCreator();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        System.Console.WriteLine("Wait for the next order");
    }

    static void InstanceCreator() {
        //hapus
        Child child = new();
    }
}
public class GrandParent {
    ~GrandParent() {
        System.Console.WriteLine("Grandparent eliminated");
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }
}
public class Parent : GrandParent {
    ~Parent() {
        System.Console.WriteLine("Parent eliminated");
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }
}
public class Child : Parent {
    ~Child() {
        System.Console.WriteLine("Child eliminated");
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }
}
