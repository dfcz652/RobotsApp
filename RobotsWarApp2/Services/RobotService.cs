using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotsWarApp2.Data.Characteristics;
using RobotsWarApp2.Enums;
using RobotsWarApp2.Models;
using RobotsWarApp2.Models.RobotParts;

namespace RobotsWarApp2.Services
{
    internal class RobotService
    {

        public RobotPartBase CreatePart(string robotPartType)
        {

            ECoreType enumRobotPartType = robotPartType switch
            {
                "1" => ECoreType.Light,
                "2" => ECoreType.Medium,
                "3" => ECoreType.Heavy,
            };

            CoreCharacteristic coreCharacteristics = new CoreCharacteristic();
            Dictionary<string, int> characteristics = coreCharacteristics.GetCharacteristics(enumRobotPartType);

            RobotPartBase robotPart = new Core(characteristics);

            Robot robot = new Robot();

            robot.AddCore(robotPart);

            return robotPart;
        }

       
    }
}
