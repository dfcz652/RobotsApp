using RobotApp.Robot.Base;
using RobotApp.Robot.RobotCharacteristics;

namespace RobotApp.Robot.RobotParts
{
    public class Body : RobotCharacteristicsBase
    {
        public Body(int hp, List<RobotCharacteristicBase> characteristics) :
            base(characteristics)
        {
            RobotCharacteristics.Add(new Hp(hp));
        }
    }
}