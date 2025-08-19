using System.ComponentModel;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotParts;

namespace RobotApp.RobotData
{
    public class Robot : RobotCharacteristicsBase
    {
        public string Name { get; set; }

        private Core _core;
        public Core Core
        {
            get => _core;
            private set
            {
                _core = value;
                UpdateRobotCharacteristics();
            }
        }

        private Body _body;
        public Body Body 
        { 
            get => _body;
            private set
            {
                _body = value;
                UpdateRobotCharacteristics();
            }
        }

        private Arms _arms;
        public Arms Arms
        {
            get => _arms;
            private set
            {
                _arms = value;
                UpdateRobotCharacteristics();
            }
        }

        private Legs _legs;
        public Legs Legs 
        { 
            get => _legs;
            private set 
            {
                _legs = value;
                UpdateRobotCharacteristics();
            }
        }

        private List<RobotCharacteristicBase> _robotCharacteristics;

        public List<RobotCharacteristicBase> RobotCharacteristics
        {
            get => _robotCharacteristics;
            private set
            {
                _robotCharacteristics = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RobotCharacteristics)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void UpdateRobotCharacteristics()
        {
            RobotCharacteristics = (Core?.RobotCharacteristics ?? new List<RobotCharacteristicBase>())
        .Concat(Arms?.RobotCharacteristics ?? new List<RobotCharacteristicBase>())
        .Concat(Body?.RobotCharacteristics ?? new List<RobotCharacteristicBase>())
        .Concat(Legs?.RobotCharacteristics ?? new List<RobotCharacteristicBase>())
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
