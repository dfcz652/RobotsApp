using System.Reflection.PortableExecutable;
using RobotApp;
using RobotApp.Equipment;
using RobotApp.Equipment.Arms;
using RobotApp.Equipment.Bodys;
using RobotApp.Equipment.Core;
using RobotApp.Equipment.Legs;
using RobotApp.RobotCharacteristics;
using RobotApp.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        RobotService robotService = new RobotService();
        CompareRobotCharacteristicsService compareRobotCharacteristicsService = new CompareRobotCharacteristicsService();

        var robot1 = new Robot();
        var robot2 = new Robot();
        var defaultEquipRobot = new Robot();

        robot1.AddCore(new EnergeticCore());//Energy - 10, EnergyRestoration - 5
        robot1.AddArms(new RocketArms());//Dmg - 10, EnergyCost - 5, ImpactDistance - 6
        robot1.AddBody(new ArmouredBody());//Hp - 30, Dmg - 3
        robot1.AddLegs(new SpeedLegs());//Speed - 10, Distance - 5

        robot2.AddCore(new LivingCore());//Energy - 8, EnergyRestoration - 4, Hp - 10
        robot2.AddArms(new SpearArms());//Dmg - 12, EnergyCost - 0, ImpactDistance - 6
        robot2.AddBody(new ShieldedBody());//Hp - 10, Shield - 10, ShieldCost - 2
        robot2.AddLegs(new ArmouredLegs());//Speed - 5, Distance - 2, Armor - 3

        var allCharacteristicsOfFirstRobot = robotService.AddAllParts(robot1);
        var allCharacteristicsOfSecondRobot = robotService.AddAllParts(robot2);

        var combinedCharacteristicsOfFirstRobot = robotService.CombineCharacteristics(allCharacteristicsOfFirstRobot);
        var combinedCharacteristicsOfSecondRobot = robotService.CombineCharacteristics(allCharacteristicsOfSecondRobot);

        compareRobotCharacteristicsService.PrintCombinedCharacteristicsForTwoRobots(combinedCharacteristicsOfFirstRobot, combinedCharacteristicsOfSecondRobot);
    }
}