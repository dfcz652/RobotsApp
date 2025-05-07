using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.BodyTypes
{
    public class ArmouredBody : Body
    {
        public ArmouredBody() : base(30, [new Armor(4)])
        {
        }
    }
}



