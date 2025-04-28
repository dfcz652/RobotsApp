using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;

namespace RobotApp.RobotData.RobotParts
{
    public class Arms : RobotCharacteristicsBase
    {
        public Arms(int dmg, int energyCost, int impactDistance, List<RobotCharacteristicBase> characteristics) :
            base(characteristics)
        {
            RobotCharacteristics.Add(new Dmg(dmg));
            RobotCharacteristics.Add(new EnergyCost(energyCost));
            RobotCharacteristics.Add(new ImpactDistance(impactDistance));
        }
    }
}
