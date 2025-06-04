using RobotApp.RobotData;
using RobotApp.Services.Dtos;
using RobotAppUI.Reports;

namespace RobotApp.Services
{
    public class CompareRobotCharacteristicsService
    {
        public RobotComparisonReport CreateRobotComparisonReport(Robot robot1, Robot robot2)
        {
            List<RobotCharacteristicDto> summaryFirstRobot = robot1.RobotCharacteristics.ToRobotCharacteristicsDtoList();
            List<RobotCharacteristicDto> summarySecondRobot = robot2.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            var allCharacteristics = summaryFirstRobot.Select(dto => dto.DisplayName)
                                             .Union(summarySecondRobot.Select(dto => dto.DisplayName))
                                             .Distinct()
                                             .OrderBy(displayName => displayName);

            RobotComparisonReport report = new(robot1.Name, robot2.Name, []);

            foreach (var characteristicDisplayName in allCharacteristics)
            {
                var value1Dto = summaryFirstRobot.FirstOrDefault(dto => dto.DisplayName == characteristicDisplayName);
                var value2Dto = summarySecondRobot.FirstOrDefault(dto => dto.DisplayName == characteristicDisplayName);

                report.ComparisonResults.Add(new ComparisonResult
                {
                    CharacteristicName = characteristicDisplayName,
                    FirstRobotCharacteristic = value1Dto?.Value ?? 0,
                    SecondRobotCharacteristic = value2Dto?.Value ?? 0,
                });
            }
            return report;
        }
    }
}
