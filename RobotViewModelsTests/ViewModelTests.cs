using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotEquipment.ArmsTypes;
using RobotApp.RobotData.RobotEquipment.BodyTypes;
using RobotApp.RobotData.RobotEquipment.CoreTypes;
using RobotApp.RobotData.RobotEquipment.LegsTypes;
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
            var ex = Assert.Throws<RobotNotFoundException>(() => _viewModel.GetRobotByName("NonExistingRobot"));
            Assert.Equal("Robot with name 'NonExistingRobot' was not found", ex.Message);
        }

        [Fact]
        public void GetRobotByName_ShouldReturnRobot()
        {
            _viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody",
                "EnergeticCore", "SpeedLegs");

            Robot actual = _viewModel.GetRobotByName("testRobot");

            Assert.Equal("testRobot", actual.Name);
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
        public void CreateRobot_ShouldClearFormattedReport()
        {
            _viewModel.FormattedReport = "Test report";

            _viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.Equal(string.Empty, _viewModel.FormattedReport);
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
            _viewModel.CreateRobot("RobotForReport1", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            _viewModel.CreateRobot("RobotForReport2", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            
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

            _viewModel.CreateAndFormatComparisonReport("DefaultArms", "DefaultArms");

            Assert.Equal(expected, _viewModel.FormattedReport);
        }

        [Fact]
        public void GetPobot_ShouldReturnRobot()
        {
            _viewModel.CreateRobot("Robot1", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            var actual = _viewModel.GetRobot("Robot1");

            Assert.Equal(_robotsGateway.GetByName("Robot1").GetType, actual.GetType);
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

        [Fact]
        public void GetAllPartsInNamespace_ShouldReturnAllRobotParts()
        {
            string currentNamespace = "RobotApp.RobotData.RobotParts";
            List<string> expected = new()
            {
                "Arms", "Body", "Core", "Legs"
            };

            List<string> actual = _viewModel.GetAllNamesInNamespace<RobotCharacteristicsBase>(currentNamespace);

            Assert.Equal(expected, actual);
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