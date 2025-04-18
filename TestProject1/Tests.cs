using System.Collections.Generic;
using RobotApp.Robot.RobotParts;
using RobotApp.Robot;
using RobotApp.Robot.Base;
using RobotApp.Robot.RobotCharacteristics;
using Newtonsoft.Json.Linq;
using RobotApp.Robot.RobotEquipment.Arms;
using RobotApp.Robot.RobotEquipment.Bodies;
using RobotApp.Robot.RobotEquipment.Cores;
using RobotApp.Robot.RobotEquipment.Legs;

namespace RobotAppTests
{
    public class Tests
    {
        public static IEnumerable<object[]> AddCharacteristicsToPartsData =>
    new List<object[]> {
            new object[] { new Arms(5, 10, 15, new List<RobotCharacteristicBase>()),
                    new List<RobotCharacteristicBase>() { new Dmg(5), new EnergyCost(10), new ImpactDistance(15) } },
            new object[] { new Body(8, new List<RobotCharacteristicBase>()),
                    new List<RobotCharacteristicBase>() { new Hp(8)} },
            new object[] { new Core(2, 9, new List<RobotCharacteristicBase>()),
                    new List<RobotCharacteristicBase>() { new Energy(2), new EnergyRestoration(9)} },
            new object[] { new Legs(10, 3, new List<RobotCharacteristicBase>()),
                    new List<RobotCharacteristicBase>() { new MovementSpeed(10), new ActionSpeed(3) } },
            new object[] { new Arms(1, 7, 4, new List<RobotCharacteristicBase>() { new ImpactDistance(4)}),
                    new List<RobotCharacteristicBase>() { new Dmg(1), new EnergyCost(7), new ImpactDistance(4), new ImpactDistance(4) } },
            new object[] { new Body(11, new List<RobotCharacteristicBase>() { new Energy(6)}),
                    new List<RobotCharacteristicBase>() { new Hp(11), new Energy(6) } },
            new object[] { new Core(14, 2, new List<RobotCharacteristicBase>() { new Hp(9)}),
                    new List<RobotCharacteristicBase>() { new Energy(14), new EnergyRestoration(2), new Hp(9) } },
            new object[] { new Legs(5, 16, new List<RobotCharacteristicBase>() { new Armor(1)}),
                    new List<RobotCharacteristicBase>() { new MovementSpeed(5), new ActionSpeed(16), new Armor(1) } },
            new object[] { new Arms(18, 1, 10, new List<RobotCharacteristicBase>() { new EnergyRestoration(1), new Shield(13), new ActionSpeed(10)}),
                    new List<RobotCharacteristicBase>() { new Dmg(18), new EnergyCost(1), new ImpactDistance(10), new EnergyRestoration(1), new Shield(13), new ActionSpeed(10) } },
            new object[] { new Body(7, new List<RobotCharacteristicBase>() { new Energy(4), new MovementSpeed(15), new Dmg(3)}),
                    new List<RobotCharacteristicBase>() { new Hp(7), new Energy(4), new MovementSpeed(15), new Dmg(3) } },
            new object[] { new Core(9, 6, new List<RobotCharacteristicBase>() { new Hp(12), new Dmg(8), new EnergyCost(11)}),
                    new List<RobotCharacteristicBase>() { new Energy(9), new EnergyRestoration(6), new Hp(12), new Dmg(8), new EnergyCost(11) } },
            new object[] { new Legs(3, 11, new List<RobotCharacteristicBase>() { new Armor(2), new Hp(14), new Dmg(1)}),
                    new List<RobotCharacteristicBase>() { new MovementSpeed(3), new ActionSpeed(11), new Armor(2), new Hp(14), new Dmg(1) } },
            };

