using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Models.RobotTypes;

namespace RobotsWarApp2.Models.RobotParts
{
    internal class Core : RobotPartBase
    {


        public Core(Dictionary<string, int> characteristics) : base("Core", characteristics)
        {

        }
    }
}
