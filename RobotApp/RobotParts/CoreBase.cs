using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class CoreBase : RobotPartBase
    {
        public CoreBase(int energy, int energyRestoration, List<RobotCharacteristicBase> characteristics = null) :
            base(characteristics ?? new List<RobotCharacteristicBase>())
        {
            characteristics.Add(new Energy(energy));
            characteristics.Add(new EnergyRestoration(energyRestoration));
        }
    }
}
