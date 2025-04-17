using RobotApp.Robot.RobotCharacteristics;
using RobotApp.Robot.RobotParts;

namespace RobotApp.Robot.RobotEquipment.Bodies
{
    public class ShieldedBody : Body
    {
        public ShieldedBody() : base(10, [new Shield(10), new ShieldCost(2)])
        {
        }
    }
}
