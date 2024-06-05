using NLog;
using NLog.Config;
class Program {
    public static Logger logger = LogManager.GetCurrentClassLogger();
    static void Main()
    {
        LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");
        logger.Debug("Starting robot");
        Robot robot = new();
        logger.Info("Starting walk");
        robot.Walk();
        logger.Info("Program ended");
    }
}
class Robot {
    public static Logger logger = LogManager.GetCurrentClassLogger();

    public void Walk() {
        LeftLegMove();
        RightLegMove();
        logger.Info("walk one step");
    }
    void LeftLegMove() {
        //process
        logger.Info("left leg move");
    }
    void RightLegMove() {
        //process
        logger.Info("right leg move");
    }
}