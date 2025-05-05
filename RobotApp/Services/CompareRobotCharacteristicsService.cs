using RobotApp.RobotData.Base;
using RobotApp.Services.Dtos;
using RobotApp.RobotData;
using RobotAppTests.Tests;
using RobotApp.Services.Reports;

namespace RobotApp.Services
{
    public class CompareRobotCharacteristicsService
    {
        public RobotComparisonReport FormComparingReportForTwoRobots(Robot robot1, Robot robot2)
        {
            List<RobotCharacteristicDto> summaryFirstRobot = robot1.RobotCharacteristics.ToRobotCharacteristicsDtoList();
            List<RobotCharacteristicDto> summarySecondRobot = robot2.RobotCharacteristics.ToRobotCharacteristicsDtoList();

            var allCharacteristics = summaryFirstRobot.Select(dto => dto.Name)
                                             .Union(summarySecondRobot.Select(dto => dto.Name))
                                             .Distinct()
                                             .OrderBy(name => name);

            RobotComparisonReport report = new() { ComparisonResults = new List<ComparisonResult>()};

            foreach (var characteristicName in allCharacteristics)
            {
                var value1Dto = summaryFirstRobot.FirstOrDefault(dto => dto.Name == characteristicName);
                var value2Dto = summarySecondRobot.FirstOrDefault(dto => dto.Name == characteristicName);

                report.ComparisonResults.Add(new ComparisonResult
                {
                    CharacteristicName = characteristicName,
                    FirstRobotCharacteristic = value1Dto?.Value ?? 0,
                    SecondRobotCharacteristic = value2Dto?.Value ?? 0,
                });
            }
            return report;
        }

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
