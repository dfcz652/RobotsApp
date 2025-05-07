using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.BodyTypes
{
    public class TankyBody : Body
    {
        public TankyBody() : base(50, [new Armor(2)])
        {
        }
    }
}
