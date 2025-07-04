using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.Services.Dtos;
using static RobotAppTests.Stubs.Parts;
using static RobotAppTests.Utils.TestUtils;

namespace RobotAppTests.Tests
{
    public class ItemCharacteristicDtosTests
    {
        public static IEnumerable<object[]> ConvertCharacteristicData =>//RobotCharacteristicBase characteristic
        new List<object[]> {
            new object[] { new Dmg(3), "Damage" },//usual case
            new object[] { new Armor(-10), "Armor" }//negative value case
        };

        [Fact]
        public void EmptyRobot_GivesEmptyCharacteristicsDtoList()
        {
            var robot = CreateRobot(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            List<ItemCharacteristicDto> robotCharacteristics = robot.RobotCharacteristics.ToItemCharacteristicsDtoList();

            Assert.Empty(robotCharacteristics);
        }

        [Fact]
        public void RobotWithOneCharacteristicInPart_GivesOneCharacteristicDtoList()
        {
            var arms = new TestArms([new Dmg(13)]);

            var robot = CreateRobot(arms, new TestBody(), new TestCore(), new TestLegs());

            List<ItemCharacteristicDto> robotCharacteristicDtos = robot.RobotCharacteristics.ToItemCharacteristicsDtoList();

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

            var robot = CreateRobot(arms, body, core, legs);

            List<ItemCharacteristicDto> robotCharacteristicDtos = robot.RobotCharacteristics.ToItemCharacteristicsDtoList();

            Assert.Equal(4, robotCharacteristicDtos.Count);
            Assert.Contains("Dmg", robotCharacteristicDtos.Select(cn => cn.Name));
            Assert.Contains(4, robotCharacteristicDtos.Select(cv => cv.Value));
        }

        [Fact]
        public void EmptyCharacteristic_ConvertIntoCharacteristicDto_ShouldReturnInvalidDataException()
        {
            var characteristic = new RobotCharacteristicBase();

            var dto = characteristic.ToItemCharacteristicDto();

            Assert.Equal("RobotCharacteristicBase", dto.Name);
            Assert.Equal(0, dto.Value);
        }

        [Theory]
        [MemberData(nameof(ConvertCharacteristicData))]
        public void Characteristic_ConvertIntoCharacteristicDto(RobotCharacteristicBase characteristic, string expectedDisplayName)
        {
            ItemCharacteristicDto dto = characteristic.ToItemCharacteristicDto();

            Assert.Equal(characteristic.GetType().Name, dto.Name);
            Assert.Equal(characteristic.Value, dto.Value);
        }
    }
}
