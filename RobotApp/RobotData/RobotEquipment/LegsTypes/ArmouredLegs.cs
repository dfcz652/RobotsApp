using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData.RobotEquipment.LegsTypes
{
    public class ArmouredLegs : Legs
    {
        public ArmouredLegs() : base(5, 2, [new Armor(3)])
        {
        }
    }
}
