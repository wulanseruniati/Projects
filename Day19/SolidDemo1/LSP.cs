public class Bird {
    public bool HasWings { get; private set;}
}
public interface IFlyable {
    public void Fly() {
        //
    }
}
public class Ostrict : Bird { 
    //
}
public class Eagle : Bird, IFlyable {
    public void Fly() {
        //
    }
}