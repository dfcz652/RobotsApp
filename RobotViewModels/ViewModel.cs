using RobotApp.RobotData;
using RobotApp.Services.Reports;
using RobotApp.Services;
using RobotViewModels.Interfaces;
using RobotApp.RobotData.RobotParts;
using System.Reflection;
using System.ComponentModel;
using RobotViewModels.Exceptions;
using RobotApp.RobotData.Base;
using RobotApp.Services.Dtos;

namespace RobotViewModels
{
    public class ViewModel(
        IRobotsGateway robotsGateway,
        IItemComparisonService comparisonReportService,
        IRobotsComparisonFormatter formatter) : INotifyPropertyChanged
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

        public string PartInfo { get; set; } = string.Empty;

        public string CurrentlySelectedPart { get; set; } = string.Empty;

        private BindingList<string> _robotCharacteristics = new();
        public BindingList<string> RobotCharacteristics
        {
            get => _robotCharacteristics;
            private set
            {
                _robotCharacteristics = value;
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

        public event EventHandler<string> RobotCreated;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void CreateAndFormatRobotsComparisonReport(string firstRobotName, string secondRobotName)
        {
            RobotCharacteristicsBase firstRobot = GetRobotByName(firstRobotName);
            RobotCharacteristicsBase secondRobot = GetRobotByName(secondRobotName);
            CreateAndFormatTwoItemsReport(firstRobot, secondRobot);
        }

        public void CreateAndFormatPartsComparisonReport(string firstPartName, string secondPartName)
        {
            RobotCharacteristicsBase firstPart = GetPart(firstPartName);
            RobotCharacteristicsBase secondPart = GetPart(secondPartName);
            CreateAndFormatTwoItemsReport(firstPart, secondPart);
        }

        private void CreateAndFormatTwoItemsReport(RobotCharacteristicsBase firstItem, RobotCharacteristicsBase secondItem)
        {
            ItemComparisonReport report = comparisonReportService.CreateReportForTwoItems(firstItem, secondItem);
            FormattedReport = formatter.FormatTwoItems(report);
        }

        public void GetAndFormatPartCharacteristics(string partName)
        {
            RobotCharacteristicsBase part = GetPart(partName);
            List<ItemCharacteristicDto> listOfCharacteristics = part.RobotCharacteristics.ToItemCharacteristicsDtoList();
            PartInfo = formatter.FormatPartDetails(partName, listOfCharacteristics);
        }

        private void UpdateRobotCharacteristics(Robot robot)
        {
            if (robot != null)
            {
                RobotCharacteristics.Clear();
                foreach (var formattedCharacteristic in formatter.FormatRobotCharacteristics(robot.RobotCharacteristics))
                {
                    RobotCharacteristics.Add(formattedCharacteristic);
                }
            }
        }

        public void UpdateRobotsNames()
        {
            RobotsNames.Clear();
            RobotsNames.AddRange(robotsGateway.GetAllRobots().Select(r => r.Name).ToList());
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
            robotsGateway.Add(robot);

            OnRobotCreated(robotName);
        }

        public void CreateEmptyRobot(string robotName)
        {
            Robot emptyRobot = new(robotName);
            robotsGateway.Add(emptyRobot);
        }

        public void UpdateRobot(
            string existingRobotName, string newName = null, string arms = null, string body = null,
            string core = null, string legs = null)
        {
            Robot robot = robotsGateway.GetByName(existingRobotName);
            robot.Name = string.IsNullOrWhiteSpace(newName) ? robot.Name : newName;
            if (arms != null) robot.AddArms(CreateInstanceByName<Arms>(arms));
            if (body != null) robot.AddBody(CreateInstanceByName<Body>(body));
            if (core != null) robot.AddCore(CreateInstanceByName<Core>(core));
            if (legs != null) robot.AddLegs(CreateInstanceByName<Legs>(legs));

            UpdateRobotCharacteristics(robot);
        }

        private void OnRobotCreated(string robotName)
        {
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
            Robot robot = robotsGateway.GetByName(name);
            if (robot == null)
            {
                throw new RobotNotFoundException($"Robot with name '{name}' was not found");
            }
            return robot;
        }
    }
}
