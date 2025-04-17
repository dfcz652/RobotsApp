using RobotApp.Robot.RobotCharacteristics;
using RobotApp.Robot.RobotParts;

namespace RobotApp.Robot.RobotEquipment.Bodies
{
    public class ArmouredBody : Body
    {
        public ArmouredBody() : base(30, [new Armor(4)])
        {
        }
    }
}



