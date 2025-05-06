using RobotApp.RobotData.RobotParts;
using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotCharacteristics;
using RobotApp.RobotData.RobotEquipment.Arms;
using RobotApp.RobotData.RobotEquipment.Bodies;
using RobotApp.RobotData.RobotEquipment.Cores;
using RobotApp.RobotData.RobotEquipment.Legs;
using static RobotAppTests.Stubs.Parts;
using static RobotAppTests.Utils.TestUtils;

namespace RobotAppTests.Tests
{
    public class RobotAppTests
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

        public static IEnumerable<object[]> OneCharacteristicInEachPartData =>
        new List<object[]> {
            new object[] { new TestArms([new Dmg(20)]), new TestBody(), new TestCore(), new TestLegs(),
                    new List<RobotCharacteristicBase>() { new Dmg(20)} },
            new object[] { new TestArms(), new TestBody([new Hp(30)]), new TestCore(), new TestLegs(),
                    new List<RobotCharacteristicBase>() { new Hp(30)} },
            new object[] { new TestArms(), new TestBody(), new TestCore([new Energy(10)]), new TestLegs(),
                    new List<RobotCharacteristicBase>() { new Energy(10)} },
            new object[] { new TestArms(), new TestBody(), new TestCore(), new TestLegs([new MovementSpeed(5)]),
                    new List<RobotCharacteristicBase>() { new MovementSpeed(5)} },
        };

        public static IEnumerable<object[]> UnionCharacteristics_OnOneCharacteristicInAllPartsData =>
        new List<object[]> {
            new object[] { new TestArms([new Dmg(20)]), new TestBody([new Hp(25)]), new TestCore([new EnergyRestoration(0)]), new TestLegs([new ActionSpeed(12)]),
                    new List<RobotCharacteristicBase>() { new Dmg(20), new Hp(25), new EnergyRestoration(0), new ActionSpeed(12)} },
            new object[] { new TestArms([new Armor(3)]), new TestBody([new Shield(1)]), new TestCore([new ActionSpeed(5)]), new TestLegs([new ShieldCost(0)]),
                    new List<RobotCharacteristicBase>() { new Armor(3), new Shield(1), new ActionSpeed(5), new ShieldCost(0)} },
            new object[] { new TestArms([new Hp(2)]), new TestBody([new ShieldCost(2)]), new TestCore([new ImpactDistance(0)]), new TestLegs([new Dmg(9)]),
                    new List<RobotCharacteristicBase>() { new Hp(2), new ShieldCost(2), new ImpactDistance(0), new Dmg(9)} },
            new object[] { new TestArms([new ShieldCost(30)]), new TestBody([new MovementSpeed(14)]), new TestCore([new ActionSpeed(1)]), new TestLegs([new Energy(16)]),
                    new List<RobotCharacteristicBase>() { new ShieldCost(30), new MovementSpeed(14), new ActionSpeed(1), new Energy(16)} },
        };

        public static IEnumerable<object[]> CalculateCharacteristics_OnNegativeValuesData =>
        new List<object[]> {
            new object[] { new TestArms([new Dmg(20)]), new TestBody([new Dmg(-10), new Hp(4)]), new TestCore([new Dmg(5), new MovementSpeed(-6)]), new TestLegs([new MovementSpeed(12), new ActionSpeed(5)]),//p1(s1), p2(-s1, s2), p3(s1, -s3), p4(s3, s4)
                    new List<RobotCharacteristicBase>() { new Dmg(15), new Hp(4), new MovementSpeed(6), new ActionSpeed(5) } },
            new object[] { new TestArms([new Armor(-3)]), new TestBody([new Armor(-1)]), new TestCore([new ShieldCost(-13), new Energy(-5)]), new TestLegs([new Energy(-6), new EnergyRestoration(-4)]),//p1(-s1), p2(-s1), p3(-s2, -s3), p4(-s3, -s4)
                    new List<RobotCharacteristicBase>() { new Armor(-4), new ShieldCost(-13), new Energy(-11), new EnergyRestoration(-4) } },
        };

