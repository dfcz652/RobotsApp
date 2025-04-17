using RobotApp.Robot.RobotCharacteristics;

namespace RobotApp.Robot.RobotEquipment.Legs
{
    public class ArmouredLegs : RobotParts.Legs
    {
        public ArmouredLegs() : base(5, 2, [new Armor(3)])
        {
        }
    }
}
