using RobotApp.Robot.Base;
using RobotApp.Robot.RobotCharacteristics;

namespace RobotApp.Robot.RobotParts
{
    internal class Arms : RobotCharacteristicsBase
    {
        public Arms(int dmg, int energyCost, int impactDistance, List<RobotCharacteristicBase> characteristics = null) :
            base(characteristics)
        {
            RobotCharacteristics.Add(new Dmg(dmg));
            RobotCharacteristics.Add(new EnergyCost(energyCost));
            RobotCharacteristics.Add(new ImpactDistance(impactDistance));
        }
    }
}
