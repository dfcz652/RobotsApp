using RobotApp.RobotData.RobotEquipment.ArmsTypes;
using RobotApp.RobotData.RobotEquipment.BodyTypes;
using RobotApp.RobotData.RobotEquipment.CoreTypes;
using RobotApp.RobotData.RobotEquipment.LegsTypes;
using RobotApp.RobotData;
using RobotApp.Services.Reports;
using RobotApp.Services;
using RobotViewModels.Formatters;
using RobotViewModels.Interfaces;
using RobotApp.RobotData.RobotParts;
using System;
using System.Reflection;

namespace RobotViewModels
{
    public class ViewModel
    {
        public string FormattedReport { get; set; }

        public List<string> OptionsMenu { get; set; } = new()
        {
            "1. Create robot", "2. Create report", "3. Exit"
        };

        public List<string> ExistingArms { get; set; }

        public List<string> ExistingBodies { get; set; }

        public List<string> ExistingCores { get; set; }

        public List<string> ExistingLegs { get; set; }

        public List<Robot> CreatedRobots { get; set; }

        public ViewModel()
        {
            CreatedRobots = new List<Robot>();
            FormattedReport = string.Empty;
            ExistingArms = GetAllExistingTypes<Arms>();
            ExistingBodies = GetAllExistingTypes<Body>();
            ExistingCores = GetAllExistingTypes<Core>();
            ExistingLegs = GetAllExistingTypes<Legs>();
        }

        public string CreateAndFormatComparisonReport(Robot robot1, Robot robot2)
        {
            CompareRobotCharacteristicsService compareRobotCharacteristicsService = new();
            IRobotsComparisonFormatter comparisonFormatter = new ReportFormatter();

            RobotComparisonReport report = compareRobotCharacteristicsService
                .CreateRobotComparisonReport(robot1, robot2);

            return comparisonFormatter.Format(report);
        }

        public Robot CreateRobot(string robotName, string choosedArms, string choosedBody,
            string choosedCore, string choosedLegs)
        {
            Robot robot = new(robotName);

            switch (choosedArms)
            {
                case "RocketArms":
                    robot.AddArms(new RocketArms());
                    break;
                case "SpearArms":
                    robot.AddArms(new SpearArms());
                    break;
                default:
                    throw new InvalidDataException("You choose non-existent arms");
            }
            switch (choosedBody)
            {
                case "ShieldedBody":
                    robot.AddBody(new ShieldedBody());
                    break;
                case "TankyBody":
                    robot.AddBody(new TankyBody());
                    break;
                default:
                    throw new InvalidDataException("You choose non-existent body");
            }
            switch (choosedCore)
            {
                case "EnergeticCore":
                    robot.AddCore(new EnergeticCore());
                    break;
                case "LivingCore":
                    robot.AddCore(new LivingCore());
                    break;
                default:
                    throw new InvalidDataException("You choose non-existent core");
            }
            switch (choosedLegs)
            {
                case "SpeedLegs":
                    robot.AddLegs(new SpeedLegs());
                    break;
                case "ArmouredLegs":
                    robot.AddLegs(new ArmouredLegs());
                    break;
                default:
                    throw new InvalidDataException("You choose non-existent legs");
            }
            return robot;
        }

        public List<string> GetAllExistingTypes<BasePart>()
        {
            Assembly currentAssembly = Assembly.GetAssembly(typeof(BasePart));

            List<Type> inheritedTypes = currentAssembly
                .GetTypes()
                .Where(t => t.IsClass && t.IsSubclassOf(typeof(BasePart))).ToList();

            List<string> namesOfExistingTypes = new();

            if (inheritedTypes.Any())
            {
                foreach (Type type in inheritedTypes)
                {
                    namesOfExistingTypes.Add(type.Name);
                }
            }
            return namesOfExistingTypes;
        }
    }
}
