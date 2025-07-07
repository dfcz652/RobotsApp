using System.Text;
using RobotViewModels.Interfaces;
using RobotApp.Services.Reports;
using DisplayNameService;

namespace RobotViewModels.Formatters
{
    public class ReportFormatter : IRobotsComparisonFormatter
    {
        public string Format(ItemComparisonReport report)
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

        private void Validate(List<ComparisonResult> comparisonResults)
        {
            if (comparisonResults == null || comparisonResults.Count() == 0)
            {
                throw new InvalidDataException("Comparison results missing");
            }
        }
    }
}
