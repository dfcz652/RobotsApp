using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsWarApp2.Models.RobotParts
{
    internal class Arms : RobotPartBase
    {
        public Arms(Dictionary<string, int> characteristics) : base("Arms", characteristics)
        {
        }
    }
}
