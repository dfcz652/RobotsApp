using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class CoreBase : RobotPartBase
    {
        public CoreBase(int energy, int energyRestoration, List<RobotCharacteristicBase> characteristics = null) :
            base(characteristics)
        {
            RobotCharacteristics.Add(new Energy(energy));
            RobotCharacteristics.Add(new EnergyRestoration(energyRestoration));
        }
    }
}
