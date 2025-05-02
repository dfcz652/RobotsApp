using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.Services;
using RobotApp.Services.Dtos;
using RobotApp.Services.Reports;
using static RobotAppTests.Stubs.Parts;
using static RobotAppTests.Utils.TestUtils;

namespace RobotAppTests.Tests
{
    public class CompareRobotCharacteristicsServiceTests
    {
        private CompareRobotCharacteristicsService CompareRobotService = new();

        public static IEnumerable<object[]> ConvertCharacteristicData =>//RobotCharacteristicBase characteristic
        new List<object[]> {
            new object[] { new Dmg(3) },//usual case
            new object[] { new Armor(-10) }//negative value case
        };

        [Fact]
        public void EmptyRobot_GivesEmptyCharacteristicsDtoList()
        {
            var robot = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            List<RobotCharacteristicDto> robotCharacteristics = robot.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            Assert.Empty(robotCharacteristics);
        }

        [Fact]
        public void RobotWithOneCharacteristicInPart_GivesOneCharacteristicDtoList()
        {
            var arms = new TestArms([new Dmg(13)]);

            var robot = CreateRobotFromParts(arms, new TestBody(), new TestCore(), new TestLegs());
            List<RobotCharacteristicDto> robotCharacteristicDtos = robot.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            Assert.Single(robotCharacteristicDtos);
            Assert.Equal("Dmg", robotCharacteristicDtos[0].Name);
            Assert.Equal(13, robotCharacteristicDtos[0].Value);
        }

        [Fact]
        public void RobotWithOneCharacteristicInEachPart_GivesFourthCharacteristicDtoList()
        {
            var arms = new TestArms([new Dmg(4)]);
            var body = new TestBody([new Hp(2)]);
            var core = new TestCore([new Energy(9)]);
            var legs = new TestLegs([new MovementSpeed(4)]);

            var robot = CreateRobotFromParts(arms, body, core, legs);
            List<RobotCharacteristicDto> robotCharacteristicDtos = robot.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            Assert.Equal(4, robotCharacteristicDtos.Count);
            Assert.Contains("Dmg", robotCharacteristicDtos.Select(cn => cn.Name));
            Assert.Contains(4, robotCharacteristicDtos.Select(cv => cv.Value));
        }

        [Fact]
        public void EmptyCharacteristic_ConvertIntoCharacteristicDto()
        {
            var characteristic = new RobotCharacteristicBase();

            RobotCharacteristicDto dto = characteristic.ToRobotCharacteristicDto();

            Assert.Equal(characteristic.GetType().Name, dto.Name);
            Assert.Equal(0, dto.Value);
        }

        [Theory]
        [MemberData(nameof(ConvertCharacteristicData))]
        public void Characteristic_ConvertIntoCharacteristicDto(RobotCharacteristicBase characteristic)
        {
            RobotCharacteristicDto dto = characteristic.ToRobotCharacteristicDto();

            Assert.Equal(characteristic.GetType().Name, dto.Name);
            Assert.Equal(characteristic.Value, dto.Value);
        }

        [Fact]
        public void TwoEmptyRobots_EmptyComparisonReports()
        {
            var robot1 = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            var robot2 = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            RobotComparisonReport report = CompareRobotService.FormComparingReportForTwoRobots(robot1, robot2);

            Assert.Empty(report.ComparisonResults);
        }

        [Fact]
        public void OneEmptyRobotAndOneRobotWithCharacteristic_OneCharacteristicComparsionReport()
        {
            var robot1 = CreateRobotFromParts(new TestArms([new Dmg(1)]), new TestBody(), new TestCore(), new TestLegs());
            var robot2 = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            RobotComparisonReport report = CompareRobotService.FormComparingReportForTwoRobots(robot1, robot2);

            Assert.Equal("Dmg", report.ComparisonResults[0].CharacteristicName);
            Assert.Equal(1, report.ComparisonResults[0].FirstRobotCharacteristic);
            Assert.Equal(0, report.ComparisonResults[0].SecondRobotCharacteristic);
        }

        [Fact]
        public void TwoRobotsWithNonRepeatingCharacteristics_NonRepeatingCharacteristicsComparsionReport()
        {
            var robot1 = CreateRobotFromParts(new TestArms([new ImpactDistance(5)]), new TestBody([new Hp(10)]), new TestCore([new Energy(4)]), new TestLegs([new ActionSpeed(2)]));
            var robot2 = CreateRobotFromParts(new TestArms([new Dmg(15)]), new TestBody([new Armor(6)]), new TestCore([new EnergyRestoration(7)]), new TestLegs([new MovementSpeed(8)]));
            RobotComparisonReport expectedReport = new()
            {
                ComparisonResults =
                [
                    new ComparisonResult { CharacteristicName = "ActionSpeed", FirstRobotCharacteristic = 2, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 6 },
                    new ComparisonResult { CharacteristicName = "Dmg", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 15 },
                    new ComparisonResult { CharacteristicName = "Energy", FirstRobotCharacteristic = 4, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "EnergyRestoration", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 7 },
                    new ComparisonResult { CharacteristicName = "Hp", FirstRobotCharacteristic = 10, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "ImpactDistance", FirstRobotCharacteristic = 5, SecondRobotCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "MovementSpeed", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 8 }
                ]
            };

            RobotComparisonReport report = CompareRobotService.FormComparingReportForTwoRobots(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void OneEmptyRobotAndRobotWithRepeatingCharacteristicsInEachPart_OneSummedCharacteristicReport()
        {
            var robot1 = CreateRobotFromParts(new TestArms([new Dmg(6)]), new TestBody([new Dmg(14)]), new TestCore([new Dmg(1)]), new TestLegs([new Dmg(9)]));
            var robot2 = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            RobotComparisonReport expectedReport = new()
            {
                ComparisonResults =
                [
                    new ComparisonResult { CharacteristicName = "Dmg", FirstRobotCharacteristic = 30, SecondRobotCharacteristic = 0 },
                ]
            };

            RobotComparisonReport report = CompareRobotService.FormComparingReportForTwoRobots(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void TwoRobotsWithRepeatingCharacteristicsInEachPart_TwoSummedCharacteristicsReport()
        {
            var robot1 = CreateRobotFromParts(new TestArms([new Armor(7)]), new TestBody([new Armor(-1)]), new TestCore([new Armor(13)]), new TestLegs([new Armor(10)]));
            var robot2 = CreateRobotFromParts(new TestArms([new ActionSpeed(2)]), new TestBody([new ActionSpeed(-3)]), new TestCore([new ActionSpeed(4)]), new TestLegs([new ActionSpeed(7)]));

            RobotComparisonReport expectedReport = new()
            {
                ComparisonResults =
                [
                    new ComparisonResult { CharacteristicName = "ActionSpeed", FirstRobotCharacteristic = 0, SecondRobotCharacteristic = 10 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstRobotCharacteristic = 29, SecondRobotCharacteristic = 0 },
                ]
            };

            RobotComparisonReport report = CompareRobotService.FormComparingReportForTwoRobots(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
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
