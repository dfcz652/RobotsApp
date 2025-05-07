using System.Runtime.Serialization;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.Services.Formatters;
using RobotApp.Services.Interfaces;
using RobotApp.Services.Reports;

namespace RobotAppTests.Tests
{
    public class RobotsComparisonFormatterTests
    {
        private IRobotsComparisonFormatter comparisonFormatter = new ReportFormatter();

        public static IEnumerable<object[]> EmptyComparsionResultReportData =>//RobotComparisonReport report
            new List<object[]> {
                        new object[] { new RobotComparisonReport(comparisonResults: []) },//empty comparison result case
                        new object[] { new RobotComparisonReport() },//null comparison results case
            };

        [Theory]
        [MemberData(nameof(EmptyComparsionResultReportData))]
        public void EmptyComparsionResultsReport_ThrowsInvalidDataException(RobotComparisonReport report)
        {
            Assert.Throws<InvalidDataException>(() => comparisonFormatter.Format(report));
        }

        [Fact]
        public void OneCharacteristicComparsionReport_FormattedStringWithOneCharacteristic()
        {
            RobotComparisonReport report = new(
                comparisonResults: 
                [
                    new ComparisonResult { CharacteristicName = "Dmg", FirstRobotCharacteristic = -1, SecondRobotCharacteristic = 0 },
                ]);
            string expected =
                "          UnnamedRobot | UnnamedRobot\r\n" +
                "Dmg:                -1 |   0\r\n"; 

            string formattedString = comparisonFormatter.Format(report);

            Assert.Equal(expected, formattedString);
        }

        [Fact]
        public void CharacteristicsComparsionReport_FormattedStringCharacteristics()
        {
            RobotComparisonReport report = new(
                comparisonResults:
                [
                    new ComparisonResult { CharacteristicName = "ActionSpeed", FirstRobotCharacteristic = 2, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 6 },
                    new ComparisonResult { CharacteristicName = "Dmg", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 15 },
                    new ComparisonResult { CharacteristicName = "Energy", FirstRobotCharacteristic = 4, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "EnergyRestoration", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = -7 },
                    new ComparisonResult { CharacteristicName = "Hp", FirstRobotCharacteristic = 10, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "ImpactDistance", FirstRobotCharacteristic = 5, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "MovementSpeed", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 8 }
                ]);
            string expected =
                "          UnnamedRobot | UnnamedRobot\r\n" +
                "ActionSpeed:         2 |   0\r\n" +
                "Armor:               0 |   6\r\n" +
                "Dmg:                 0 |  15\r\n" +
                "Energy:              4 |   0\r\n" +
                "EnergyRestoration:   0 |  -7\r\n" +
                "Hp:                 10 |   0\r\n" +
                "ImpactDistance:      5 |   0\r\n" +
                "MovementSpeed:       0 |   8\r\n";

            string formattedString = comparisonFormatter.Format(report);

            Assert.Equal(expected, formattedString);
        }
    }
}
