using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Models.Characteristics;

namespace RobotsWarApp2.Models.RobotCharacteristics
{
    internal class Armor : RobotCharacteristicBase
    {
        public Armor(string name, int value) : base("Armor", value)
        {
        }
    }
}
