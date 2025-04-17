using RobotApp.Robot.Base;
using RobotApp.Robot.RobotParts;

namespace RobotApp.Robot
{
    public class Robot : RobotCharacteristicsBase
    {
        public Core Core { get; set; }

        public Body Body { get; set; }

        public Arms Arms { get; set; }

        public Legs Legs { get; set; }

        public override List<RobotCharacteristicBase> RobotCharacteristics 
        { 
            get 
            { 
                return CalculateRobotCharacteristics(); 
            } 
        }

        public Robot() : base([])
        {
        }

        public void AddCore(Core robotPart)
        {
            Core = robotPart;
        }

        public void AddBody(Body robotPart)
        {
            Body = robotPart;
        }

        public void AddArms(Arms robotPart)
        {
            Arms = robotPart;
        }

        public void AddLegs(Legs robotPart)
        {
            Legs = robotPart;
        }

        private List<RobotCharacteristicBase> CalculateRobotCharacteristics()
        {
            return Core.RobotCharacteristics
            .Concat(Arms.RobotCharacteristics)
            .Concat(Body.RobotCharacteristics)
            .Concat(Legs.RobotCharacteristics)
            .GroupBy(characteristic => characteristic.GetType())
            .Select(group =>
            {
                var combinedCharacteristic = (RobotCharacteristicBase)Activator.CreateInstance(group.Key);
                combinedCharacteristic.Value = group.Sum(characteristic => characteristic.Value);
                return combinedCharacteristic;
            }).ToList();
        }
    }
}
