using System.Text;
using RobotApp.Services.Interfaces;
using RobotApp.Services.Reports;

namespace RobotApp.Services.Formatters
{
    public class ReportFormatter : IRobotsComparisonFormatter
    {
        public string Format(RobotComparisonReport report)
        {
            ValidityCheck(report.ComparisonResults);

            StringBuilder sb = new();
            sb.AppendLine($"{report.FirstRobotName,22} | {report.SecondRobotName,3}");

            foreach (var comparisonResult in report.ComparisonResults)
            {
                sb.AppendLine($"{comparisonResult.CharacteristicName + ":",-18} {comparisonResult.FirstRobotCharacteristic,3} | " +
                    $"{comparisonResult.SecondRobotCharacteristic,3}");
            }
            return sb.ToString();
        }

        private void ValidityCheck(List<ComparisonResult> comparisonResults)
        {
            if (comparisonResults == null || comparisonResults.Count() == 0)
            {
                throw new InvalidDataException();
            }
        }
    }
}
