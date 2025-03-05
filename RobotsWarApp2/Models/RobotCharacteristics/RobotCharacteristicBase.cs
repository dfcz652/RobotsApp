using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsWarApp2.Models.Characteristics
{
    internal class RobotCharacteristicBase
    {

        public string Name { get; set; }

        public int Value { get; set; }

        public RobotCharacteristicBase(string name, int value)
        {
            Name = name;
            Value = value;
        }

    }
}
