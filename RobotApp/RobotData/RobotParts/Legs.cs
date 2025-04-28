using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;

namespace RobotApp.RobotData.RobotParts
{
    public class Legs : RobotCharacteristicsBase
    {
        public Legs(int movementSpeed, int actionSpeed, List<RobotCharacteristicBase> characteristics) :
            base(characteristics)
        {
            RobotCharacteristics.Add(new MovementSpeed(movementSpeed));
            RobotCharacteristics.Add(new ActionSpeed(actionSpeed));
        }
    }
}