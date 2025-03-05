using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Models.Characteristics;

namespace RobotsWarApp2.Models.RobotCharacteristics
{
    internal class Speed : RobotCharacteristicBase
    {
        public Speed(string name, int value) : base("Speed", value)
        {
        }
    }
}
