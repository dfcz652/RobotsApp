using System.Text;
using RobotAppConsole.Interfaces;
using RobotApp.Services.Reports;

namespace RobotAppConsole.Formatters
{
    public class ReportFormatter : IRobotsComparisonFormatter
    {
        public string Format(RobotComparisonReport report)
        {
            Validate(report.ComparisonResults);

            StringBuilder sb = new();
            sb.AppendLine($"{report.FirstRobotName,23} | {report.SecondRobotName,3}");

            foreach (var comparisonResult in report.ComparisonResults)
            {
                sb.AppendLine($"{comparisonResult.CharacteristicName + ":",-19} {comparisonResult.FirstRobotCharacteristic,3} | " +
                    $"{comparisonResult.SecondRobotCharacteristic,3}");
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
