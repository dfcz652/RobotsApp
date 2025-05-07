using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.BodyTypes
{
    public class ShieldedBody : Body
    {
        public ShieldedBody() : base(10, [new Shield(10), new ShieldCost(2)])
        {
        }
    }
}
