using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class RobotPartBase
    {

        public List<RobotCharacteristicBase> RobotCharacteristics { get; set; }

        public RobotPartBase(List<RobotCharacteristicBase> characteristics)
        {
            RobotCharacteristics = characteristics;
        }
    }
}
