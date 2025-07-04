using RobotApp.Services.Reports;
using RobotApp.Services;
using static RobotAppTests.Stubs.Parts;
using static RobotAppTests.Utils.TestUtils;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData;

namespace RobotAppTests.Tests
{
    public class CreateItemComparisonReportTests
    {
        private IRobotService _robotService;

        public CreateItemComparisonReportTests()
        {
            _robotService = new CompareRobotCharacteristicsService();
        }
        [Fact]
        public void TwoEmptyRobots_EmptyComparisonReports()
        {
            var robot1 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            var robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            ItemComparisonReport report = _robotService.CreateItemComparisonReport(robot1, robot2);

            Assert.Empty(report.ComparisonResults);
        }

        [Fact]
        public void OneEmptyRobotAndOneRobotWithCharacteristic_OneCharacteristicComparsionReport()
        {
            var robot1 = CreateRobot(new TestArms([new Dmg(1)]), new TestBody(), new TestCore(), new TestLegs());
            var robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            ItemComparisonReport report = _robotService.CreateItemComparisonReport(robot1, robot2);

            Assert.Equal("Dmg", report.ComparisonResults[0].CharacteristicName);
            Assert.Equal(1, report.ComparisonResults[0].FirstItemCharacteristic);
            Assert.Equal(0, report.ComparisonResults[0].SecondItemCharacteristic);
        }

