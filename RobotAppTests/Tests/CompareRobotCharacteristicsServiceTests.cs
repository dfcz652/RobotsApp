using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.Services;
using RobotApp.Services.Dtos;
using RobotAppUI.Reports;
using static RobotAppTests.Stubs.Parts;
using static RobotAppTests.Utils.TestUtils;

namespace RobotAppTests.Tests
{
    public class CompareRobotCharacteristicsServiceTests
    {
        private CompareRobotCharacteristicsService compareRobotService = new();

        public static IEnumerable<object[]> ConvertCharacteristicData =>//RobotCharacteristicBase characteristic
        new List<object[]> {
            new object[] { new Dmg(3), "Damage" },//usual case
            new object[] { new Armor(-10), "Armor" }//negative value case
        };

        [Fact]
        public void EmptyRobot_GivesEmptyCharacteristicsDtoList()
        {
            var robot = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            List<RobotCharacteristicDto> robotCharacteristics = robot.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            Assert.Empty(robotCharacteristics);
        }

        [Fact]
        public void RobotWithOneCharacteristicInPart_GivesOneCharacteristicDtoList()
        {
            var arms = new TestArms([new Dmg(13)]);

            var robot = CreateRobot(arms, new TestBody(), new TestCore(), new TestLegs());

            List<RobotCharacteristicDto> robotCharacteristicDtos = robot.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            Assert.Single(robotCharacteristicDtos);
            Assert.Equal("Dmg", robotCharacteristicDtos[0].Name);
            Assert.Equal("Damage", robotCharacteristicDtos[0].DisplayName);
            Assert.Equal(13, robotCharacteristicDtos[0].Value);
        }

        [Fact]
        public void RobotWithOneCharacteristicInEachPart_GivesFourthCharacteristicDtoList()
        {
            var arms = new TestArms([new Dmg(4)]);
            var body = new TestBody([new Hp(2)]);
            var core = new TestCore([new Energy(9)]);
            var legs = new TestLegs([new MovementSpeed(4)]);

            var robot = CreateRobot(arms, body, core, legs);

            List<RobotCharacteristicDto> robotCharacteristicDtos = robot.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            Assert.Equal(4, robotCharacteristicDtos.Count);
            Assert.Contains("Dmg", robotCharacteristicDtos.Select(cn => cn.Name));
            Assert.Contains("Damage", robotCharacteristicDtos.Select(cn => cn.DisplayName));
            Assert.Contains(4, robotCharacteristicDtos.Select(cv => cv.Value));
        }

        [Fact]
        public void EmptyCharacteristic_ConvertIntoCharacteristicDto_ShouldReturnInvalidDataException()
        {
            var characteristic = new RobotCharacteristicBase();

            Assert.Throws<InvalidDataException>(characteristic.ToRobotCharacteristicDto);
        }

        [Theory]
        [MemberData(nameof(ConvertCharacteristicData))]
        public void Characteristic_ConvertIntoCharacteristicDto(RobotCharacteristicBase characteristic, string expectedDisplayName)
        {
            RobotCharacteristicDto dto = characteristic.ToRobotCharacteristicDto();

            Assert.Equal(characteristic.GetType().Name, dto.Name);
            Assert.Equal(expectedDisplayName, dto.DisplayName);
            Assert.Equal(characteristic.Value, dto.Value);
        }

        [Fact]
        public void TwoEmptyRobots_EmptyComparisonReports()
        {
            var robot1 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            var robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            RobotComparisonReport report = compareRobotService.CreateRobotComparisonReport(robot1, robot2);

            Assert.Empty(report.ComparisonResults);
        }

        [Fact]
        public void OneEmptyRobotAndOneRobotWithCharacteristic_OneCharacteristicComparsionReport()
        {
            var robot1 = CreateRobot(new TestArms([new Dmg(1)]), new TestBody(), new TestCore(), new TestLegs());
            var robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            RobotComparisonReport report = compareRobotService.CreateRobotComparisonReport(robot1, robot2);

            Assert.Equal("Damage", report.ComparisonResults[0].CharacteristicName);
            Assert.Equal(1, report.ComparisonResults[0].FirstRobotCharacteristic);
            Assert.Equal(0, report.ComparisonResults[0].SecondRobotCharacteristic);
        }

