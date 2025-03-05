using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class ArmsBase : RobotPartBase
    {

        public ArmsBase(int dmg, int energyCost, int impactDistance, List<RobotCharacteristicBase> characteristics) : base(characteristics)
        {

            characteristics.Add(new Dmg(dmg));
            characteristics.Add(new EnergyCost(energyCost));
            characteristics.Add(new ImpactDistance(impactDistance));
     
        }

        public ArmsBase(int dmg, int energyCost, int impactDistance) : base(new List<RobotCharacteristicBase>())
        {

            RobotCharacteristics.Add(new Dmg(dmg));
            RobotCharacteristics.Add(new EnergyCost(energyCost));
            RobotCharacteristics.Add(new ImpactDistance(impactDistance));

        }
        
    }
}
