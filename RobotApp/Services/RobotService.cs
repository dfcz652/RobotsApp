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

            var combinedCharacteristics = new List<RobotCharacteristicBase>();

            foreach (var characteristic in allCharacteristics)
            {
                bool characteristicAdded = false;//флажок який вказує чи х-ка буде додана до списку, чи обєднана

                for (int i = 0; i < combinedCharacteristics.Count; i++)
                {
                    if (characteristic.GetType() == combinedCharacteristics[i].GetType())//якщо тип х-ки збігається з типом поточного обєкта в combinedChar
                    {
                        combinedCharacteristics[i].Value += characteristic.Value;//обєднуємо значення однакових х-к
                        characteristicAdded = true;
                        break;
                    }
                }

                if (!characteristicAdded)//якщо х-ка не обєднана
                {
                    combinedCharacteristics.Add(characteristic);
                }
            }

            return combinedCharacteristics;
        }

        public void PrintCombinedCharacteristicsForTwoRobots(List<RobotCharacteristicBase> firstRobotCharacteristics,
            List<RobotCharacteristicBase> secondRobotCharacteristics)
        {
            Console.WriteLine("                Robot1 | Robot2");
            //виведення х-к першого робота і тих самих другого робота
            foreach (var characteristic in firstRobotCharacteristics)
            {
                int value2 = FindCharacteristicValue(secondRobotCharacteristics, characteristic.GetType().Name);

                Console.WriteLine($"{characteristic.GetType().Name + ":",-18} {characteristic.Value,3} | {value2,3}");
            }

            // Виводимо х-ки другого робота яких немає у першого
            foreach (var characteristic in secondRobotCharacteristics)
            {
                if (FindCharacteristicValue(firstRobotCharacteristics, characteristic.GetType().Name) == 0)
                {

                    Console.WriteLine($"{characteristic.GetType().Name + ":",-18} {0,3} | {characteristic.Value,3}");
                }
            }

        }
        //шукаємо х-ки
        public int FindCharacteristicValue(List<RobotCharacteristicBase> robotCharacteristics, string characteristicName)
        {
            foreach (var characteristic in robotCharacteristics)
            {
                if (characteristic.GetType().Name == characteristicName)
                {
                    return characteristic.Value;
                }
            }
            return 0;
        }
    }
}
