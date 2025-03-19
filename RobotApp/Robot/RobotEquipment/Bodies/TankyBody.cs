using RobotApp.Robot.RobotCharacteristics;
using RobotApp.Robot.RobotParts;

namespace RobotApp.Robot.RobotEquipment.Bodies
{
    internal class TankyBody : Body
    {
        public TankyBody() : base(50, [new Armor(2)])
        {
        }
    }
}
