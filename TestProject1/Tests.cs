using System.Collections.Generic;
using RobotApp.Robot.RobotParts;
using RobotApp.Robot;
using RobotApp.Robot.Base;
using RobotApp.Robot.RobotCharacteristics;
using Newtonsoft.Json.Linq;

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

        [Theory]
        [MemberData(nameof(AddCharacteristicsToPartsData))]
        public void AddCharacteristicsToPart(RobotCharacteristicsBase part, List<RobotCharacteristicBase> expectedCharacteristics)
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