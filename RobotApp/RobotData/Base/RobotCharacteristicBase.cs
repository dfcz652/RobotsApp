using RobotApp.Services.Dtos;

namespace RobotApp.RobotData.Base
{
    public class RobotCharacteristicBase
    {
        public int Value { get; set; }

        public RobotCharacteristicBase(int value)
        {
            Value = value;
        }

        public RobotCharacteristicBase()
        {
        }
    }
}
