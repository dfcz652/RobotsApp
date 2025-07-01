using System.Reflection;
using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotEquipment.ArmsTypes;
using RobotApp.RobotData.RobotEquipment.BodyTypes;
using RobotApp.RobotData.RobotEquipment.CoreTypes;
using RobotApp.RobotData.RobotEquipment.LegsTypes;
using RobotApp.RobotData.RobotParts;
using RobotApp.Services;
using RobotViewModels;
using RobotViewModels.Exceptions;

namespace RobotViewModelsTests
{
    public class ViewModelTests
    {
        private readonly IRobotsGateway _robotsGateway;
        private readonly ViewModel _viewModel;

        public ViewModelTests () 
        {
            _robotsGateway = new RobotsGatewayInMemory();
            _viewModel = new ViewModel(_robotsGateway);
        }

        [Fact]
        public void GetRobot_ShouldThrowRobotNotFoundException_WhenNoRobots()
        {
            Assert.Throws<RobotNotFoundException>(() => _viewModel.GetRobotByName("robot1"));
        }

        [Fact]
        public void GetRobotByName_ShouldReturnRobot()
        {
            _viewModel.CreateRobot("robot1", "RocketArms", "ShieldedBody",
                "EnergeticCore", "SpeedLegs");

            Robot actual = _viewModel.GetRobotByName("robot1");

            Assert.Equal("robot1", actual.Name);
        }

        [Fact]
        public void RobotNameAndPartsNames_CreatedRobot()
        {
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
        public void WhenChangingReport_RaisesOnPropertyChanges()
        {
            string changedPropertyName = null;
            _viewModel.PropertyChanged += (sender, args) => changedPropertyName = args.PropertyName;
            
            _viewModel.FormattedReport = "TestReport";

            Assert.Equal(nameof(ViewModel.FormattedReport), changedPropertyName);
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
        public void CreateRobot_RaisesRobotCreatedEvent_ShouldClearFormattedReport()
        {
            _viewModel.FormattedReport = "Test report";

            _viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.Equal(string.Empty, _viewModel.FormattedReport);
        }

        [Fact]
        public void CreateRobot_RaisesRobotCreatedEvent_ShouldSetRobotName()
        {
            string receivedRobotName = null;
            _viewModel.RobotCreated += (sender, robotName) => receivedRobotName = robotName;

            _viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.Equal("testRobot", receivedRobotName);
        }

        [Fact]
        public void CreateRobot_ShouldClearCreatedRobotsWhenCountEqualsTwo()
        {
            _viewModel.CreateRobot("testRobot1", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            _viewModel.CreateRobot("testRobot2", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            _viewModel.CreateRobot("testRobot3", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            
            Assert.Equal(0, _robotsGateway.Count);
        }

        [Fact]
        public void CreateComparisonReport_ShouldUpdateFormattedReport()
        {
            _viewModel.CreateRobot("testRobot1", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            _viewModel.CreateRobot("testRobot2", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            var robot1 = _robotsGateway.GetByName("testRobot1");
            var robot2 = _robotsGateway.GetByName("testRobot2");

            _viewModel.CreateAndFormatComparisonReport();

            Assert.NotEmpty(_viewModel.FormattedReport);
        }

        [Fact]
        public void HasExactlyTwoRobots_ShouldReturnTrue_WhenRobotCountIsTwo()
        {
            _viewModel.CreateRobot("testRobot1", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            _viewModel.CreateRobot("testRobot2", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            bool actual = _viewModel.HasExactlyTwoRobots();

            Assert.True(actual);
        }

        [Fact]
        public void HasExactlyTwoRobots_ShouldReturnFalse_WhenRobotCountIsNotTwo()
        {
            _viewModel.CreateRobot("testRobot1", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            bool actual = _viewModel.HasExactlyTwoRobots();

            Assert.False(actual);
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