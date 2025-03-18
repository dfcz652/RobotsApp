using RobotApp.RobotCharacteristics;
using RobotApp.RobotParts;

namespace RobotApp.Equipment.Core
{
    internal class ProtectiveCore : CoreBase
    {
        public ProtectiveCore() : base(9, 4, [new Shield(5), new ShieldCost(1)])
        {
        }
    }
}
