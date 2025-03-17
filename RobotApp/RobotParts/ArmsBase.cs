using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class ArmsBase : RobotPartBase
    {
        public ArmsBase(int dmg, int energyCost, int impactDistance, List<RobotCharacteristicBase> characteristics = null) : 
            base(characteristics)
        {
            RobotCharacteristics.Add(new Dmg(dmg));
            RobotCharacteristics.Add(new EnergyCost(energyCost));
            RobotCharacteristics.Add(new ImpactDistance(impactDistance));
        }
    }
}
