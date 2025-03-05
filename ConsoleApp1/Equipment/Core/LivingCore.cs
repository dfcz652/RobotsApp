using RobotApp.RobotCharacteristics;
using RobotApp.RobotParts;

namespace RobotApp.Equipment.Core
{
    internal class LivingCore : CoreBase
    {
        public LivingCore() : base(8, 4, new List<RobotCharacteristicBase>() { new Hp(10) })
        {
        }
    }
}
