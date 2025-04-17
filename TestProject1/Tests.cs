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
        private static Arms ArmsWithoutAdditionalCharacteristics = new Arms(1, 1, 1, []);
        private static Body BodyWithoutAdditionalCharacteristics = new Body(1, []);
        private static Core CoreWithoutAdditionalCharacteristics = new Core(1, 1, []);
        private static Legs LegsWithoutAdditionalCharacteristics = new Legs(1, 1, []);
        private static Arms ArmsWithOneAdditionalCharacteristic = new Arms(1, 1, 1, [new ImpactDistance(1)]);
        private static Body BodyWithOneAdditionalCharacteristic = new Body(1, [new Energy(1)]);
        private static Core CoreWithOneAdditionalCharacteristic = new Core(1, 1, [new Hp(1)]);
        private static Legs LegsWithOneAdditionalCharacteristic = new Legs(1, 1, [new Armor(1)]);
        private static Arms ArmsWithThreeAdditionalCharacteristic = new Arms(1, 1, 1, [new EnergyRestoration(1), new Shield(1), new ActionSpeed(1)]);
        private static Body BodyWithThreeAdditionalCharacteristic = new Body(1, [new Energy(1), new MovementSpeed(1), new Dmg(1)]);
        private static Core CoreWithThreeAdditionalCharacteristic = new Core(1, 1, [new Hp(1), new Dmg(1), new EnergyCost(1)]);
        private static Legs LegsWithThreeAdditionalCharacteristic = new Legs(1, 1, [new Armor(1), new Hp(1), new Dmg(1)]);

        public static IEnumerable<object[]> AddCharacteristicsToPartsData =>
        new List<object[]> {
                new object[] { ArmsWithoutAdditionalCharacteristics,
                    new List<RobotCharacteristicBase>() { new Dmg(1), new EnergyCost(1), new ImpactDistance(1) } },
                new object[] { BodyWithoutAdditionalCharacteristics,
                    new List<RobotCharacteristicBase>() { new Hp(1)} },
                new object[] { CoreWithoutAdditionalCharacteristics,
                    new List<RobotCharacteristicBase>() { new Energy(1), new EnergyRestoration(1)} },
                new object[] { LegsWithoutAdditionalCharacteristics,
                    new List<RobotCharacteristicBase>() { new ActionSpeed(1), new MovementSpeed(1)} },
                new object[] { ArmsWithOneAdditionalCharacteristic,
                    new List<RobotCharacteristicBase>() { new Dmg(1), new EnergyCost(1), new ImpactDistance(1), new ImpactDistance(1) } },
                new object[] { BodyWithOneAdditionalCharacteristic,
                    new List<RobotCharacteristicBase>() { new Hp(1), new Energy(1) } },
                new object[] { CoreWithOneAdditionalCharacteristic,
                    new List<RobotCharacteristicBase>() { new Energy(1), new EnergyRestoration(1), new Hp(1) } },
                new object[] { LegsWithOneAdditionalCharacteristic,
                    new List<RobotCharacteristicBase>() { new MovementSpeed(1), new ActionSpeed(1), new Armor(1) } },
                new object[] { ArmsWithThreeAdditionalCharacteristic,
                    new List<RobotCharacteristicBase>() { new Dmg(1), new EnergyCost(1), new ImpactDistance(1), new EnergyRestoration(1), new Shield(1), new ActionSpeed(1) } },
                new object[] { BodyWithThreeAdditionalCharacteristic,
                    new List<RobotCharacteristicBase>() { new Hp(1), new Energy(1), new MovementSpeed(1), new Dmg(1) } },
                new object[] { CoreWithThreeAdditionalCharacteristic,
                    new List<RobotCharacteristicBase>() { new Energy(1), new EnergyRestoration(1), new Hp(1), new Dmg(1), new EnergyCost(1) } },
                new object[] { LegsWithThreeAdditionalCharacteristic,
                    new List<RobotCharacteristicBase>() { new MovementSpeed(1), new ActionSpeed(1), new Armor(1), new Hp(1), new Dmg(1) } },
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

        [Theory]
        [MemberData(nameof(AddCharacteristicsToPartsData))]
        public void AddCharacteristicsToPart(RobotCharacteristicsBase part, List<RobotCharacteristicBase> expectedCharacteristics)
        {
            Assert.True(AssertEqualsCollections(expectedCharacteristics, part.RobotCharacteristics));
        }

        [Theory]
        [MemberData(nameof(CompareCharacteristicsData))]
        public void CompareCharacteristics(RobotCharacteristicsBase part, List<RobotCharacteristicBase> expectedCharacteristics)
        {
            Assert.True(AssertEqualsCollections(expectedCharacteristics, part.RobotCharacteristics));
        }

        public static bool AssertEqualsCollections(List<RobotCharacteristicBase> list1, List<RobotCharacteristicBase> list2)
        {
            if (list1 == null && list2 == null)
            {
                return true;
            }
            if (list1 == null || list2 == null)
            {
                return false;
            }
            if (list1.Count != list2.Count)
            {
                return false;
            }

            var sortedList1 = list1.OrderBy(c => c.GetType().Name).ToList();
            var sortedList2 = list2.OrderBy(c => c.GetType().Name).ToList();

            for (int i = 0; i < sortedList1.Count; i++)
            {
                var char1 = sortedList1[i];
                var char2 = sortedList2[i];

                if (char1.GetType() != char2.GetType())
                {
                    return false;
                }
                if(char1.Value != char2.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}