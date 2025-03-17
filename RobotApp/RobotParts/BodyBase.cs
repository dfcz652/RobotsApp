using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class BodyBase : RobotPartBase
    {
        public BodyBase(int hp, List<RobotCharacteristicBase> characteristics = null) : 
            base(characteristics)
        {
            RobotCharacteristics.Add(new Hp(hp));
        }
    }
}