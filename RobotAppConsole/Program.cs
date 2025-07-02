using System.ComponentModel;
using RobotApp.Services;
using RobotViewModels;

public class Program
{
    private static void Main(string[] args)
    {
        ViewModel viewModel = new(new RobotsGatewayInMemory());

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
                        Console.WriteLine("Choose arms from existing: ");
                        foreach (string arms in viewModel.ExistingArms)
                        {
                            Console.WriteLine("  " + arms);
                        }
                        string chosenArms = Console.ReadLine();

                        Console.WriteLine("Choose body from existing: ");
                        foreach (string body in viewModel.ExistingBodies)
                        {
                            Console.WriteLine("  " + body);
                        }
                        string chosenBody = Console.ReadLine();
                        Console.WriteLine("Choose core from existing: ");
                        foreach (string core in viewModel.ExistingCores)
                        {
                            Console.WriteLine("  " + core);
                        }
                        string chosenCore = Console.ReadLine();
                        Console.WriteLine("Choose legs from existing: ");
                        foreach (string legs in viewModel.ExistingLegs)
                        {
                            Console.WriteLine("  " + legs);
                        }
                        string chosenLegs = Console.ReadLine();
                        viewModel.CreateRobot(robotName, chosenArms, chosenBody, chosenCore, chosenLegs);
                        break;
                    case "2":// Create report
                        var chosenFirstName = AskRobotName(viewModel, "Choose first robot from the list to create a report: ");
                        var chosenSecondName = AskRobotName(viewModel, "Choose second robot from the list to create a report: ");
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

    private static string AskRobotName(ViewModel viewModel, string messageToUser)
    {
        while (true)
        {
            Console.WriteLine(messageToUser);
            foreach (string name in viewModel.RobotNames)
            {
                Console.WriteLine("  " + name);
            }
            string choosedName = Console.ReadLine();
            if (viewModel.RobotNames.Contains(choosedName))
            {
                return choosedName;
            }
            Console.WriteLine($"Robot '{choosedName}' not found. Please try again");
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
