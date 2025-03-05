using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class LegsBase : RobotPartBase
    {


        public LegsBase(int speed, int distance, List<RobotCharacteristicBase> characteristics) : base(characteristics)
        {

            characteristics.Add(new Speed(speed));
            characteristics.Add(new Distance(distance));

        }

        public LegsBase(int speed, int distance) : base(new List<RobotCharacteristicBase>())
        {

            RobotCharacteristics.Add(new Speed(speed));
            RobotCharacteristics.Add(new Distance(distance));
        }
    }
}
