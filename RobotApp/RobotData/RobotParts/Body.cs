using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;

namespace RobotApp.RobotData.RobotParts
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