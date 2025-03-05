using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Models.Characteristics;

namespace RobotsWarApp2.Models.RobotCharacteristics
{
    internal class Shield : RobotCharacteristicBase
    {
        public Shield(string name, int value) : base("Shield", value)
        {
        }
    }
}