        [Fact]
        public void TwoRobotsWithNonRepeatingCharacteristics_NonRepeatingCharacteristicsComparsionReport()
        {
            var robot1 = CreateRobot(new TestArms([new ImpactDistance(5)]), new TestBody([new Hp(10)]), new TestCore([new Energy(4)]), new TestLegs([new ActionSpeed(2)]));
            var robot2 = CreateRobot(new TestArms([new Dmg(15)]), new TestBody([new Armor(6)]), new TestCore([new EnergyRestoration(7)]), new TestLegs([new MovementSpeed(8)]));

            List<ComparisonResult> comparisonResults = [
                    new ComparisonResult { CharacteristicName = "ActionSpeed", FirstItemCharacteristic = 2, SecondItemCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstItemCharacteristic = 0, SecondItemCharacteristic = 6 },
                    new ComparisonResult { CharacteristicName = "Dmg", FirstItemCharacteristic = 0, SecondItemCharacteristic = 15 },
                    new ComparisonResult { CharacteristicName = "Energy", FirstItemCharacteristic = 4, SecondItemCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "EnergyRestoration", FirstItemCharacteristic = 0, SecondItemCharacteristic = 7 },
                    new ComparisonResult { CharacteristicName = "Hp", FirstItemCharacteristic = 10, SecondItemCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "ImpactDistance", FirstItemCharacteristic = 5, SecondItemCharacteristic = 0 },
                    new ComparisonResult { CharacteristicName = "MovementSpeed", FirstItemCharacteristic = 0, SecondItemCharacteristic = 8 }
            ];

            ItemComparisonReport expectedReport = new("", "", comparisonResults);

            ItemComparisonReport report = _robotService.CreateItemComparisonReport(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void CreateReportForTwoEmptyArms_ShouldReturnComparisonReport()
        {
            ItemComparisonReport report = _robotService.CreateItemComparisonReport(new TestArms(), new TestArms());

            Assert.Equal("TestArms", report.FirstItemName);
            Assert.Equal("TestArms", report.SecondItemName);
            Assert.Empty(report.ComparisonResults);
        }

        [Fact]
        public void CreateReportForEmptyArmsAndArmsWithOneCharacteristic_ShouldReturnOneCharacteristicComparisonReport()
        {
            ItemComparisonReport report = _robotService.CreateItemComparisonReport(new TestArms(), new TestArms([new Dmg(10)]));

            Assert.Equal("Dmg", report.ComparisonResults[0].CharacteristicName);
            Assert.Equal(0, report.ComparisonResults[0].FirstItemCharacteristic);
            Assert.Equal(10, report.ComparisonResults[0].SecondItemCharacteristic);
        }

        [Fact]
        public void CreateReportForTwoCoresWithThreeCharacteristicsInEach_ShouldReturnComparisonReport()
        {
            List<ComparisonResult> expectedComparisonResults = [
                    new ComparisonResult { CharacteristicName = "Energy", FirstItemCharacteristic = 4, SecondItemCharacteristic = 8 },
                    new ComparisonResult { CharacteristicName = "EnergyRestoration", FirstItemCharacteristic = 2, SecondItemCharacteristic = 4 },
                    new ComparisonResult { CharacteristicName = "Hp", FirstItemCharacteristic = 10, SecondItemCharacteristic = 20 }
                    ];

            ItemComparisonReport report = _robotService.CreateItemComparisonReport(
                new TestCore([new Energy(4), new EnergyRestoration(2), new Hp(10)]),
                new TestCore([new Energy(8), new EnergyRestoration(4), new Hp(20)]));

            AssertEqualsComparisonResultCollections(expectedComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void OneEmptyRobotAndRobotWithRepeatingCharacteristicsInEachPart_OneSummedCharacteristicReport()
        {
            var robot1 = CreateRobot(new TestArms([new Dmg(6)]), new TestBody([new Dmg(14)]), new TestCore([new Dmg(1)]), new TestLegs([new Dmg(9)]));
            var robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            ItemComparisonReport expectedReport = new("", "",
                [
                    new ComparisonResult { CharacteristicName = "Dmg", FirstItemCharacteristic = 30, SecondItemCharacteristic = 0 }
                ]);


            ItemComparisonReport report = _robotService.CreateItemComparisonReport(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void TwoRobotsWithRepeatingCharacteristicsInEachPart_TwoSummedCharacteristicsReport()
        {
            var robot1 = CreateRobot(new TestArms([new Armor(7)]), new TestBody([new Armor(-1)]), new TestCore([new Armor(13)]), new TestLegs([new Armor(10)]));
            var robot2 = CreateRobot(new TestArms([new ActionSpeed(2)]), new TestBody([new ActionSpeed(-3)]), new TestCore([new ActionSpeed(4)]), new TestLegs([new ActionSpeed(7)]));

            List<ComparisonResult> comparisonResults =
                [
                    new ComparisonResult { CharacteristicName = "ActionSpeed", FirstItemCharacteristic = 0, SecondItemCharacteristic = 10 },
                    new ComparisonResult { CharacteristicName = "Armor", FirstItemCharacteristic = 29, SecondItemCharacteristic = 0 },
                ];

            ItemComparisonReport expectedReport = new("", "", comparisonResults);

            ItemComparisonReport report = _robotService.CreateItemComparisonReport(robot1, robot2);

            AssertEqualsComparisonResultCollections(expectedReport.ComparisonResults, report.ComparisonResults);
        }

        [Fact]
        public void OneEmptyNameRobotAndOneRobotWithName_OneRobotNameReport()
        {
            Robot robot1 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs(), "TestRobot");
            Robot robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            ItemComparisonReport report = _robotService.CreateItemComparisonReport(robot1, robot2);

            Assert.Equal("TestRobot", report.FirstItemName);
        }

        [Fact]
        public void TwoRobotsWithNames_TwoRobotNameReport()
        {
            Robot robot1 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs(), "TestRobot1");
            Robot robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs(), "TestRobot2");

            ItemComparisonReport report = _robotService.CreateItemComparisonReport(robot1, robot2);

            Assert.Equal("TestRobot1", report.FirstItemName);
            Assert.Equal("TestRobot2", report.SecondItemName);
        }

        [Fact]
        public void TwoRobotsWithoutNames_TwoUnnamedRobotNameReport()
        {
            Robot robot1 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            Robot robot2 = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            ItemComparisonReport report = _robotService.CreateItemComparisonReport(robot1, robot2);

            Assert.Equal("UnnamedRobot", report.FirstItemName);
            Assert.Equal("UnnamedRobot", report.SecondItemName);
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
                Assert.Equal(list1[i].FirstItemCharacteristic, list2[i].FirstItemCharacteristic);
                Assert.Equal(list1[i].SecondItemCharacteristic, list2[i].SecondItemCharacteristic);
            }
        }
    }
}
