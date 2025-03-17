using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class ArmsBase : RobotPartBase
    {
        public ArmsBase(int dmg, int energyCost, int impactDistance, List<RobotCharacteristicBase> characteristics = null) : 
            base(characteristics ?? new List<RobotCharacteristicBase>())
        {
            characteristics.Add(new Dmg(dmg));
            characteristics.Add(new EnergyCost(energyCost));
            characteristics.Add(new ImpactDistance(impactDistance));
        }
    }
}
