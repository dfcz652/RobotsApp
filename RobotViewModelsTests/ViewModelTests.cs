using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotEquipment.ArmsTypes;
using RobotApp.RobotData.RobotEquipment.BodyTypes;
using RobotApp.RobotData.RobotEquipment.CoreTypes;
using RobotApp.RobotData.RobotEquipment.LegsTypes;
using RobotApp.RobotData.RobotParts;
using RobotViewModels;

namespace RobotViewModelsTests
{
    public class ViewModelTests
    {
        private ViewModel viewModel = new();

        [Fact]
        public void RobotNameAndPartsNames_CreatedRobot()
        {
            var actual = viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", 
                "EnergeticCore", "SpeedLegs");

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
            Assert.Throws<InvalidDataException>(() => viewModel.CreateRobot(robotName, chosenArms, chosenBody, chosenCore, chosenLegs));
        }

        [Fact]
        public void GetAllExistingTypesForArms_ListofAllExistingArms()
        {
            List<string> expectedList = new() { "DefaultArms", "PistolArms", "RocketArms", "SpearArms", "SwordArms" };

            List<string> actualList = viewModel.GetAllExistingTypes<Arms>();

            Assert.Equal(expectedList, actualList);
        }

        [Fact]
        public void GetAllExistingTypesForBodies_ListofAllExistingBodies()
        {
            List<string> expectedList = new() { "ArmouredBody", "DefaultBody", "ShieldedBody", "TankyBody" };

            List<string> actualList = viewModel.GetAllExistingTypes<Body>();

            Assert.Equal(expectedList, actualList);
        }

        [Fact]
        public void GetAllExistingTypesForCores_ListofAllExistingCores()
        {
            List<string> expectedList = new() { "DefaultCore", "EnergeticCore", "LivingCore", "ProtectiveCore" };

            List<string> actualList = viewModel.GetAllExistingTypes<Core>();

            Assert.Equal(expectedList, actualList);
        }

        [Fact]
        public void GetAllExistingTypesForLegs_ListofAllExistingLegs()
        {
            List<string> expectedList = new() { "ArmouredLegs", "DefaultLegs", "RechargingLegs", "SpeedLegs" };

            List<string> actualList = viewModel.GetAllExistingTypes<Legs>();

            Assert.Equal(expectedList, actualList);
        }

        [Fact]
        public void CreateRobot_FormattedReportShouldBeCleared()
        {
            viewModel.FormattedReport = "Test report";

            viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.True(string.IsNullOrEmpty(viewModel.FormattedReport));
        }

        [Fact]
        public void CreateComparisonReport_ShouldUpdateFormattedReport()
        {
            var robot1 = viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");
            var robot2 = viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            var report = viewModel.CreateAndFormatComparisonReport(robot1, robot2);

            Assert.Equal(report, viewModel.FormattedReport);
        }

        [Fact]
        public void CreateRobot_ShouldClearCreatedRobots_WhenCountEqualsTwo()
        {
            viewModel.CreatedRobots.Add(new Robot("robot1"));
            viewModel.CreatedRobots.Add(new Robot("robot2"));

            viewModel.CreateRobot("testRobot", "RocketArms", "ShieldedBody", "EnergeticCore", "SpeedLegs");

            Assert.Empty(viewModel.CreatedRobots);
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