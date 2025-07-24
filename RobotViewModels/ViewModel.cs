using RobotApp.RobotData;
using RobotApp.Services.Reports;
using RobotApp.Services;
using RobotViewModels.Formatters;
using RobotViewModels.Interfaces;
using RobotApp.RobotData.RobotParts;
using System.Reflection;
using System.ComponentModel;
using RobotViewModels.Exceptions;
using RobotApp.RobotData.Base;

namespace RobotViewModels
{
    public class ViewModel(IRobotsGateway robotsGateway) : INotifyPropertyChanged
    {
        private string _formattedReport = string.Empty;

        public string FormattedReport
        {
            get => _formattedReport;
            set
            {
                if (_formattedReport != value)
                {
                    _formattedReport = value;
                }
            }
        }

        public List<string> Parts { get; set; } = new()
        {
            "Arms", "Body", "Core", "Legs"
        };

        public List<string> ExistingArms
        {
            get => GetAllExistingTypes<Arms>();
        }

        public List<string> ExistingBodies
        {
            get => GetAllExistingTypes<Body>();
        }

        public List<string> ExistingCores
        {
            get => GetAllExistingTypes<Core>();
        }

        public List<string> ExistingLegs
        {
            get => GetAllExistingTypes<Legs>();
        }

        private readonly List<string> _robotsNames = new();
        public List<string> RobotsNames 
        { 
            get => _robotsNames;
        }

        private readonly IRobotsGateway _robotsGateway = robotsGateway;

        public event EventHandler<string> RobotCreated;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void CreateAndFormatComparisonReport(string firstItemName, string secondItemName)
        {
            ItemComparisonReportService compareRobotCharacteristicsService = new();
            IRobotsComparisonFormatter comparisonFormatter = new ReportFormatter();

            RobotCharacteristicsBase firstItem = GetRobot(firstItemName) ?? GetPart(firstItemName);
            RobotCharacteristicsBase secondItem = GetRobot(secondItemName) ?? GetPart(secondItemName);
            ItemComparisonReport report = compareRobotCharacteristicsService.CreateItemComparisonReport(firstItem, secondItem);

            FormattedReport = comparisonFormatter.Format(report);
        }

        public RobotCharacteristicsBase GetRobot(string itemName)
        {
            return _robotsGateway.GetByName(itemName);
        }

        public RobotCharacteristicsBase GetPart(string itemName)
        {
            if (ExistingArms.Contains(itemName))
                return CreateInstanceByName<Arms>(itemName);
            if (ExistingBodies.Contains(itemName))
                return CreateInstanceByName<Body>(itemName);
            if (ExistingCores.Contains(itemName))
                return CreateInstanceByName<Core>(itemName);
            if (ExistingLegs.Contains(itemName))
                return CreateInstanceByName<Legs>(itemName);
            throw new ArgumentException($"Part with name '{itemName}' does not exist");
        }

        public void CreateRobot(string robotName, string choosedArms, string choosedBody,
            string choosedCore, string choosedLegs)
        {
            Robot robot = new(robotName);
            robot.AddArms(CreateInstanceByName<Arms>(choosedArms));
            robot.AddBody(CreateInstanceByName<Body>(choosedBody));
            robot.AddCore(CreateInstanceByName<Core>(choosedCore));
            robot.AddLegs(CreateInstanceByName<Legs>(choosedLegs));
            _robotsGateway.Add(robot);

            OnRobotCreated(robotName);
        }

        private void OnRobotCreated(string robotName)
        {
            RobotsNames.Add(robotName);
            RobotCreated?.Invoke(this, robotName);
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

        public Robot GetRobotByName(string name)
        {
            Robot robot = _robotsGateway.GetByName(name);
            if (robot == null)
            {
                throw new RobotNotFoundException($"Robot with name '{name}' was not found");
            }
            return robot;
        }
    }
}