        public static IEnumerable<object[]> CalculateCharacteristics_OnSimpleWaysData =>
        new List<object[]> {
            new object[] { new TestArms([new Dmg(20)]), new TestBody([new Dmg(10)]), new TestCore([new Hp(5)]), new TestLegs([new ImpactDistance(12)]),//p1(s1), p2(s1), p3(2), p4(s3)
                    new List<RobotCharacteristicBase>() { new Dmg(30), new Hp(5), new ImpactDistance(12) } },
            new object[] { new TestArms([new Armor(3)]), new TestBody([new Armor(1)]), new TestCore([new Armor(13)]), new TestLegs([new Shield(6)]),//p1(s1), p2(s1), p3(s1), p4(s2)
                    new List<RobotCharacteristicBase>() { new Armor(17), new Shield(6) } },
            new object[] { new TestArms([new ActionSpeed(8)]), new TestBody([new ActionSpeed(2)]), new TestCore([new ActionSpeed(9)]), new TestLegs([new ActionSpeed(9)]),//p1(s1), p2(s1), p3(s1), p4(s1)
                    new List<RobotCharacteristicBase>() { new ActionSpeed(28)} },
            new object[] { new TestArms([new Dmg(8), new ImpactDistance(4)]), new TestBody([new Dmg(2), new ImpactDistance(13)]), new TestCore([new Dmg(9), new ImpactDistance(3)]), new TestLegs([new Dmg(7), new ImpactDistance(6)]),//p1(s1, s2), p2(s1, s2), p3(s1, s2), p4(s1, s2)
                    new List<RobotCharacteristicBase>() { new Dmg(26), new ImpactDistance(26)} },
            new object[] { new TestArms([new Shield(3)]), new TestBody([new Shield(2)]), new TestCore([new Hp(5)]), new TestLegs([new Hp(1)]),//p1(s1), p2(s1), p3(s2), p4(s2)
                    new List<RobotCharacteristicBase>() { new Shield(5), new Hp(6) } },
        };

