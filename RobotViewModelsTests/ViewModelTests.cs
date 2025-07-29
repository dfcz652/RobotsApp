using Moq;
using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotEquipment.ArmsTypes;
using RobotApp.RobotData.RobotEquipment.BodyTypes;
using RobotApp.RobotData.RobotEquipment.CoreTypes;
using RobotApp.RobotData.RobotEquipment.LegsTypes;
using RobotApp.Services;
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

        public ViewModelTests () 
        {
            _robotsGatewayMock = new Mock<IRobotsGateway>();
            _comparisonReportServiceMock = new Mock<IItemComparisonService>();
            _formatterMock = new Mock<IRobotsComparisonFormatter>();

            _viewModel = new ViewModel(
                _robotsGatewayMock.Object,
                _comparisonReportServiceMock.Object,
                _formatterMock.Object);
        }

        [Fact]
        public void GetRobot_ShouldThrowRobotNotFoundException_WhenNoRobots()
        {
            _robotsGatewayMock.Setup(rg => rg.GetByName("NonExistingRobot")).Returns((Robot)null);

            var ex = Assert.Throws<RobotNotFoundException>(() => _viewModel.GetRobotByName("NonExistingRobot"));

            Assert.Equal("Robot with name 'NonExistingRobot' was not found", ex.Message);
        }

        [Fact]
        public void GetRobotByName_ShouldReturnRobot()
        {
            var robot = new Robot("testRobot");
            _robotsGatewayMock.Setup(rg => rg.GetByName("testRobot")).Returns(robot);

            Robot actual = _viewModel.GetRobotByName("testRobot");

            Assert.Equal("testRobot", actual.Name);
        }

        [Fact]
        public void RobotNameAndPartsNames_CreatedRobot()
        {
            var robot = new Robot("testRobot");
            robot.AddArms(new RocketArms());
            robot.AddBody(new ShieldedBody());
            robot.AddCore(new EnergeticCore());
            robot.AddLegs(new SpeedLegs());
            _robotsGatewayMock.Setup(rg => rg.GetByName("testRobot")).Returns(robot);
            _viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody",
                "EnergeticCore", "SpeedLegs");

            var actual = _viewModel.GetRobotByName("testRobot");

            Assert.Equal("testRobot", actual.Name);
            AssertEqualsCollections(new RocketArms().RobotCharacteristics, actual.Arms.RobotCharacteristics);
            AssertEqualsCollections(new ShieldedBody().RobotCharacteristics, actual.Body.RobotCharacteristics);
            AssertEqualsCollections(new EnergeticCore().RobotCharacteristics, actual.Core.RobotCharacteristics);
            AssertEqualsCollections(new SpeedLegs().RobotCharacteristics, actual.Legs.RobotCharacteristics);
        }

        [Theory]
        [InlineData("testRobot", "", "ShieldedBody", "EnergeticCore", "SpeedLegs")]
        [InlineData("testRobot", "RocketArms", "", "EnergeticCore", "SpeedLegs")]
        [InlineData("testRobot", "RocketArms", "ShieldedBody", "", "SpeedLegs")]
        [InlineData("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "")]
        public void RobotNameAndNonExistPartName_ThrowsInvalidDataException(string robotName,
            string chosenArms, string chosenBody, string chosenCore, string chosenLegs)
        {
            Assert.Throws<InvalidDataException>(() => _viewModel.CreateRobot(robotName, chosenArms, chosenBody, chosenCore, chosenLegs));
        }

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

        [Fact]
        public void CreateRobot_ShouldAddRobotNameIntoRobotsNames()
        {
            _viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.Contains("testRobot", _viewModel.RobotsNames);
        }

        [Fact]
        public void CreateTwoRobots_ShouldAddRobotsNamesIntoRobotsNames()
        {
            _viewModel.CreateRobot("testRobot1", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            _viewModel.CreateRobot("testRobot2", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.Contains("testRobot1", _viewModel.RobotsNames);
            Assert.Contains("testRobot2", _viewModel.RobotsNames);
        }

        [Fact]
        public void CreateRobot_ShouldRaiseRobotCreatedEvent_WithCorrectRobotName()
        {
            string receivedRobotName = string.Empty;
            _viewModel.RobotCreated += (sender, robotName) => receivedRobotName = robotName;

            _viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.Equal("testRobot", receivedRobotName);
        }

        [Fact]
        public void CreateComparisonReport_ShouldUpdateFormattedReport()
        {
            var robot1 = new Robot("RobotForReport1");
            var robot2 = new Robot("RobotForReport2");
            var report = new ItemComparisonReport("RobotForReport1", "RobotForReport2", new List<ComparisonResult>());
            _robotsGatewayMock.Setup(rg => rg.GetByName("RobotForReport1")).Returns(robot1);
            _robotsGatewayMock.Setup(rg => rg.GetByName("RobotForReport2")).Returns(robot2);
            _comparisonReportServiceMock.Setup(s => s.CreateItemComparisonReport(robot1, robot2)).Returns(report);
            _formatterMock.Setup(f => f.Format(report)).Returns("FormattedReportText");

            _viewModel.CreateAndFormatComparisonReport("RobotForReport1", "RobotForReport2");

            Assert.NotEmpty(_viewModel.FormattedReport);
        }

        [Fact]
        public void CreateComparisonReportForTwoArms_ShouldUpdateFormattedReport()
        {
            string expected =
                "            DefaultArms | DefaultArms" + "\r\n" +
                "Damage:               5 |   5" + "\r\n" +
                "Energy cost:          0 |   0" + "\r\n" +
                "Impact distance:      1 |   1" + "\r\n";
            var report = new ItemComparisonReport("DefaultArms", "DefaultArms", new List<ComparisonResult>());
            _comparisonReportServiceMock.Setup(s => s.CreateItemComparisonReport(
                It.IsAny<RobotCharacteristicsBase>(),
                It.IsAny<RobotCharacteristicsBase>())).Returns(report);
            _formatterMock.Setup(f => f.Format(report)).Returns(expected);

            _viewModel.CreateAndFormatComparisonReport("DefaultArms", "DefaultArms");

            Assert.Equal(expected, _viewModel.FormattedReport);
        }

        [Fact]
        public void GetPobot_ShouldReturnRobot()
        {
            var robot = new Robot("Robot1");
            _robotsGatewayMock.Setup(rg => rg.GetByName("Robot1")).Returns(robot);
            _viewModel.CreateRobot("Robot1", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            var actual = _viewModel.GetRobot("Robot1");

            Assert.Equal(_robotsGatewayMock.Object.GetByName("Robot1").GetType, actual.GetType);
        }

        [Fact]
        public void GetPartForArms_ShouldReturnPart()
        {
            DefaultArms arms = new();
            DefaultArms expected = new();

            var actual = _viewModel.GetPart(arms.GetType().Name);

            Assert.Equal(expected.GetType(), arms.GetType());
        }

        [Fact]
        public void GetPartForBody_ShouldReturnPart()
        {
            DefaultBody body = new();
            DefaultBody expected = new();

            var actual = _viewModel.GetPart(body.GetType().Name);

            Assert.Equal(expected.GetType(), body.GetType());
        }

        [Fact]
        public void GetPartForCore_ShouldReturnPart()
        {
            DefaultCore core = new();
            DefaultCore expected = new();

            var actual = _viewModel.GetPart(core.GetType().Name);

            Assert.Equal(expected.GetType(), core.GetType());
        }

        [Fact]
        public void GetPartForLegs_ShouldReturnPart()
        {
            DefaultLegs legs = new();
            DefaultLegs expected = new();

            var actual = _viewModel.GetPart(legs.GetType().Name);

            Assert.Equal(expected.GetType(), legs.GetType());
        }

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