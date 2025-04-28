using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.Cores
{
    public class ProtectiveCore : Core
    {
        public ProtectiveCore() : base(9, 4, [new Shield(5), new ShieldCost(1)])
        {
        }
    }
}
