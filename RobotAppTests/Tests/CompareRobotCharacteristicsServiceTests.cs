using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.Services;
using RobotApp.Services.Dtos;
using RobotApp.Services.Utils;
using static RobotAppTests.Stubs.Parts;
using static RobotAppTests.Utils.TestUtils;

namespace RobotAppTests.Tests
{
    public class CompareRobotCharacteristicsServiceTests
    {
        public static IEnumerable<object[]> ConvertCharacteristicData =>//RobotCharacteristicBase characteristic
        new List<object[]> {
            new object[] { new Dmg(3) },//usual case
            new object[] { new Armor(-10) }//negative value case
        };

        [Fact]
        public void EmptyRobot_GivesEmptyCharacteristicsDtoList()
        {
            var robot = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            List<RobotCharacteristicDto> robotCharacteristics = new CompareRobotUtils().GetRobotCharacteristicsDtoList(robot);

            Assert.Empty(robotCharacteristics);
        }

        [Fact]
        public void RobotWithOneCharacteristicInPart_GivesOneCharacteristicDtoList()
        {
            var arms = new TestArms([new Dmg(13)]);

            var robot = CreateRobotFromParts(arms, new TestBody(), new TestCore(), new TestLegs());
            List<RobotCharacteristicDto> robotCharacteristicDtos = new CompareRobotUtils().GetRobotCharacteristicsDtoList(robot);

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
            List<RobotCharacteristicDto> robotCharacteristicDtos = new CompareRobotUtils().GetRobotCharacteristicsDtoList(robot);

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
    }
}
