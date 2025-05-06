using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData
{
    public class Robot : RobotCharacteristicsBase
    {
        public string Name { get; set; }

        public Core Core { get; private set; }

        public Body Body { get; private set; }

        public Arms Arms { get; private set; }

        public Legs Legs { get; private set; }

        public override List<RobotCharacteristicBase> RobotCharacteristics 
        { 
            get 
            { 
                return CalculateRobotCharacteristics(); 
            } 
        }

        public Robot(string name = "UnnamedRobot") : base([])
        {
            Name = name;
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
