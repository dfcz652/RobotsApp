using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsWarApp2.Models.RobotParts
{
    internal class Legs : RobotPartBase
    {
        public Legs(Dictionary<string, int> characteristics) : base("Legs", characteristics)
        {
        }
    }
}
