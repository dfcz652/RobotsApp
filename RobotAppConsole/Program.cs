using System.ComponentModel;
using RobotApp.Services;
using RobotViewModels;

public class Program
{
    private static ViewModel viewModel = new(new RobotsGatewayInMemory());
    private static void Main(string[] args)
    {
        viewModel.RobotCreated += DisplayMessage_WhenRobotCreated;
        viewModel.PropertyChanged += DisplayReport_WhenReportCreated;

        bool showMenu = true;
        while (showMenu)
        {
            string choosedOption = DisplayMenuAndChoiceOfOption(viewModel);
            try
            {
                switch (choosedOption)
                {
                    case "1":// Create robot
                        Console.WriteLine("Hey man. Let's create a robot");
                        Console.Write("Input robot name: ");
                        string robotName = Console.ReadLine();
                        string chosenArms = ChoosePartFromList(viewModel.ExistingArms, "arms");
                        string chosenBody = ChoosePartFromList(viewModel.ExistingBodies, "body");
                        string chosenCore = ChoosePartFromList(viewModel.ExistingCores, "core");
                        string chosenLegs = ChoosePartFromList(viewModel.ExistingLegs, "legs");
                        viewModel.CreateRobot(robotName, chosenArms, chosenBody, chosenCore, chosenLegs);
                        break;
                    case "2":// Create report
                        var chosenFirstName = AskRobotName("Choose index of first robot from the list to create a report: ");
                        var chosenSecondName = AskRobotName("Choose index of second robot from the list to create a report: ");
                        Console.Clear();
                        viewModel.CreateAndFormatComparisonReport(chosenFirstName, chosenSecondName);
                        break;
                    case "3":// Exit
                        showMenu = false;
                        DisplayMessageAndReturnToMenu("Bye!");
                        break;
                    default:
                        DisplayMessageAndReturnToMenu("You must choose 1 - 3 number option.");
                        break;
                }
            }
            catch (InvalidDataException ex)
            {
                DisplayMessageAndReturnToMenu(ex.Message);
            }
            Console.Clear();
        }
    }

    private static string ChoosePartFromList(List<string> partsList, string partName)
    {
        while (true)
        {
            Console.WriteLine($"Choose {partName} from existing: ");
            for(int i = 0; i < partsList.Count(); i++)
            {
                Console.WriteLine($"  {i + 1}. {partsList[i]}");
            }
            string input = Console.ReadLine();
            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= partsList.Count())
            {
                return partsList[selectedIndex - 1];
            }
            Console.WriteLine("Part with this index not in list");
        }
    }

    private static string AskRobotName(string messageToUser)
    {
        var robotsNames = viewModel.RobotsNames;
        while (true)
        {
            Console.WriteLine(messageToUser);
            for (int i = 0; i < robotsNames.Count(); i++)
            {
                Console.WriteLine($"  {i + 1}. {robotsNames[i]}");
            }
            string input = Console.ReadLine();
            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= robotsNames.Count())
            {
                return robotsNames[selectedIndex - 1];
            }
            Console.WriteLine($"Robot with index '{selectedIndex}' not in the list. Please try again");
        }
    }

    private static void DisplayReport_WhenReportCreated(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ViewModel.FormattedReport))
        {
            var vm = (ViewModel)sender;
            Console.WriteLine("Your comparison report: ");
            Console.WriteLine(vm.FormattedReport);
            Console.WriteLine("Press any key for return to menu");
            Console.ReadKey(true);
        }
    }

    private static void DisplayMessage_WhenRobotCreated(object sender, string robotName)
    {
        DisplayMessageAndReturnToMenu($"{robotName} created. Return to menu.");
    }

    private static void DisplayMessageAndReturnToMenu(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.WriteLine("Press any key for return to menu");
        Console.ReadKey(true);
    }

    private static string DisplayMenuAndChoiceOfOption(ViewModel viewModel)
    {
        Console.WriteLine("Choose number of option from menu: ");
        foreach (string option in viewModel.OptionsMenu)
        {
            Console.WriteLine(option);
        }
        return Console.ReadLine();
    }
}
