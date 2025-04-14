using RobotApp.Robot.RobotEquipment.Arms;
using RobotApp.Robot.RobotEquipment.Bodies;
using RobotApp.Robot.RobotEquipment.Cores;
using RobotApp.Robot.RobotEquipment.Legs;
using RobotApp.Services;
using RobotApp.Robot;

internal class Program
{
    private static void Main(string[] args)
    {
        FightingService robotService = new FightingService();
        CompareRobotCharacteristicsService compareRobotCharacteristicsService = new CompareRobotCharacteristicsService();

        var robot1 = new Robot();
        var robot2 = new Robot();

        robot1.AddCore(new EnergeticCore());//Energy - 10, EnergyRestoration - 5
        robot1.AddArms(new RocketArms());//Dmg - 10, EnergyCost - 5, ImpactDistance - 6
        robot1.AddBody(new ArmouredBody());//Hp - 30, Armor - 4
        robot1.AddLegs(new SpeedLegs());//Speed - 10, Distance - 5

        robot2.AddCore(new LivingCore());//Energy - 8, EnergyRestoration - 4, Hp - 10
        robot2.AddArms(new SpearArms());//Dmg - 12, EnergyCost - 0, ImpactDistance - 6
        robot2.AddBody(new ShieldedBody());//Hp - 10, Shield - 10, ShieldCost - 2
        robot2.AddLegs(new ArmouredLegs());//Speed - 5, Distance - 2, Armor - 3

        compareRobotCharacteristicsService.PrintCombinedCharacteristicsForTwoRobots(robot1.RobotCharacteristics, robot2.RobotCharacteristics);
    }
}
