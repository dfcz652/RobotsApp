using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Models.RobotParts;

namespace RobotsWarApp2.Models
{
    internal class Robot
    {

        public RobotPartBase Core { get; set; }

        public RobotPartBase Body { get; set; }

        public RobotPartBase Arms { get; set; }

        public RobotPartBase Legs { get; set; }

        public void AddCore(RobotPartBase robotPart)
        {

            Core = robotPart;
        }
    }
}
