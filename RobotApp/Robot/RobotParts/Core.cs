using RobotApp.Robot.Base;
using RobotApp.Robot.RobotCharacteristics;

namespace RobotApp.Robot.RobotParts
{
    public class Core : RobotCharacteristicsBase
    {
        public Core(int energy, int energyRestoration, List<RobotCharacteristicBase> characteristics) :
            base(characteristics)
        {
            RobotCharacteristics.Add(new Energy(energy));
            RobotCharacteristics.Add(new EnergyRestoration(energyRestoration));
        }
    }
}
