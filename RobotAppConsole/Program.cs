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
            DisplayMenu();
            showMenu = SelectionOfOption();
            Console.Clear();
        }
    }

    #region Menu
    private static bool SelectionOfOption()
    {
        string chosenOption = Console.ReadLine();
        try
        {
            switch (chosenOption)
            {
                case "1":// Create robot
                    RobotCreationOption();
                    break;
                case "2":// Create report for robots
                    RobotsReportCreationOption();
                    break;
                case "3":// Create report for parts
                    PartsReportCreationOption();
                    break;
                case "4":// Exit
                    DisplayMessageAndReturnToMenu("Bye!");
                    return false;
                default:
                    DisplayMessageAndReturnToMenu("You must choose 1 - 3 number option.");
                    break;
            }
        }
        catch (InvalidDataException ex)
        {
            DisplayMessageAndReturnToMenu(ex.Message);
        }
        return true;
    }
    #endregion

    #region Reports creating
    private static void PartsReportCreationOption()
    {
        int chosenPart = ChoosePartsFromList();
        string chosenFirstPart, chosenSecondPart;
        ChoosePartTypes(chosenPart, out chosenFirstPart, out chosenSecondPart);
        Console.Clear();
        viewModel.CreateAndFormatComparisonReport(chosenFirstPart, chosenSecondPart);
    }

    private static void RobotsReportCreationOption()
    {
        Console.WriteLine($"Choose first robot from the list:");
        var chosenFirstName = ChooseFromList(viewModel.RobotsNames);
        Console.WriteLine($"Choose second robot from the list:");
        var chosenSecondName = ChooseFromList(viewModel.RobotsNames);
        Console.Clear();
        viewModel.CreateAndFormatComparisonReport(viewModel.RobotsNames[chosenFirstName], viewModel.RobotsNames[chosenSecondName]);
    }
    #endregion

    #region Choise
    private static void RobotCreationOption()
    {
        Console.WriteLine("Hey man. Let's create a robot");
        Console.Write("Input robot name: ");
        string robotName = Console.ReadLine();

        Console.WriteLine($"Choose arms from the list:");
        int chosenArms = ChooseFromList(viewModel.ExistingArms);
        Console.WriteLine($"Choose body from the list:");
        int chosenBody = ChooseFromList(viewModel.ExistingBodies);
        Console.WriteLine($"Choose core from the list:");
        int chosenCore = ChooseFromList(viewModel.ExistingCores);
        Console.WriteLine($"Choose legs from the list:");
        int chosenLegs = ChooseFromList(viewModel.ExistingLegs);
        viewModel.CreateRobot(robotName, viewModel.ExistingArms[chosenArms], viewModel.ExistingBodies[chosenBody], 
            viewModel.ExistingCores[chosenCore], viewModel.ExistingLegs[chosenLegs]);
    }

    private static void ChoosePartTypes(int chosenPart, out string chosenFirstPart, out string chosenSecondPart)
    {
        int firstPartIndex;
        int secondPartIndex;
        chosenFirstPart = string.Empty;
        chosenSecondPart = string.Empty;

        switch (viewModel.Parts[chosenPart])
        {
            case "Arms":
                Console.WriteLine($"Choose first arms from the list:");
                firstPartIndex = ChooseFromList(viewModel.ExistingArms);
                chosenFirstPart = viewModel.ExistingArms[firstPartIndex];
                Console.WriteLine($"Choose second arms from the list:");
                secondPartIndex = ChooseFromList(viewModel.ExistingArms);
                chosenSecondPart = viewModel.ExistingArms[secondPartIndex];
                break;
            case "Body":
                Console.WriteLine($"Choose first body from the list:");
                firstPartIndex = ChooseFromList(viewModel.ExistingBodies);
                chosenFirstPart = viewModel.ExistingBodies[firstPartIndex];
                Console.WriteLine($"Choose second body from the list:");
                secondPartIndex = ChooseFromList(viewModel.ExistingBodies);
                chosenSecondPart = viewModel.ExistingBodies[secondPartIndex];
                break;
            case "Core":
                Console.WriteLine($"Choose first core from the list:");
                firstPartIndex = ChooseFromList(viewModel.ExistingCores);
                chosenFirstPart = viewModel.ExistingCores[firstPartIndex];
                Console.WriteLine($"Choose second core from the list:");
                secondPartIndex = ChooseFromList(viewModel.ExistingCores);
                chosenSecondPart = viewModel.ExistingCores[secondPartIndex];
                break;
            case "Legs":
                Console.WriteLine($"Choose first legs from the list:");
                firstPartIndex = ChooseFromList(viewModel.ExistingLegs);
                chosenFirstPart = viewModel.ExistingLegs[firstPartIndex];
                Console.WriteLine($"Choose second legs from the list:");
                secondPartIndex = ChooseFromList(viewModel.ExistingLegs);
                chosenSecondPart = viewModel.ExistingLegs[secondPartIndex];
                break;
        }
    }

    private static int ChoosePartsFromList()
    {
        Console.WriteLine($"Choose part from the list:");
        int chosenPart = ChooseFromList(viewModel.Parts);
        Console.WriteLine($"You choose {viewModel.Parts[chosenPart]}");
        Console.WriteLine("Now choose two parts for creating report:");
        return chosenPart;
    }

    private static int ChooseFromList(List<string> itemsList)
    {
        while (true)
        {
            for (int i = 0; i < itemsList.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {itemsList[i]}");
            }
            string input = Console.ReadLine();
            return int.Parse(input) - 1;
        }
    }
    #endregion

    #region Display
    private static void DisplayMenu()
    {
        List<string> optionsMenu = new()
        {
            "Create robot", "Create report for robots", "Create report for parts", "Exit"
        };
        Console.WriteLine("Choose number of option from menu: ");
        foreach (string option in optionsMenu)
        {
            Console.WriteLine(option);
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
    #endregion
}
