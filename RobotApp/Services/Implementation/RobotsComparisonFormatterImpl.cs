using System.Text;
using RobotApp.Services.Interfaces;
using RobotAppTests.Tests;

namespace RobotApp.Services.Implementation
{
    public class RobotsComparisonFormatterImpl : IRobotsComparisonFormatter
    {
        public void Format(RobotComparisonReport report)
        {
            StringBuilder sb = new();
            sb.AppendFormat($"{"Robot1",22} | {"Robot2",3}");

            foreach(var comparsionResult in report.ComparisonResults)
            {
                sb.AppendFormat($"\n{comparsionResult.CharacteristicName + ":",-18} {comparsionResult.FirstRobotCharacteristic,3} | " +
                    $"{comparsionResult.SecondRobotCharacteristic,3}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
