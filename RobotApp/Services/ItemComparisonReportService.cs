using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotParts;
using RobotApp.Services.Dtos;
using RobotApp.Services.Reports;

namespace RobotApp.Services
{
    public class ItemComparisonReportService : IItemComparisonService
    {
        public ItemComparisonReport CreateReportForItem(RobotCharacteristicsBase item1)
        {
            List<ItemCharacteristicDto> summaryItem = item1.RobotCharacteristics.ToItemCharacteristicsDtoList();

            string itemName = GetItemNames(item1);
            ItemComparisonReport report = new(itemName, string.Empty, new List<ComparisonResult>());
            foreach (var dto in summaryItem.OrderBy(dto => dto.Name))
            {
                report.ComparisonResults.Add(new ComparisonResult
                {
                    CharacteristicName = dto.Name,
                    FirstItemCharacteristic = dto.Value,
                    SecondItemCharacteristic = 0,
                });
            }
            return report;
        }

        public ItemComparisonReport CreateReportForTwoItems(RobotCharacteristicsBase firstItem, RobotCharacteristicsBase secondItem)
        {
            List<ItemCharacteristicDto> summaryFirstItem = firstItem.RobotCharacteristics.ToItemCharacteristicsDtoList();
            List<ItemCharacteristicDto> summarySecondItem = secondItem.RobotCharacteristics.ToItemCharacteristicsDtoList();
            var allCharacteristics = summaryFirstItem.Select(dto => dto.Name)
                                             .Union(summarySecondItem.Select(dto => dto.Name))
                                             .Distinct()
                                             .OrderBy(name => name);
            string firstItemName = GetItemNames(firstItem);
            string secondItemName = GetItemNames(secondItem);
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

        private string GetItemNames(RobotCharacteristicsBase item)
        {
            string itemName = string.Empty;
            switch (item)
            {
                case Robot robot:
                    itemName = robot.Name;
                    break;
                case Arms _:
                case Body _:
                case Core _:
                case Legs _:
                    itemName = item.GetType().Name;
                    break;
                default:
                    throw new NotImplementedException($"{item.GetType().Name} is not supported");
            }
            return itemName;
        }
    }
}
