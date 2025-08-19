using System.ComponentModel;
using Moq;
using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotEquipment.ArmsTypes;
using RobotApp.RobotData.RobotEquipment.BodyTypes;
using RobotApp.RobotData.RobotEquipment.CoreTypes;
using RobotApp.RobotData.RobotEquipment.LegsTypes;
using RobotApp.RobotData.RobotParts;
using RobotApp.Services;
using RobotApp.Services.Dtos;
using RobotApp.Services.Reports;
using RobotViewModels;
using RobotViewModels.Exceptions;
using RobotViewModels.Interfaces;

namespace RobotViewModelsTests
{
    public class ViewModelTests
    {
        private readonly Mock<IRobotsGateway> _robotsGatewayMock;
        private readonly Mock<IItemComparisonService> _comparisonReportServiceMock;
        private readonly Mock<IRobotsComparisonFormatter> _formatterMock;
        private readonly ViewModel _viewModel;

        public ViewModelTests()
        {
            _robotsGatewayMock = new Mock<IRobotsGateway>();
            _comparisonReportServiceMock = new Mock<IItemComparisonService>();
            _formatterMock = new Mock<IRobotsComparisonFormatter>();
            _viewModel = new ViewModel(
                _robotsGatewayMock.Object,
                _comparisonReportServiceMock.Object,
                _formatterMock.Object);
        }

        #region GetRobotByName
        [Fact]
        public void GetRobotByName_ShouldThrowRobotNotFoundException_WhenNoRobots()
        {
            var ex = Assert.Throws<RobotNotFoundException>(() => _viewModel.GetRobotByName("NonExistingRobot"));

            _robotsGatewayMock.Verify(x => x.GetByName("NonExistingRobot"), Times.Once);
            Assert.Equal("Robot with name 'NonExistingRobot' was not found", ex.Message);
        }

        [Fact]
        public void GetRobotByName_ShouldReturnRobot()
        {
            var robot = new Robot("testRobot");
            robot.AddArms(new RocketArms());
            robot.AddBody(new ShieldedBody());
            robot.AddCore(new EnergeticCore());
            robot.AddLegs(new SpeedLegs());
            _robotsGatewayMock.Setup(rg => rg.GetByName("testRobot")).Returns(robot);

            var actual = _viewModel.GetRobotByName("testRobot");

            _robotsGatewayMock.Verify(x => x.GetByName("testRobot"), Times.Once);
            Assert.Equal("testRobot", actual.Name);
            AssertEqualsCollections(new RocketArms().RobotCharacteristics, actual.Arms.RobotCharacteristics);
            AssertEqualsCollections(new ShieldedBody().RobotCharacteristics, actual.Body.RobotCharacteristics);
            AssertEqualsCollections(new EnergeticCore().RobotCharacteristics, actual.Core.RobotCharacteristics);
            AssertEqualsCollections(new SpeedLegs().RobotCharacteristics, actual.Legs.RobotCharacteristics);
        }
        #endregion

