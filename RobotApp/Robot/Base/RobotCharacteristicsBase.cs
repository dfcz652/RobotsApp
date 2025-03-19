namespace RobotApp.Robot.Base
{
    internal class RobotCharacteristicsBase
    {
        public virtual List<RobotCharacteristicBase> RobotCharacteristics { get; set; }

        public RobotCharacteristicsBase(List<RobotCharacteristicBase> characteristics)
        {
            RobotCharacteristics = characteristics ?? [];
        }
    }
}
