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
using System.ComponentModel;

namespace RobotViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _formattedReport;
        public string FormattedReport
        {
            get => _formattedReport;
            set
            {
                if (_formattedReport != value)
                {
                    _formattedReport = value;
                    OnPropertyChanged(nameof(FormattedReport));
                }
            }
        }

        public List<string> OptionsMenu { get; set; } = new()
        {
            "1. Create robot", "2. Create report", "3. Exit"
        };

        public List<string> ExistingArms { get; set; }

        public List<string> ExistingBodies { get; set; }

        public List<string> ExistingCores { get; set; }

        public List<string> ExistingLegs { get; set; }

        public List<Robot> CreatedRobots { get; set; }

        public event EventHandler<string> RobotCreated;

        //public event EventHandler<List<Robot>> IsRobotsEnough;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ViewModel()
        {
            CreatedRobots = new List<Robot>();
            FormattedReport = string.Empty;
            ExistingArms = GetAllExistingTypes<Arms>();
            ExistingBodies = GetAllExistingTypes<Body>();
            ExistingCores = GetAllExistingTypes<Core>();
            ExistingLegs = GetAllExistingTypes<Legs>();

            RobotCreated += (sender, robotName) => FormattedReport = string.Empty;
        }

        public string CreateAndFormatComparisonReport(Robot robot1, Robot robot2)
        {
            CompareRobotCharacteristicsService compareRobotCharacteristicsService = new();
            IRobotsComparisonFormatter comparisonFormatter = new ReportFormatter();

            RobotComparisonReport report = compareRobotCharacteristicsService
                .CreateRobotComparisonReport(robot1, robot2);

            FormattedReport += comparisonFormatter.Format(report);
            return comparisonFormatter.Format(report);
        }

        public Robot CreateRobot(string robotName, string choosedArms, string choosedBody,
            string choosedCore, string choosedLegs)
        {
            Robot robot = new(robotName);

            robot.AddArms(CreateInstanceByName<Arms>(choosedArms));
            robot.AddBody(CreateInstanceByName<Body>(choosedBody));
            robot.AddCore(CreateInstanceByName<Core>(choosedCore));
            robot.AddLegs(CreateInstanceByName<Legs>(choosedLegs));

            RobotCreated?.Invoke(this, robotName);

            return robot;
        }

        private TypeBase CreateInstanceByName<TypeBase>(string name) where TypeBase : class
        {
            Assembly targetAssembly = Assembly.GetAssembly(typeof(TypeBase));

            Type targetType = targetAssembly
                .GetTypes()
                .FirstOrDefault(t =>
                    t.IsClass &&
                    t.IsSubclassOf(typeof(TypeBase)) &&
                    t.Name.Equals(name));

            if (targetType == null)
            {
                throw new InvalidDataException("You choose non-existent part");
            }

            return Activator.CreateInstance(targetType) as TypeBase;
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
