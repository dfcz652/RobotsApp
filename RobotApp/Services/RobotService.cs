using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using RobotApp.RobotCharacteristics;

namespace RobotApp.Services
{
    internal class RobotService
    {

        public List<RobotCharacteristicBase> AddAllParts(Robot robot)
        {

            var allCharacteristics = new List<RobotCharacteristicBase>();
            allCharacteristics.AddRange(robot.Core.RobotCharacteristics);
            allCharacteristics.AddRange(robot.Arms.RobotCharacteristics);
            allCharacteristics.AddRange(robot.Body.RobotCharacteristics);
            allCharacteristics.AddRange(robot.Legs.RobotCharacteristics);

            return allCharacteristics;
        }

        public List<RobotCharacteristicBase> CombineCharacteristics(List<RobotCharacteristicBase> allCharacteristics)
        {

            return allCharacteristics.GroupBy(characteristic => characteristic.GetType())
                .Select(group =>
                {
                    var combinedCharacteristic = (RobotCharacteristicBase)Activator.CreateInstance(group.Key);
                    combinedCharacteristic.Value = group.Sum(characteristic => characteristic.Value);
                    
                    return combinedCharacteristic;
                }).ToList();
        }
    }
}
