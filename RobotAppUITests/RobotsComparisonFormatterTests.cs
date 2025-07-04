using RobotViewModels.Formatters;
using RobotViewModels.Interfaces;
using RobotApp.Services.Reports;

namespace RobotAppUITests.Tests
{
    public class RobotsComparisonFormatterTests
    {
        private IRobotsComparisonFormatter comparisonFormatter = new ReportFormatter();

        public static IEnumerable<object[]> EmptyComparsionResultReportData =>//RobotComparisonReport report
            new List<object[]> {
                        new object[] { new ItemComparisonReport("", "", []) },//empty comparison results case
                        new object[] { new ItemComparisonReport("", "") },//null comparison results case
            };

        [Theory]
        [MemberData(nameof(EmptyComparsionResultReportData))]
        public void EmptyComparsionResultsReport_ThrowsInvalidDataException(ItemComparisonReport report)
        {
            Assert.Throws<InvalidDataException>(() => comparisonFormatter.Format(report));
        }

        [Fact]
        public void OneCharacteristicComparsionReport_FormattedStringWithOneCharacteristic()
        {
            ItemComparisonReport report = new("UnnamedRobot", "UnnamedRobot",
                [
                    new ComparisonResult { CharacteristicName = "Dmg", FirstItemCharacteristic = -1, SecondItemCharacteristic = 0 },
                ]);
            string expected =
                "           UnnamedRobot | UnnamedRobot" + "\r\n" +
                "Damage:              -1 |   0" + "\r\n";

            string formattedString = comparisonFormatter.Format(report);

            Assert.Equal(expected, formattedString);
        }

        [Fact]
        public void CharacteristicsComparsionReport_FormattedStringCharacteristics()
        {
            List<ComparisonResult> comparisonResults = [
                    new ComparisonResult { CharacteristicName = "ActionSpeed", FirstItemCharacteristic = 2, SecondItemCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstItemCharacteristic = 0, SecondItemCharacteristic = 6 },
                    new ComparisonResult { CharacteristicName = "Dmg", FirstItemCharacteristic = 0, SecondItemCharacteristic = 15 },
                    new ComparisonResult { CharacteristicName = "Energy", FirstItemCharacteristic = 4, SecondItemCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "EnergyRestoration", FirstItemCharacteristic = 0, SecondItemCharacteristic = -7 },
                    new ComparisonResult { CharacteristicName = "Hp", FirstItemCharacteristic = 10, SecondItemCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "ImpactDistance", FirstItemCharacteristic = 5, SecondItemCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "MovementSpeed", FirstItemCharacteristic = 0, SecondItemCharacteristic = 8 }
            ];
            ItemComparisonReport report = new( "UnnamedRobot", "UnnamedRobot", comparisonResults);
            string expected =
                "           UnnamedRobot | UnnamedRobot" + "\r\n" +
                "Action speed:         2 |   0" + "\r\n" +
                "Armor:                0 |   6" + "\r\n" +
                "Damage:               0 |  15" + "\r\n" +
                "Energy:               4 |   0" + "\r\n" +
                "Energy restoration:   0 |  -7" + "\r\n" +
                "Health:              10 |   0" + "\r\n" +
                "Impact distance:      5 |   0" + "\r\n" +
                "Movement speed:       0 |   8" + "\r\n";

            string formattedString = comparisonFormatter.Format(report);

            Assert.Equal(expected, formattedString);
        }
    }
}
