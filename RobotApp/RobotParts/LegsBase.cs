using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class LegsBase : RobotPartBase
    {
        public LegsBase(int speed, int distance, List<RobotCharacteristicBase> characteristics = null) : 
            base(characteristics)
        {
            RobotCharacteristics.Add(new Speed(speed));
            RobotCharacteristics.Add(new Distance(distance));
        }
    }
}