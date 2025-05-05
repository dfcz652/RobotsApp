using RobotApp.Services.Implementation;
using RobotApp.Services.Interfaces;
using RobotApp.Services.Reports;

namespace RobotAppTests.Tests
{
    public class RobotsComparisonFormatterTests
    {
        private IRobotsComparisonFormatter comparisonFormatter = new Formatter();

        [Fact]
        public void EmptyComparisonReport_FormattedStringWithoutCharacteristics()
        {
            string formattedString = comparisonFormatter.Format(new RobotComparisonReport());

            Assert.Equal($"{null,22} | {null,3}", formattedString);
        }

        [Fact]
        public void OneCharacteristicComparsionReport_FormattedStringWithOneCharacteristic()
        {
            RobotComparisonReport report = new()
            {
                ComparisonResults =
                [
                    new ComparisonResult { CharacteristicName = "Dmg", FirstRobotCharacteristic = -1, SecondRobotCharacteristic = 0 },
                ]
            };
            string expected = 
                $"{null,22} | {null,3}\n" +
                $"{"Dmg" + ":",-18} {-1,3} | {0,3}";

            string formattedString = comparisonFormatter.Format(report);

            Assert.Equal(expected, formattedString);
        }

        [Fact]
        public void CharacteristicsComparsionReport_FormattedStringCharacteristics()
        {
            RobotComparisonReport report = new()
            {
                ComparisonResults =
                [
                    new ComparisonResult { CharacteristicName = "ActionSpeed", FirstRobotCharacteristic = 2, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 6 },
                    new ComparisonResult { CharacteristicName = "Dmg", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 15 },
                    new ComparisonResult { CharacteristicName = "Energy", FirstRobotCharacteristic = 4, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "EnergyRestoration", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = -7 },
                    new ComparisonResult { CharacteristicName = "Hp", FirstRobotCharacteristic = 10, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "ImpactDistance", FirstRobotCharacteristic = 5, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "MovementSpeed", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 8 }
                ]
            };
            string expected =
                $"{null,22} | {null,3}\n" +
                $"{"ActionSpeed" + ":",-18} {2,3} | {0,3}\n" +
                $"{"Armor" + ":",-18} {0,3} | {6,3}\n" +
                $"{"Dmg" + ":",-18} {0,3} | {15,3}\n" +
                $"{"Energy" + ":",-18} {4,3} | {0,3}\n" +
                $"{"EnergyRestoration" + ":",-18} {0,3} | {-7,3}\n" +
                $"{"Hp" + ":",-18} {10,3} | {0,3}\n" +
                $"{"ImpactDistance" + ":",-18} {5,3} | {0,3}\n" +
                $"{"MovementSpeed" + ":",-18} {0,3} | {8,3}";

            string formattedString = comparisonFormatter.Format(report);

            Assert.Equal(expected, formattedString);
        }

        [Fact]
        public void ComparisonReportWithFirstRobotName_FormattedStringWithFirstRobotName()
        {
            RobotComparisonReport report = new() { FirstRobotName = "BF20" };
            string expected = $"{"BF20",22} | {null,3}";

            string formattedString = comparisonFormatter.Format(report);

            Assert.Equal(expected, formattedString);
        }
    }
}