        #region GetPart
        [Fact]
        public void GetPartForArms_ShouldReturnPart()
        {
            string arms = "DefaultArms";
            DefaultArms expected = new();

            var actual = _viewModel.GetPart(arms);

            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void GetPartForBody_ShouldReturnPart()
        {
            string body = "DefaultBody";
            DefaultBody expected = new();

            var actual = _viewModel.GetPart(body);

            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void GetPartForCore_ShouldReturnPart()
        {
            string core = "DefaultCore";
            DefaultCore expected = new();

            var actual = _viewModel.GetPart(core);

            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void GetPartForLegs_ShouldReturnPart()
        {
            string legs = "DefaultLegs";
            DefaultLegs expected = new();

            var actual = _viewModel.GetPart(legs);

            Assert.Equal(expected.GetType(), actual.GetType());
        }
        #endregion

        #region GetExistingParts
        [Fact]
        public void GetExistingArms_ListofAllExistingArms()
        {
            List<string> expectedList = new() { "DefaultArms", "PistolArms", "RocketArms", "SpearArms", "SwordArms" };

            var actual = _viewModel.ExistingArms;

            Assert.Equal(expectedList, actual);
        }

        [Fact]
        public void GetExistingBodies_ListofAllExistingBodies()
        {
            List<string> expectedList = new() { "ArmouredBody", "DefaultBody", "ShieldedBody", "TankyBody" };

            var actual = _viewModel.ExistingBodies;

            Assert.Equal(expectedList, actual);
        }

        [Fact]
        public void GetExistingCores_ListofAllExistingCores()
        {
            List<string> expectedList = new() { "DefaultCore", "EnergeticCore", "LivingCore", "ProtectiveCore" };

            var actual = _viewModel.ExistingCores;

            Assert.Equal(expectedList, actual);
        }

        [Fact]
        public void GetExistingLegs_ListofAllExistingLegs()
        {
            List<string> expectedList = new() { "ArmouredLegs", "DefaultLegs", "RechargingLegs", "SpeedLegs" };

            var actual = _viewModel.ExistingLegs;

            Assert.Equal(expectedList, actual);
        }
        #endregion

        #region CreateRobot

        [Fact]
        public void CreateRobot_WithoutParts_ShouldAddRobotToGateway()
        {
            string robotName = "TestRobot";
            _viewModel.CreateEmptyRobot(robotName);

            _robotsGatewayMock.Verify(g => g.Add(It.Is<Robot>(r => r.Name == robotName)), Times.Once);
        }

        [Fact]
        public void UpdateRobot_ShouldUpdateRobotNameInGateway()
        {
            var existingRobot = new Robot("OldName");
            string newName = "UpdatedName";
            List<string> expected = new();
            _robotsGatewayMock.Setup(g => g.GetByName("OldName")).Returns(existingRobot);
            _formatterMock.Setup(f => f.FormatRobotCharacteristics(It.IsAny<List<RobotCharacteristicBase>>()))
            .Returns(expected);

            _viewModel.UpdateRobot(existingRobot.Name, newName);

            Assert.Empty(_viewModel.RobotCharacteristics);
        }

        [Fact]
        public void UpdateEmptyRobot_WhenNeedToUpdateFourParts_ShouldSetCharacteristicsIntoRobotCharacteristics()
        {
            var existingRobot = new Robot("EmptyRobot");
            List<string> expected = new();
            _robotsGatewayMock.Setup(g => g.GetByName("EmptyRobot")).Returns(existingRobot);
            _formatterMock.Setup(f => f.FormatRobotCharacteristics(It.IsAny<List<RobotCharacteristicBase>>()))
            .Returns(expected);

            _viewModel.UpdateRobot(existingRobot.Name,
                "RobotWithParts", "DefaultArms", "DefaultBody", "DefaultCore", "DefaultLegs");

            Assert.Equal(expected, _viewModel.RobotCharacteristics);
        }

        [Fact]
        public void CreateRobot_ShouldCreateRobotWithCorrectParts_AndAddToGateway()
        {
            var robotName = "testRobot";
            var armsName = "RocketArms";
            var bodyName = "ShieldedBody";
            var coreName = "EnergeticCore";
            var legsName = "SpeedLegs";

            Robot capturedRobot = null;

            _robotsGatewayMock
                .Setup(r => r.Add(It.IsAny<Robot>()))
                .Callback<Robot>(r => capturedRobot = r);

            _robotsGatewayMock
                .Setup(r => r.GetAllRobots())
                .Returns(() => new List<Robot> { capturedRobot! });

            _viewModel.CreateRobot(robotName, armsName, bodyName, coreName, legsName);

            _robotsGatewayMock.Verify(r => r.Add(It.IsAny<Robot>()), Times.Once);
            Assert.NotNull(capturedRobot);
            Assert.Equal(robotName, capturedRobot!.Name);
            Assert.IsType<RocketArms>(capturedRobot.Arms);
            Assert.IsType<ShieldedBody>(capturedRobot.Body);
            Assert.IsType<EnergeticCore>(capturedRobot.Core);
            Assert.IsType<SpeedLegs>(capturedRobot.Legs);
        }

        [Theory]
        [InlineData("testRobot", "", "ShieldedBody", "EnergeticCore", "SpeedLegs")]
        [InlineData("testRobot", "RocketArms", "", "EnergeticCore", "SpeedLegs")]
        [InlineData("testRobot", "RocketArms", "ShieldedBody", "", "SpeedLegs")]
        [InlineData("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "")]
        public void CreateRobot_ShouldThrowInvalidDataException(string robotName,
            string chosenArms, string chosenBody, string chosenCore, string chosenLegs)
        {
            Assert.Throws<InvalidDataException>(() => _viewModel.CreateRobot(robotName, chosenArms, chosenBody, chosenCore, chosenLegs));
        }

        [Fact]
        public void UpdateRobotsNames_ShouldClearPreviousNames()
        {
            _viewModel.RobotsNames.Add("OldName");

            _robotsGatewayMock.Setup(g => g.GetAllRobots()).Returns(new List<Robot>
            {
                new Robot("NewRobot")
            });

            _viewModel.UpdateRobotsNames();

            Assert.Single(_viewModel.RobotsNames);
            Assert.Contains("NewRobot", _viewModel.RobotsNames);
            Assert.DoesNotContain("OldName", _viewModel.RobotsNames);
        }

        [Fact]
        public void UpdateRobotsNames_ShouldFillRobotsNames()
        {
            var robots = new List<Robot>
            {
                new Robot("Robot1"),
                new Robot("Robot2")
            };

            _robotsGatewayMock.Setup(g => g.GetAllRobots()).Returns(robots);

            _viewModel.UpdateRobotsNames();

            Assert.Equal(2, _viewModel.RobotsNames.Count);
            Assert.Contains("Robot1", _viewModel.RobotsNames);
            Assert.Contains("Robot2", _viewModel.RobotsNames);
        }

        [Fact]
        public void CreateRobot_ShouldRaiseRobotCreatedEvent_WithCorrectRobotName()
        {
            string receivedRobotName = string.Empty;
            _robotsGatewayMock.Setup(g => g.GetAllRobots()).Returns(new List<Robot>
            {
                new Robot("testRobot")
            });
            _viewModel.RobotCreated += (sender, robotName) => receivedRobotName = robotName;

            _viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.Equal("testRobot", receivedRobotName);
        }
        #endregion

        #region CreateComparisonReport

        [Fact]
        public void CreateAndFormatPartReport_ShouldSetFormattedReport()
        {
            var partName = "DefaultArms";
            var characteristics = new List<ItemCharacteristicDto>
            {
                new ItemCharacteristicDto { Name = "Damage", Value = 5 },
                new ItemCharacteristicDto { Name = "Energy cost", Value = 0 },
                new ItemCharacteristicDto { Name = "Impact distance", Value = 1 }
            };
            var actual = "TestPart\r\n" +
                "------------------------------\r\n" +
                "Action speed:         3\r\n" +
                "Damage:               5\r\n";
            var expected =
                "TestPart\r\n" +
                "------------------------------\r\n" +
                "Action speed:         3\r\n" +
                "Damage:               5\r\n";
            _formatterMock.Setup(f => f.FormatPartDetails(
                It.IsAny<string>(),It.IsAny<List<ItemCharacteristicDto>>()))
                .Returns(actual);

            _viewModel.GetAndFormatPartCharacteristics(partName);

            _formatterMock.Verify(f => f.FormatPartDetails(partName, It.IsAny<List<ItemCharacteristicDto>>()), Times.Once);
            Assert.Equal(expected, _viewModel.PartInfo);
        }

        [Fact]
        public void CreateComparisonReport_ForTwoRobots_ShouldCreateFormatAndUpdateFormattedReport()
        {
            var robot1 = new Robot("RobotForReport1");
            var robot2 = new Robot("RobotForReport2");
            var report = new ItemComparisonReport("RobotForReport1", "RobotForReport2", new List<ComparisonResult>());
            _robotsGatewayMock.Setup(rg => rg.GetByName("RobotForReport1")).Returns(robot1);
            _robotsGatewayMock.Setup(rg => rg.GetByName("RobotForReport2")).Returns(robot2);
            _comparisonReportServiceMock.Setup(s => s.CreateReportForTwoItems(robot1, robot2)).Returns(report);
            _formatterMock.Setup(f => f.FormatTwoItems(report)).Returns("FormattedReportText");

            _viewModel.CreateAndFormatRobotsComparisonReport("RobotForReport1", "RobotForReport2");

            _robotsGatewayMock.Verify(x => x.GetByName("RobotForReport1"), Times.Once);
            _robotsGatewayMock.Verify(x => x.GetByName("RobotForReport2"), Times.Once);
            _comparisonReportServiceMock.Verify(x => x.CreateReportForTwoItems(robot1, robot2), Times.Once);
            _formatterMock.Verify(x => x.FormatTwoItems(report), Times.Once);
            Assert.NotEmpty(_viewModel.FormattedReport);
        }

        [Fact]
        public void CreateComparisonReport_ForTwoArms_ShouldCreateFormatAndUpdateFormattedReport()
        {
            string expected =
                "            DefaultArms | DefaultArms" + "\r\n" +
                "Damage:               5 |   5" + "\r\n" +
                "Energy cost:          0 |   0" + "\r\n" +
                "Impact distance:      1 |   1" + "\r\n";
            var report = new ItemComparisonReport("DefaultArms", "DefaultArms", new List<ComparisonResult>());
            _comparisonReportServiceMock.Setup(s => s.CreateReportForTwoItems(
                It.IsAny<RobotCharacteristicsBase>(),
                It.IsAny<RobotCharacteristicsBase>())).Returns(report);
            _formatterMock.Setup(f => f.FormatTwoItems(report)).Returns(expected);

            _viewModel.CreateAndFormatPartsComparisonReport("DefaultArms", "DefaultArms");

            _comparisonReportServiceMock.Verify(
                x => x.CreateReportForTwoItems(It.IsAny<RobotCharacteristicsBase>(), It.IsAny<RobotCharacteristicsBase>()),
                Times.Once);
            _formatterMock.Verify(x => x.FormatTwoItems(report), Times.Once);
            Assert.Equal(expected, _viewModel.FormattedReport);
        }
        #endregion

        private static void AssertEqualsCollections(List<RobotCharacteristicBase> list1, List<RobotCharacteristicBase> list2)
        {
            if (list1 == null && list2 == null)
            {
                Assert.Fail();
            }
            if (list1 == null || list2 == null)
            {
                Assert.Fail();
            }
            if (list1.Count != list2.Count)
            {
                Assert.Fail();
            }

            list1.Sort((c1, c2) => c1.GetType().Name.CompareTo(c2.GetType().Name));
            list2.Sort((c1, c2) => c1.GetType().Name.CompareTo(c2.GetType().Name));

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].GetType() != list2[i].GetType())
                {
                    Assert.Fail();
                }
                if (list1[i].Value != list2[i].Value)
                {
                    Assert.Fail();
                }
            }
            Assert.True(true);
        }
    }
}