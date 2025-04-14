using RobotApp.Robot.Base;
using RobotApp.Robot.RobotCharacteristics;

namespace RobotApp.Robot.RobotParts
{
    internal class Legs : RobotCharacteristicsBase
    {
        public Legs(int speed, int distance, List<RobotCharacteristicBase> characteristics) :
            base(characteristics)
        {
            RobotCharacteristics.Add(new MovementSpeed(speed));
            RobotCharacteristics.Add(new ActionSpeed(distance));
        }
    }
}