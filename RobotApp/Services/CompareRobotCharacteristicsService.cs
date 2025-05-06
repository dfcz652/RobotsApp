using RobotApp.RobotData;
using RobotApp.Services.Dtos;
using RobotApp.Services.Reports;

namespace RobotApp.Services
{
    public class CompareRobotCharacteristicsService
    {
        public RobotComparisonReport CreateRobotComparisonReport(Robot robot1, Robot robot2)
        {
            List<RobotCharacteristicDto> summaryFirstRobot = robot1.RobotCharacteristics.ToRobotCharacteristicsDtoList();
            List<RobotCharacteristicDto> summarySecondRobot = robot2.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            var allCharacteristics = summaryFirstRobot.Select(dto => dto.Name)
                                             .Union(summarySecondRobot.Select(dto => dto.Name))
                                             .Distinct()
                                             .OrderBy(name => name);

            RobotComparisonReport report = new() { FirstRobotName = robot1.Name, SecondRobotName = robot2.Name };

            foreach (var characteristicName in allCharacteristics)
            {
                var value1Dto = summaryFirstRobot.FirstOrDefault(dto => dto.Name == characteristicName);
                var value2Dto = summarySecondRobot.FirstOrDefault(dto => dto.Name == characteristicName);

                report.ComparisonResults.Add(new ComparisonResult
                {
                    CharacteristicName = characteristicName,
                    FirstRobotCharacteristic = value1Dto?.Value ?? 0,
                    SecondRobotCharacteristic = value2Dto?.Value ?? 0,
                });
            }
            return report;
        }
    }
}