        public static IEnumerable<object[]> CompareCharacteristicsData =>
        new List<object[]> {
                new object[] { new DefaultArms(),
                            new List<RobotCharacteristicBase>() { new Dmg(5), new EnergyCost(0), new ImpactDistance(1) } },
                new object[] { new PistolArms(),
                            new List<RobotCharacteristicBase>() { new Dmg(7), new EnergyCost(4), new ImpactDistance(6) } },
                new object[] { new RocketArms(),
                            new List<RobotCharacteristicBase>() { new Dmg(10), new EnergyCost(5), new ImpactDistance(10) } },
                new object[] { new SpearArms(),
                            new List<RobotCharacteristicBase>() { new Dmg(12), new EnergyCost(0), new ImpactDistance(4) } },
                new object[] { new SwordArms(),
                            new List<RobotCharacteristicBase>() { new Dmg(15), new EnergyCost(0), new ImpactDistance(2) } },
                new object[] { new DefaultBody(),
                    new List<RobotCharacteristicBase>() { new Hp(15) } },
                new object[] { new ArmouredBody(),
                    new List<RobotCharacteristicBase>() { new Hp(30), new Armor(4) } },
                new object[] { new TankyBody(),
                    new List<RobotCharacteristicBase>() { new Hp(50), new Armor(2) } },
                new object[] { new ShieldedBody(),
                    new List<RobotCharacteristicBase>() { new Hp(10), new Shield(10), new ShieldCost(2) } },
                new object[] { new DefaultCore(),
                    new List<RobotCharacteristicBase>() { new Energy(5), new EnergyRestoration(3) } },
                new object[] { new EnergeticCore(),
                    new List<RobotCharacteristicBase>() { new Energy(10), new EnergyRestoration(5) } },
                new object[] { new LivingCore(),
                    new List<RobotCharacteristicBase>() { new Energy(8), new EnergyRestoration(4), new Hp(10) } },
                new object[] { new ProtectiveCore(),
                    new List<RobotCharacteristicBase>() { new Energy(9), new EnergyRestoration(4), new Shield(5), new ShieldCost(1) } },
                new object[] { new DefaultLegs(),
                    new List<RobotCharacteristicBase>() { new MovementSpeed(2), new ActionSpeed(2) } },
                new object[] { new SpeedLegs(),
                    new List<RobotCharacteristicBase>() { new MovementSpeed(10), new ActionSpeed(5) } },
                new object[] { new ArmouredLegs(),
                    new List<RobotCharacteristicBase>() { new MovementSpeed(5), new ActionSpeed(2), new Armor(3) } },
                new object[] { new RechargingLegs(),
                    new List<RobotCharacteristicBase>() { new MovementSpeed(5), new ActionSpeed(2), new EnergyRestoration(3) } },
        };

