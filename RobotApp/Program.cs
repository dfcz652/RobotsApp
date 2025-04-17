using RobotApp.Robot.RobotEquipment.Arms;
using RobotApp.Robot.RobotEquipment.Bodies;
using RobotApp.Robot.RobotEquipment.Cores;
using RobotApp.Robot.RobotEquipment.Legs;
using RobotApp.Services;
using RobotApp.Robot;

public class Program
{
    private static void Main(string[] args)
    {
        FightingService robotService = new FightingService();
        CompareRobotCharacteristicsService compareRobotCharacteristicsService = new CompareRobotCharacteristicsService();

        var robot1 = new Robot();
        var robot2 = new Robot();

        robot1.AddCore(new EnergeticCore());
        robot1.AddArms(new RocketArms());
        robot1.AddBody(new ArmouredBody());
        robot1.AddLegs(new SpeedLegs());

        robot2.AddCore(new LivingCore());
        robot2.AddArms(new SpearArms());
        robot2.AddBody(new ShieldedBody());
        robot2.AddLegs(new ArmouredLegs());

        compareRobotCharacteristicsService.PrintCombinedCharacteristicsForTwoRobots(robot1.RobotCharacteristics, robot2.RobotCharacteristics);
    }
}