        public static IEnumerable<object[]> CalculateCharacteristics_OnDifficultWaysData =>
        new List<object[]> {
            new object[] { new TestArms([new Dmg(20), new Hp(3)]), new TestBody([new Dmg(4)]), new TestCore([new Hp(5)]), new TestLegs([new Shield(12)]),//p1(s1, s2), p2(s1), p3(s2), p4(s3)
                    new List<RobotCharacteristicBase>() { new Dmg(24), new Hp(8), new Shield(12) } },
            new object[] { new TestArms([new Armor(4)]), new TestBody([new Armor(2), new ImpactDistance(6)]), new TestCore([new Armor(6), new ActionSpeed(8)]), new TestLegs([new ActionSpeed(22), new MovementSpeed(2)]),//p1(s1), p2(s1, s2), p3(s1, s3), p4(s3, s4)
                    new List<RobotCharacteristicBase>() { new Armor(12), new ImpactDistance(6), new ActionSpeed(30), new MovementSpeed(2) } },
            new object[] { new TestArms([new Dmg(5), new Shield(5), new EnergyRestoration(2), new ImpactDistance(4)]), new TestBody([new Hp(7), new ShieldCost(13), new ActionSpeed(11)]), new TestCore([new Hp(13), new Shield(6)]), new TestLegs([new Hp(2), new ShieldCost(14), new EnergyRestoration(3)]),//p1(s1, s3, s5, s7), p2(s2, s4, s6), p3(s1, s3), p4(s2, s4, s5)
                    new List<RobotCharacteristicBase>() { new Dmg(5), new Shield(11), new EnergyRestoration(5), new ImpactDistance(4), new Hp(22), new ShieldCost(27), new ActionSpeed(11) } },
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

        [Fact]
        public void AddNameToRobot()
        {
            Robot robot = new();

            robot.Name = "TestRobot";

            Assert.Equal("TestRobot", robot.Name);
        }

        [Fact]
        public void AddDefaultNameToRobot()
        {
            Robot robot = new();

            Assert.Equal("UnnamedRobot", robot.Name);
        }

        [Fact]
        public void UnionCharacteristics_OnEmptyParts()
        {
            Robot robot = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            AssertEqualsCollections(new List<RobotCharacteristicBase>(), robot.RobotCharacteristics);
        }

        [Theory]
        [MemberData(nameof(OneCharacteristicInEachPartData))]
        public void UnionCharacteristics_OnOneCharacteristicInPart(TestArms arms, TestBody body, TestCore core, TestLegs legs,
        List<RobotCharacteristicBase> expectedCharacteristics)
        {
            Robot robot = CreateRobotFromParts(arms, body, core, legs);

            AssertEqualsCollections(expectedCharacteristics, robot.RobotCharacteristics);
        }

        [Theory]
        [MemberData(nameof(UnionCharacteristics_OnOneCharacteristicInAllPartsData))]
        public void UnionCharacteristics_OnOneCharacteristicInAllParts(TestArms arms, TestBody body, TestCore core, TestLegs legs,
        List<RobotCharacteristicBase> expectedCharacteristics)
        {
            Robot robot = CreateRobotFromParts(arms, body, core, legs);

            AssertEqualsCollections(expectedCharacteristics, robot.RobotCharacteristics);
        }

        [Fact]
        public void UnionCharacteristics_OnMultipleCharacteristicInAllParts()
        {
            var arms = new TestArms([new Dmg(12), new Shield(2)]);
            var body = new TestBody([new Armor(23), new ShieldCost(1)]);
            var core = new TestCore([new Energy(12), new MovementSpeed(24), new ImpactDistance(33)]);
            var legs = new TestLegs([new ActionSpeed(0), new Hp(14), new EnergyRestoration(4)]);
            var expectedCharacteristics = new List<RobotCharacteristicBase>() { new Dmg(12), new Shield(2), new Armor(23), new ShieldCost(1), new Energy(12),
            new MovementSpeed(24), new ImpactDistance(33), new ActionSpeed(0), new Hp(14), new EnergyRestoration(4)};

            Robot robot = CreateRobotFromParts(arms, body, core, legs);

            AssertEqualsCollections(expectedCharacteristics, robot.RobotCharacteristics);
        }

        [Fact]
        public void CalculateCharacteristics_OnEmptyParts()
        {
            Robot robot = CreateRobotFromParts(new TestArms(), new TestBody(), new TestCore(), new TestLegs());

            AssertEqualsCollections(new List<RobotCharacteristicBase>(), robot.RobotCharacteristics);
        }

        [Theory]
        [MemberData(nameof(CalculateCharacteristics_OnSimpleWaysData))]
        public void CalculateCharacteristics_OnSimpleWays(TestArms arms, TestBody body, TestCore core, TestLegs legs,
            List<RobotCharacteristicBase> expectedCharacteristics)
        {
            Robot robot = CreateRobotFromParts(arms, body, core, legs);

            AssertEqualsCollections(expectedCharacteristics, robot.RobotCharacteristics);
        }

        [Theory]
        [MemberData(nameof(CalculateCharacteristics_OnNegativeValuesData))]
        public void CalculateCharacteristics_OnNegativeValues(TestArms arms, TestBody body, TestCore core, TestLegs legs,
            List<RobotCharacteristicBase> expectedCharacteristics)
        {
            Robot robot = CreateRobotFromParts(arms, body, core, legs);

            AssertEqualsCollections(expectedCharacteristics, robot.RobotCharacteristics);
        }

        [Theory]
        [MemberData(nameof(CalculateCharacteristics_OnDifficultWaysData))]
        public void CalculateCharacteristics_OnDifficultWays(TestArms arms, TestBody body, TestCore core, TestLegs legs,
            List<RobotCharacteristicBase> expectedCharacteristics)
        {
            Robot robot = CreateRobotFromParts(arms, body, core, legs);

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
                if (list1[i].Value != list2[i].Value)
                {
                    Assert.Fail();
                }
            }
            Assert.True(true);
        }
    }
}