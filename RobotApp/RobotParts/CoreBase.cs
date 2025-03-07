using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class CoreBase : RobotPartBase
    {


        public CoreBase(int energy, int energyRestoration, List<RobotCharacteristicBase> characteristics) : base(characteristics)
        {

            characteristics.Add(new Energy(energy));
            characteristics.Add(new EnergyRestoration(energyRestoration));

        }

        public CoreBase(int energy, int energyRestoration) : base(new List<RobotCharacteristicBase>())
        {

            RobotCharacteristics.Add(new Energy(energy));
            RobotCharacteristics.Add(new EnergyRestoration(energyRestoration));
        }
    }
}
