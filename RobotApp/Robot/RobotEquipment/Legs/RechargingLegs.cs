using RobotApp.Robot.RobotCharacteristics;

namespace RobotApp.Robot.RobotEquipment.Legs
{
    public class RechargingLegs : RobotParts.Legs
    {
        public RechargingLegs() : base(5, 2, [new EnergyRestoration(3)])
        {
        }
    }
}
