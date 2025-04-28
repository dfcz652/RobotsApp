using RobotApp.RobotData.Base;
using RobotApp.Services.Dtos;
using RobotApp.RobotData;
using System.Reflection.PortableExecutable;

namespace RobotApp.Services
{
    public class CompareRobotCharacteristicsService
    {
        public void PrintCombinedCharacteristicsForTwoRobots(List<RobotCharacteristicBase> firstRobotCharacteristics,
            List<RobotCharacteristicBase> secondRobotCharacteristics)
        {
            Console.WriteLine($"{"Robot1",22} | {"Robot2",3}");

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
