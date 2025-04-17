using RobotApp.Robot.RobotCharacteristics;
using RobotApp.Robot.RobotParts;

namespace RobotApp.Robot.RobotEquipment.Cores
{
    public class ProtectiveCore : Core
    {
        public ProtectiveCore() : base(9, 4, [new Shield(5), new ShieldCost(1)])
        {
        }
    }
}
