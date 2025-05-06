using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.LegsTypes
{
    public class RechargingLegs : Legs
    {
        public RechargingLegs() : base(5, 2, [new EnergyRestoration(3)])
        {
        }
    }
}
