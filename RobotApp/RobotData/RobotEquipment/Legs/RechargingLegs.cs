using RobotApp.RobotData.RobotCharacteristics;

namespace RobotApp.RobotData.RobotEquipment.Legs
{
    public class RechargingLegs : RobotParts.Legs
    {
        public RechargingLegs() : base(5, 2, [new EnergyRestoration(3)])
        {
        }
    }
}
