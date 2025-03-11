using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using RobotApp.RobotCharacteristics;

namespace RobotApp.Services
{
    internal class RobotService
    {

        public List<RobotCharacteristicBase> AddAllParts(Robot robot)
        {

            var allCharacteristics = new List<RobotCharacteristicBase>();
            allCharacteristics.AddRange(robot.Core.RobotCharacteristics);
            allCharacteristics.AddRange(robot.Arms.RobotCharacteristics);
            allCharacteristics.AddRange(robot.Body.RobotCharacteristics);
            allCharacteristics.AddRange(robot.Legs.RobotCharacteristics);

            return allCharacteristics;
        }

        public List<RobotCharacteristicBase> CombineCharacteristics(List<RobotCharacteristicBase> allCharacteristics)
        {
            //групую х-ки за їхніми типами
            return allCharacteristics.GroupBy(characteristic => characteristic.GetType())

                //обєднання значень х-к
                .Select(group =>
                {
                    //беремо першу х-ку з групи 
                    var firstCharacteristic = group.First();

                    //обчислюємо суму значень усіх х-к у групі 
                    firstCharacteristic.Value = group.Sum(characteristic => characteristic.Value);

                    return firstCharacteristic;
                }).ToList();
        }

        public void PrintCombinedCharacteristicsForTwoRobots(List<RobotCharacteristicBase> firstRobotCharacteristics,
            List<RobotCharacteristicBase> secondRobotCharacteristics)
        {
            Console.WriteLine($"{"Robot1", 22} | {"Robot2", 3}");

            //перетворення в словник в якому перше - ключ, друге - значення
            var firstRobotDict = firstRobotCharacteristics.ToDictionary(characteristic => characteristic.GetType().Name,
                characteristic => characteristic.Value);
            var secondRobotDict = secondRobotCharacteristics.ToDictionary(characteristic => characteristic.GetType().Name,
                characteristic => characteristic.Value);

            //обєднуємо в один словнк і сортуємо
            var allCharacteristics = firstRobotDict.Keys.Union(secondRobotDict.Keys).OrderBy(element => element);

            //беремо значення і виводимо, якщо значення немає виводиться дефолт - 0
            foreach (var characteristicName in allCharacteristics)
            {
                int firstValue = firstRobotDict.GetValueOrDefault(characteristicName, 0);
                int secondValue = secondRobotDict.GetValueOrDefault(characteristicName, 0);

                Console.WriteLine($"{characteristicName + ":",-18} {firstValue,3} | {secondValue,3}");
            }

        }
    }
}
