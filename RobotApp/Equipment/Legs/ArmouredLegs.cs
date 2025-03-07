using RobotApp.RobotCharacteristics;
using RobotApp.RobotParts;

namespace RobotApp.Equipment.Legs
{
    internal class ArmouredLegs : LegsBase
    {
        public ArmouredLegs() : base(5, 2, new List<RobotCharacteristicBase>() { new Armor(3) })
        {
        }
    }
}
