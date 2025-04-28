using RobotApp.RobotData.RobotCharacteristics;

namespace RobotApp.RobotData.RobotEquipment.Legs
{
    public class ArmouredLegs : RobotParts.Legs
    {
        public ArmouredLegs() : base(5, 2, [new Armor(3)])
        {
        }
    }
}
