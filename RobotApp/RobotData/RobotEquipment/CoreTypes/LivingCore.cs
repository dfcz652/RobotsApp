using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.CoreTypes
{
    public class LivingCore : Core
    {
        public LivingCore() : base(8, 4, [new Hp(10)])
        {
        }
    }
}