        [Fact]
        public void TwoRobotsWithNonRepeatingCharacteristics_NonRepeatingCharacteristicsComparsionReport()
        {
            var robot1 = CreateRobot(new TestArms([new ImpactDistance(5)]), new TestBody([new Hp(10)]), new TestCore([new Energy(4)]), new TestLegs([new ActionSpeed(2)]));
            var robot2 = CreateRobot(new TestArms([new Dmg(15)]), new TestBody([new Armor(6)]), new TestCore([new EnergyRestoration(7)]), new TestLegs([new MovementSpeed(8)]));

            List<ComparisonResult> comparisonResults = [
                    new ComparisonResult { CharacteristicName = "Action speed", FirstRobotCharacteristic = 2, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 6 },
                    new ComparisonResult { CharacteristicName = "Damage", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 15 },
                    new ComparisonResult { CharacteristicName = "Energy", FirstRobotCharacteristic = 4, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Energy restoration", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 7 },
                    new ComparisonResult { CharacteristicName = "Health", FirstRobotCharacteristic = 10, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Impact distance", FirstRobotCharacteristic = 5, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Movement speed", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 8 }
            ];

            RobotComparisonReport expectedReport = new("", "", comparisonResults);

            RobotComparisonReport report = compareRobotService.CreateRobotComparisonReport(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void OneEmptyRobotAndRobotWithRepeatingCharacteristicsInEachPart_OneSummedCharacteristicReport()
        {
            var robot1 = CreateRobot(new TestArms([new Dmg(6)]), new TestBody([new Dmg(14)]), new TestCore([new Dmg(1)]), new TestLegs([new Dmg(9)]));
            var robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            RobotComparisonReport expectedReport = new("", "",
                [
                    new ComparisonResult { CharacteristicName = "Damage", FirstRobotCharacteristic = 30, SecondRobotCharacteristic = 0 }
                ]);


            RobotComparisonReport report = compareRobotService.CreateRobotComparisonReport(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void TwoRobotsWithRepeatingCharacteristicsInEachPart_TwoSummedCharacteristicsReport()
        {
            var robot1 = CreateRobot(new TestArms([new Armor(7)]), new TestBody([new Armor(-1)]), new TestCore([new Armor(13)]), new TestLegs([new Armor(10)]));
            var robot2 = CreateRobot(new TestArms([new ActionSpeed(2)]), new TestBody([new ActionSpeed(-3)]), new TestCore([new ActionSpeed(4)]), new TestLegs([new ActionSpeed(7)]));

            List<ComparisonResult> comparisonResults =
                [
                    new ComparisonResult { CharacteristicName = "Action speed", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 10 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstRobotCharacteristic = 29, SecondRobotCharacteristic = 0 },
                ];

            RobotComparisonReport expectedReport = new("", "", comparisonResults);

            RobotComparisonReport report = compareRobotService.CreateRobotComparisonReport(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void OneEmptyNameRobotAndOneRobotWithName_OneRobotNameReport()
        {
            Robot robot1 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs(), "TestRobot");
            Robot robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            RobotComparisonReport report = compareRobotService.CreateRobotComparisonReport(robot1, robot2);

            Assert.Equal("TestRobot", report.FirstRobotName);
        }

        [Fact]
        public void TwoRobotsWithNames_TwoRobotNameReport()
        {
            Robot robot1 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs(), "TestRobot1");
            Robot robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs(), "TestRobot2");

            RobotComparisonReport report = compareRobotService.CreateRobotComparisonReport(robot1, robot2);

            Assert.Equal("TestRobot1", report.FirstRobotName);
            Assert.Equal("TestRobot2", report.SecondRobotName);
        }

        [Fact]
        public void TwoRobotsWithoutNames_TwoUnnamedRobotNameReport()
        {
            Robot robot1 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            Robot robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            RobotComparisonReport report = compareRobotService.CreateRobotComparisonReport(robot1, robot2);

            Assert.Equal("UnnamedRobot", report.FirstRobotName);
            Assert.Equal("UnnamedRobot", report.SecondRobotName);
        }

        private static void AssertEqualsComparisonResultCollections(List<ComparisonResult> list1, List<ComparisonResult> list2)
        {
            if (list1 == null && list2 == null)
            {
                Assert.Fail("Collections are null");
                return;
            }
            if (list1 == null || list2 == null)
            {
                Assert.Fail("One of collection is null");
                return;
            }
            if (list1.Count != list2.Count)
            {
                Assert.Fail($"Number of elements in collections varies: {list1.Count} against {list2.Count}");
                return;
            }

            list1 = list1.OrderBy(cr => cr.CharacteristicName).ToList();
            list2 = list2.OrderBy(cr => cr.CharacteristicName).ToList();

            for (int i = 0; i < list1.Count; i++)
            {
                Assert.Equal(list1[i].CharacteristicName, list2[i].CharacteristicName);
                Assert.Equal(list1[i].FirstRobotCharacteristic, list2[i].FirstRobotCharacteristic);
                Assert.Equal(list1[i].SecondRobotCharacteristic, list2[i].SecondRobotCharacteristic);
            }
        }
    }
}
