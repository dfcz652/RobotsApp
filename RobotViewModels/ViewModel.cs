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

namespace RobotViewModels
{
    public class ViewModel
    {
        public string FormattedReport { get; set; }

        public List<string> OptionsMenu { get; set; } = new List<string>()
        {
            "1. Create two robots", "2. Create report", "3. Exit"
        };

        public List<string> ExistingArms { get; set; } = new List<string>()
        {
            "RocketArms", "SpearArms"
        };

        public List<string> ExistingBodies { get; set; } = new List<string>()
        {
            "ShieldedBody", "TankyBody"
        };

        public List<string> ExistingCores { get; set; } = new List<string>()
        {
            "EnergeticCore", "LivingCore"
        };

        public List<string> ExistingLegs { get; set; } = new List<string>()
        {
            "SpeedLegs", "ArmouredLegs"
        };

        public ViewModel()
        {
        }

        public string CreateAndFormatComparisonReport(Robot robot1, Robot robot2)
        {
            CompareRobotCharacteristicsService compareRobotCharacteristicsService = new();
            IRobotsComparisonFormatter comparisonFormatter = new ReportFormatter();

            RobotComparisonReport report = compareRobotCharacteristicsService.CreateRobotComparisonReport(robot1, robot2);

            return comparisonFormatter.Format(report);
        }

        public object CreateRobot(string robotName, string choosedArms, string choosedBody,
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
            }
            switch (choosedBody)
            {
                case "ShieldedBody":
                    robot.AddBody(new ShieldedBody());
                    break;
                case "TankyBody":
                    robot.AddBody(new TankyBody());
                    break;
            }
            switch (choosedCore)
            {
                case "EnergeticCore":
                    robot.AddCore(new EnergeticCore());
                    break;
                case "LivingCore":
                    robot.AddCore(new LivingCore());
                    break;
            }
            switch (choosedLegs)
            {
                case "SpeedLegs":
                    robot.AddLegs(new SpeedLegs());
                    break;
                case "ArmouredLegs":
                    robot.AddLegs(new ArmouredLegs());
                    break;
            }

            return robot;
        }
    }
}
