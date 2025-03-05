using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Models.Characteristics;
using RobotsWarApp2.Models.RobotTypes;

namespace RobotsWarApp2.Models.RobotParts
{
    internal class RobotPartBase
    {

        public string Name { get; set; }

        public RobotPartTypeBase RobotPartType { get; set; }

        public Dictionary<string, int> RobotCharacteristics { get; set; }

        public RobotPartBase(string name, Dictionary<string, int> characteristics)
        {

            Name = name;
            RobotCharacteristics = new Dictionary<string, int>();
        }

        public void AddCharacteristic(RobotCharacteristicBase characteristic)        {

            RobotCharacteristics.Add(characteristic.Name, characteristic.Value);

        }

        public void PrintCharacteristics()
        {

            Console.WriteLine($"{Name} Characteristics of Robot: ");
            foreach (var characteristic in RobotCharacteristics)
            {
                Console.WriteLine($"{characteristic.Key}: {characteristic.Value}");
            }
        }
    }
}
