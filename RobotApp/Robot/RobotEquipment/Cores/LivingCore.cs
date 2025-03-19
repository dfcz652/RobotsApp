using RobotApp.Robot.RobotCharacteristics;
using RobotApp.Robot.RobotParts;

namespace RobotApp.Robot.RobotEquipment.Cores
{
    internal class LivingCore : Core
    {
        public LivingCore() : base(8, 4, [new Hp(10)])
        {
        }
    }
}
