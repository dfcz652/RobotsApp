using RobotApp.Robot.Base;
using RobotApp.Robot.RobotCharacteristics;

namespace RobotApp.Robot.RobotParts
{
    internal class Body : RobotCharacteristicsBase
    {
        public Body(int hp, List<RobotCharacteristicBase> characteristics = null) :
            base(characteristics)
        {
            RobotCharacteristics.Add(new Hp(hp));
        }
    }
}