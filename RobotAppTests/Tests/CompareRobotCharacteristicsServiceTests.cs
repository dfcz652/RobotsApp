using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.Services;
using RobotApp.Services.Dtos;
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
        public void TwoEmptyRobot_EmptyCharacteristicSummary()
        {
            var robot1 = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            var robot2 = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            string expectedSummary = $"{"Robot1",22} | {"Robot2",3}";

            string summary = CompareRobotService.FormComparingForTwoRobots(robot1, robot2);

            Assert.Equal(expectedSummary, summary);
        }

        [Fact]
        public void OneEmptyRobotAndOneWithCharacteristicRobot_OneCharacteristicSummary()
        {
            var robot1 = CreateRobotFromParts(new TestArms([new Dmg(1)]), new TestBody(), new TestCore(), new TestLegs());
            var robot2 = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            string expectedSummary = 
                $"{"Robot1", 22} | {"Robot2", 3}\n" +
                $"{"Dmg" + ":", -18} {1, 3} | {0, 3}";

            string summary = CompareRobotService.FormComparingForTwoRobots(robot1, robot2);

            Assert.Equal(expectedSummary, summary);
        }

        [Fact]
        public void TwoRobotsWithNonRepeatingCharacteristics_NonRepeatingCharacteristicsSummary()
        {
            var robot1 = CreateRobotFromParts(new TestArms([new ImpactDistance(5)]), new TestBody([new Hp(10)]), new TestCore([new Energy(4)]), new TestLegs([new ActionSpeed(2)]));
            var robot2 = CreateRobotFromParts(new TestArms([new Dmg(15)]), new TestBody([new Armor(6)]), new TestCore([new EnergyRestoration(7)]), new TestLegs([new MovementSpeed(8)]));
            string expectedSummary =
                $"{"Robot1",22} | {"Robot2",3}\n" +
                $"{"ActionSpeed" + ":",-18} {2,3} | {0,3}" +
                $"\n{"Armor" + ":",-18} {0,3} | {6,3}" +
                $"\n{"Dmg" + ":",-18} {0,3} | {15,3}" +
                $"\n{"Energy" + ":",-18} {4,3} | {0,3}" +
                $"\n{"EnergyRestoration" + ":",-18} {0,3} | {7,3}" +
                $"\n{"Hp" + ":",-18} {10,3} | {0,3}" +
                $"\n{"ImpactDistance" + ":",-18} {5,3} | {0,3}" +
                $"\n{"MovementSpeed" + ":",-18} {0,3} | {8,3}";

            string summary = new CompareRobotCharacteristicsService().FormComparingForTwoRobots(robot1, robot2);

            Assert.Equal(expectedSummary, summary);
        }

        [Fact]
        public void OneEmptyRobotAndRobotWIthRepeatingCharacteristicsInEachPart_OneCharacteristicSummary()
        {
            var robot1 = CreateRobotFromParts(new TestArms([new Dmg(6)]), new TestBody([new Dmg(14)]), new TestCore([new Dmg(1)]), new TestLegs([new Dmg(9)]));
            var robot2 = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());
            string expectedSummary =
                $"{"Robot1",22} | {"Robot2",3}\n" +
                $"{"Dmg" + ":",-18} {30,3} | {0,3}";

            string summary = new CompareRobotCharacteristicsService().FormComparingForTwoRobots(robot1, robot2);

            Assert.Equal(expectedSummary, summary);
        }

        [Fact]
        public void TwoRobotsWithRepeatingCharacteristicsInEachPart_TwoCharacteristicsSummary()
        {
            var robot1 = CreateRobotFromParts(new TestArms([new Armor(7)]), new TestBody([new Armor(-1)]), new TestCore([new Armor(13)]), new TestLegs([new Armor(10)]));
            var robot2 = CreateRobotFromParts(new TestArms([new ActionSpeed(2)]), new TestBody([new ActionSpeed(-3)]), new TestCore([new ActionSpeed(4)]), new TestLegs([new ActionSpeed(7)]));
            string expectedSummary =
                $"{"Robot1",22} | {"Robot2",3}\n" +
                $"{"ActionSpeed" + ":",-18} {0,3} | {10,3}" +
                $"\n{"Armor" + ":",-18} {29,3} | {0,3}";

            string summary = new CompareRobotCharacteristicsService().FormComparingForTwoRobots(robot1, robot2);

            Assert.Equal(expectedSummary, summary);
        }
    }
}
