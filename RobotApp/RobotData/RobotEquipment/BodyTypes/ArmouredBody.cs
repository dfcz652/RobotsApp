using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.Bodies
{
    public class ArmouredBody : Body
    {
        public ArmouredBody() : base(30, [new Armor(4)])
        {
        }
    }
}



