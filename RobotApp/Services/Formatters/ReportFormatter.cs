using System.Text;

namespace RobotApp.Services
{
    public class ReportFormatter : IRobotsComparisonFormatter
    {
        public string Format(RobotComparisonReport report)
        {
            StringBuilder sb = new();
            sb.AppendLine($"{report.FirstRobotName,22} | {report.SecondRobotName,3}");

            foreach (var comparisonResult in report.ComparisonResults)
            {
                sb.AppendLine($"{comparisonResult.CharacteristicName + ":",-18} {comparisonResult.FirstRobotCharacteristic,3} | " +
                    $"{comparisonResult.SecondRobotCharacteristic,3}");
            }
            return sb.ToString();
        }
    }
}
