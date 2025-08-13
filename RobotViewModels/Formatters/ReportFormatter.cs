using System.Text;
using RobotViewModels.Interfaces;
using RobotApp.Services.Reports;
using DisplayNameService;
using RobotApp.Services.Dtos;

namespace RobotViewModels.Formatters
{
    public class ReportFormatter : IRobotsComparisonFormatter
    {
        public string FormatTwoItems(ItemComparisonReport report)
        {
            Validate(report.ComparisonResults);
            StringBuilder sb = new();
            sb.AppendLine($"{report.FirstItemName,23} | {report.SecondItemName,3}");
            string displayName;

            foreach (var comparisonResult in report.ComparisonResults)
            {
                displayName = DisplayNameProvider.GetDisplayName(comparisonResult.CharacteristicName);

                sb.AppendLine($"{displayName + ":",-19} {comparisonResult.FirstItemCharacteristic,3} | " +
                    $"{comparisonResult.SecondItemCharacteristic,3}");
            }
            return sb.ToString();
        }

        public string FormatPartDetails(string partName, List<ItemCharacteristicDto> characteristics)
        {
            StringBuilder sb = new();
            sb.AppendLine(partName);
            sb.AppendLine(new string('-', 30));

            foreach (var characteristic in characteristics.OrderBy(c => c.Name))
            {
                string displayName = DisplayNameProvider.GetDisplayName(characteristic.Name);
                sb.AppendLine($"{displayName + ":", -21}{characteristic.Value}");
            }
            return sb.ToString();
        }

        private void Validate(List<ComparisonResult> comparisonResults)
        {
            if (comparisonResults == null || comparisonResults.Count() == 0)
            {
                throw new InvalidDataException("Comparison results missing");
            }
        }
    }
}
