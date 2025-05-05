using System.Text;
using RobotApp.Services.Interfaces;

namespace RobotApp.Services.Implementation
{
    public class Formatter : IRobotsComparisonFormatter
    {
        public string Format(RobotComparisonReport report)
        {
            StringBuilder sb = new();
            sb.AppendFormat($"{report.FirstRobotName,22} | {report.SecondRobotName,3}");

            foreach(var comparisonResult in report.ComparisonResults)
            {
                sb.AppendFormat($"\n{comparisonResult.CharacteristicName + ":",-18} {comparisonResult.FirstRobotCharacteristic,3} | " +
                    $"{comparisonResult.SecondRobotCharacteristic,3}");
            }
            return sb.ToString();
        }
    }
}
