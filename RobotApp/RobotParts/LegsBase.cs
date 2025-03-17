using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class LegsBase : RobotPartBase
    {
        public LegsBase(int speed, int distance, List<RobotCharacteristicBase> characteristics = null) : 
            base(characteristics ?? new List<RobotCharacteristicBase>())
        {
            characteristics.Add(new Speed(speed));
            characteristics.Add(new Distance(distance));
        }
    }
}
