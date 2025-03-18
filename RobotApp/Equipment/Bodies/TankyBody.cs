using RobotApp.RobotCharacteristics;
using RobotApp.RobotParts;

namespace RobotApp.Equipment.Bodys
{
    internal class TankyBody : BodyBase
    {
        public TankyBody() : base(50, [new Armor(2)])
        {
        }
    }
}
