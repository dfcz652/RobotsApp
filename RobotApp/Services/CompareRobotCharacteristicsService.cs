using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.Services.Dtos;
using RobotApp.Services.Reports;

namespace RobotApp.Services
{
    public class CompareRobotCharacteristicsService : IRobotService
    {
        public ItemComparisonReport CreateRobotComparisonReport(RobotCharacteristicsBase firstItem, RobotCharacteristicsBase secondItem)
        {
            List<ItemCharacteristicDto> summaryFirstItem = firstItem.RobotCharacteristics.ToRobotCharacteristicsDtoList();
            List<ItemCharacteristicDto> summarySecondItem = secondItem.RobotCharacteristics.ToRobotCharacteristicsDtoList();
            var allCharacteristics = summaryFirstItem.Select(dto => dto.Name)
                                             .Union(summarySecondItem.Select(dto => dto.Name))
                                             .Distinct()
                                             .OrderBy(name => name);
            string firstItemName, secondItemName;
            IsRobot(firstItem, secondItem, out firstItemName, out secondItemName);
            ItemComparisonReport report = new(firstItemName, secondItemName, []);
            foreach (var characteristicName in allCharacteristics)
            {
                var value1Dto = summaryFirstItem.FirstOrDefault(dto => dto.Name == characteristicName);
                var value2Dto = summarySecondItem.FirstOrDefault(dto => dto.Name == characteristicName);
                report.ComparisonResults.Add(new ComparisonResult
                {
                    CharacteristicName = characteristicName,
                    FirstItemCharacteristic = value1Dto?.Value ?? 0,
                    SecondItemCharacteristic = value2Dto?.Value ?? 0,
                });
            }
            return report;
        }

        private static void IsRobot(RobotCharacteristicsBase firstItem, RobotCharacteristicsBase secondItem, out string firstItemName, out string secondItemName)
        {
            if (firstItem is Robot firstRobot && secondItem is Robot secondRobot)
            {
                firstItemName = firstRobot.Name;
                secondItemName = secondRobot.Name;
            }
            else
            {
                firstItemName = firstItem.GetType().Name;
                secondItemName = secondItem.GetType().Name;
            }
        }
    }
}
