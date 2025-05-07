using RobotApp.RobotData.RobotEquipment.ArmsTypes;
using RobotApp.RobotData.RobotEquipment.BodyTypes;
using RobotApp.RobotData.RobotEquipment.CoreTypes;
using RobotApp.RobotData.RobotEquipment.LegsTypes;
using RobotApp.Services;
using RobotApp.RobotData;
using RobotApp.Services.Interfaces;
using RobotApp.Services.Formatters;
using RobotApp.Services.Reports;

public class Program
{
    private static void Main(string[] args)
    {
        IRobotsComparisonFormatter comparisonFormatter = new ReportFormatter();
        FightingService robotService = new();
        CompareRobotCharacteristicsService compareRobotCharacteristicsService = new();

        Robot robot1 = new("BF20");
        Robot robot2 = new("GT99");

        robot1.AddCore(new EnergeticCore());
        robot1.AddArms(new RocketArms());
        robot1.AddBody(new ArmouredBody());
        robot1.AddLegs(new SpeedLegs());

        robot2.AddCore(new LivingCore());
        robot2.AddArms(new SpearArms());
        robot2.AddBody(new ShieldedBody());
        robot2.AddLegs(new ArmouredLegs());

        RobotComparisonReport report = compareRobotCharacteristicsService.CreateRobotComparisonReport(robot1, robot2);

        Console.WriteLine(comparisonFormatter.Format(report));
    }
}
