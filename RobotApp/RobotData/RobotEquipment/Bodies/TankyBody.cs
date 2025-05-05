using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.Bodies
{
    public class TankyBody : Body
    {
        public TankyBody() : base(50, [new Armor(2)])
        {
        }
    }
}
