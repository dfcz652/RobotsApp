using RobotApp.RobotCharacteristics;
using RobotApp.RobotParts;

namespace RobotApp.Equipment.Bodys
{
    internal class ShieldedBody : BodyBase
    {
        public ShieldedBody() : base(10, [new ShieldCost(3)])
        {
        }
    }
}
