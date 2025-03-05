using RobotApp.RobotCharacteristics;
using RobotApp.RobotParts;

namespace RobotApp.Equipment.Legs
{
    internal class RechargingLegs : LegsBase
    {
        public RechargingLegs() : base(5, 2, new List<RobotCharacteristicBase>() { new EnergyRestoration(3) })
        {
        }
    }
}