        public static IEnumerable<object[]> AddArmsToRobotData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultArms() },
                new object[] { new Robot(), new PistolArms() },
                new object[] { new Robot(), new RocketArms() },
                new object[] { new Robot(), new SpearArms() },
                new object[] { new Robot(), new SwordArms() },
        };

        public static IEnumerable<object[]> AddBodyToRobotData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultBody() },
                new object[] { new Robot(), new ArmouredBody() },
                new object[] { new Robot(), new ShieldedBody() },
                new object[] { new Robot(), new TankyBody() },
        };

        public static IEnumerable<object[]> AddCoreToRobotData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultCore() },
                new object[] { new Robot(), new EnergeticCore() },
                new object[] { new Robot(), new LivingCore() },
                new object[] { new Robot(), new ProtectiveCore() },
        };

        public static IEnumerable<object[]> AddLegsToRobotData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultLegs() },
                new object[] { new Robot(), new ArmouredLegs() },
                new object[] { new Robot(), new RechargingLegs() },
                new object[] { new Robot(), new SpeedLegs() },
        };

        public static IEnumerable<object[]> AddArmsAndBodyToRobotData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultArms(), new DefaultBody() },
                new object[] { new Robot(), new PistolArms(), new ArmouredBody() },
                new object[] { new Robot(), new SpearArms(), new ShieldedBody() },
                new object[] { new Robot(), new RocketArms(), new TankyBody() },
        };

        public static IEnumerable<object[]> AddCoreAndLegsToRobotData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultCore(), new DefaultLegs() },
                new object[] { new Robot(), new EnergeticCore(), new ArmouredLegs() },
                new object[] { new Robot(), new LivingCore(), new RechargingLegs() },
                new object[] { new Robot(), new ProtectiveCore(), new SpeedLegs() },
        };

        public static IEnumerable<object[]> AddAllPartsToRobotData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultArms(), new DefaultBody(), new DefaultCore(), new DefaultLegs() },
                new object[] { new Robot(), new PistolArms(), new ArmouredBody(), new EnergeticCore(), new ArmouredLegs() },
                new object[] { new Robot(), new RocketArms(), new ShieldedBody(), new LivingCore(), new RechargingLegs() },
                new object[] { new Robot(), new SpearArms(), new TankyBody(), new ProtectiveCore(), new SpeedLegs() },
        };

        public static IEnumerable<object[]> CalculateRobotCharacteristicsData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultArms(), new DefaultBody(), new DefaultCore(), new DefaultLegs(),
                    new List<RobotCharacteristicBase>() { new Dmg(5), new EnergyCost(0), new ImpactDistance(1), new Hp(15), new Energy(5), new EnergyRestoration(3), new MovementSpeed(2), new ActionSpeed(2) } },
                new object[] { new Robot(), new DefaultArms(), new ArmouredBody(), new LivingCore(), new DefaultLegs(),
                    new List<RobotCharacteristicBase>() { new Dmg(5), new EnergyCost(0), new ImpactDistance(1), new Hp(40), new Armor(4), new Energy(8), new EnergyRestoration(4), new MovementSpeed(2), new ActionSpeed(2) } },
                new object[] { new Robot(), new DefaultArms(), new ArmouredBody(), new LivingCore(), new ArmouredLegs(),
                    new List<RobotCharacteristicBase>() { new Dmg(5), new EnergyCost(0), new ImpactDistance(1), new Hp(40), new Armor(7), new Energy(8), new EnergyRestoration(4), new MovementSpeed(5), new ActionSpeed(2) } },
        };

        public static IEnumerable<object[]> CalculateRobotCharacteristicsForBodyAndCoreData =>
        new List<object[]> {
                new object[] { new Robot(), new DefaultBody(), new DefaultCore(),
                    new List<RobotCharacteristicBase>() { new Dmg(5), new EnergyCost(0), new ImpactDistance(1), new Hp(15), new Energy(5), new EnergyRestoration(3), new MovementSpeed(2), new ActionSpeed(2) } },
                new object[] { new Robot(), new ShieldedBody(), new ProtectiveCore(),
                    new List<RobotCharacteristicBase>() { new Hp(10), new Shield(15), new ShieldCost(3), new Energy(9), new EnergyRestoration(4) } },
        };

        [Theory]
        [MemberData(nameof(AddCharacteristicsToPartsData))]
        public void AddCharacteristicsToPart(RobotCharacteristicsBase part, List<RobotCharacteristicBase> expectedCharacteristics)
        {
            AssertEqualsCollections(expectedCharacteristics, part.RobotCharacteristics);
        }

        [Theory]
        [MemberData(nameof(CompareCharacteristicsData))]
        public void VerifyCharacteristicsOfPredefinedParts(RobotCharacteristicsBase part, List<RobotCharacteristicBase> expectedCharacteristics)
        {
            AssertEqualsCollections(expectedCharacteristics, part.RobotCharacteristics);
        }

        [Fact]
        public void AddArmsToRobot()
        {
            var robot = new Robot();
            var arms = new DefaultArms();

            robot.AddArms(arms);

            Assert.Equal(arms, robot.Arms);
        }

        [Fact]
        public void AddBodyToRobot()
        {
            var robot = new Robot();
            var body = new DefaultBody();

            robot.AddBody(body);

            Assert.Equal(body, robot.Body);
        }

        [Fact]
        public void AddCoreToRobot()
        {
            var robot = new Robot();
            var core = new DefaultCore();

            robot.AddCore(core);

            Assert.Equal(core, robot.Core);
        }

        [Fact]
        public void AddLegsToRobot()
        {
            var robot = new Robot();
            var legs = new DefaultLegs();

            robot.AddLegs(legs);

            Assert.Equal(legs, robot.Legs);
        }

        [Fact]
        public void AddArmsAndBodyToRobot()
        {
            var robot = new Robot();
            var arms = new DefaultArms();
            var body = new DefaultBody();

            robot.AddArms(arms);
            robot.AddBody(body);

            Assert.Equal(arms, robot.Arms);
            Assert.Equal(body, robot.Body);
        }

        [Fact]
        public void AddCoreAndLegsToRobot()
        {
            var robot = new Robot();
            var core = new DefaultCore();
            var legs = new DefaultLegs();

            robot.AddCore(core);
            robot.AddLegs(legs);

            Assert.Equal(core, robot.Core);
            Assert.Equal(legs, robot.Legs);
        }

        [Fact]
        public void AddAllPartsToRobot()
        {
            var robot = new Robot();
            var arms = new DefaultArms();
            var body = new DefaultBody();
            var core = new DefaultCore();
            var legs = new DefaultLegs();

            robot.AddArms(arms);
            robot.AddBody(body);
            robot.AddCore(core);
            robot.AddLegs(legs);

            Assert.Equal(arms, robot.Arms);
            Assert.Equal(body, robot.Body);
            Assert.Equal(core, robot.Core);
            Assert.Equal(legs, robot.Legs);
        }

        [Theory]
        [MemberData(nameof(CalculateRobotCharacteristicsData))]
        public void CalculateRobotCharacteristics(Robot robot, Arms arms, Body body, Core core, Legs legs,
            List<RobotCharacteristicBase> expectedCharacteristics)
        {
            robot.AddArms(arms);
            robot.AddBody(body);
            robot.AddCore(core);
            robot.AddLegs(legs);

            AssertEqualsCollections(expectedCharacteristics, robot.RobotCharacteristics);
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
                if(list1[i].Value != list2[i].Value)
                {
                    Assert.Fail();
                }
            }
            Assert.True(true);
        }
    }
}