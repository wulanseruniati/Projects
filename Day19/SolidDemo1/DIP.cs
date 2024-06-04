public interface IDevice {
    public void TurnOn();
}
public class LightBulb : IDevice {
    public void TurnOn() {
        //
    }
}
public class Computer : IDevice {
    public void TurnOn() {
        //
    }
}
public class Switch {
    private IDevice _device;
    public Switch(IDevice device)
    {
        _device = device;
    }
    public void Operate()
    {
        _device.TurnOn();
    }
}