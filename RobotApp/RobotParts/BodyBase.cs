using RobotApp.RobotCharacteristics;

namespace RobotApp.RobotParts
{
    internal class BodyBase : RobotPartBase
    {

        public BodyBase(int hp, List<RobotCharacteristicBase> characteristics) : base(characteristics)
        {
            characteristics.Add(new Hp(hp));
        }

        public BodyBase(int hp) : base(new List<RobotCharacteristicBase>() )
        {
            RobotCharacteristics.Add(new Hp(hp));
        }
    }
}
