using RobotApp.RobotData.RobotEquipment.Arms;
using RobotApp.RobotData.RobotEquipment.Bodies;
using RobotApp.RobotData.RobotEquipment.Cores;
using RobotApp.RobotData.RobotEquipment.Legs;
using RobotApp.Services;
using RobotApp.RobotData;

public class Program
{
    private static void Main(string[] args)
    {
        IRobotsComparisonFormatter comparisonFormatter = new ReportFormatter();
        FightingService robotService = new();
        CompareRobotCharacteristicsService compareRobotCharacteristicsService = new();

        Robot robot1 = new();
        Robot robot2 = new();

        robot1.AddName("BF20");
        robot1.AddCore(new EnergeticCore());
        robot1.AddArms(new RocketArms());
        robot1.AddBody(new ArmouredBody());
        robot1.AddLegs(new SpeedLegs());

        robot2.AddName("GT99");
        robot2.AddCore(new LivingCore());
        robot2.AddArms(new SpearArms());
        robot2.AddBody(new ShieldedBody());
        robot2.AddLegs(new ArmouredLegs());

        RobotComparisonReport report = compareRobotCharacteristicsService.CreateComparingReportForTwoRobots(robot1, robot2);

        Console.WriteLine(comparisonFormatter.Format(report));
    }
}
