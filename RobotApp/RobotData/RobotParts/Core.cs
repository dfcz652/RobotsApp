using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;

namespace RobotApp.RobotData.RobotParts
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
