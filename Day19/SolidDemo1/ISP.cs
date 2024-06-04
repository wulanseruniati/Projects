public interface IWorkable {
    public void Work();
}
public interface IEatable {
    public void Eat();
}
//jgn semua method masuk satu interface, ga semua butuh
public class Worker : IWorkable, IEatable {
    public void Work() {
        //
    }
    public void Eat() {
        //
    }
}
public class Robot : IWorkable {
    public void Work() {
        //
    }
}