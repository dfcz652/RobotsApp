using RobotApp.Robot.Base;
using RobotApp.Robot.RobotCharacteristics;

namespace RobotApp.Robot.RobotParts
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