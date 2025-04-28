using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotApp.RobotData;
using RobotApp.Services.Dtos;

namespace RobotApp.Services.Utils
{
    public class CompareRobotUtils
    {
        public List<RobotCharacteristicDto> GetRobotCharacteristicsDtoList(Robot robot)
        {
            List<RobotCharacteristicDto> robotCharacteristics = new List<RobotCharacteristicDto>();
            if (robot.RobotCharacteristics.Count() == 0)
            {
                return robotCharacteristics;
            }
            else
            {
                foreach (var characteristic in robot.RobotCharacteristics)
                {
                    RobotCharacteristicDto dto = characteristic.ToRobotCharacteristicDto();

                    robotCharacteristics.Add(dto);
                }
            }
            return robotCharacteristics;
        }
    }
}
