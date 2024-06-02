//generic class
public class Student<T1, T2, T3> { 
    //generic field
    public T1? stdName;
    public T1? stdPhoneNum;
    public T2? stdAge;
    public T3? stdHeight;

    //generic method
    public void ShowInformation<T>(T weight) {
        System.Console.WriteLine("Student Name: " + stdName);
        System.Console.WriteLine("Student Phone Number: " + stdPhoneNum);
        System.Console.WriteLine("Student Age: " + stdAge);
        System.Console.WriteLine("Student Height: " + stdHeight);
        System.Console.WriteLine("Student Weight: " + weight);
    }
}