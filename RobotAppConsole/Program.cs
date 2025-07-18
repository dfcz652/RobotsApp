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
            DisplayMainMenu();
            showMenu = HandleMainMenuSelection();
            Console.Clear();
        }
    }

    #region Menu
    private static bool HandleMainMenuSelection()
    {
        string chosenOption = Console.ReadLine();
        try
        {
            switch (chosenOption)
            {
                case "1":// Create robot
                    CreateRobotOption();
                    break;
                case "2":// Create report for robots
                    CreateRobotsReportOption();
                    break;
                case "3":// Create report for parts
                    CreatePartsReportOption();
                    break;
                case "4":// Exit
                    DisplayMessageAndReturnToMenu("Bye!");
                    return false;
                default:
                    DisplayMessageAndReturnToMenu("You must choose 1 - 4 number option.");
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
    private static void CreatePartsReportOption()
    {
        int chosenPart = ChoosePartsFromList();
        string chosenFirstPart, chosenSecondPart;
        ChoosePartTypes(chosenPart, out chosenFirstPart, out chosenSecondPart);
        Console.Clear();
        viewModel.CreateAndFormatComparisonReport(chosenFirstPart, chosenSecondPart);
    }

    private static void CreateRobotsReportOption()
    {
        Console.WriteLine($"Choose first robot from the list:");
        DisplayNumberedList(viewModel.RobotsNames);
        var chosenFirstName = ChooseItemFromList(viewModel.RobotsNames.Count);
        Console.WriteLine($"Choose second robot from the list:");
        DisplayNumberedList(viewModel.RobotsNames);
        var chosenSecondName = ChooseItemFromList(viewModel.RobotsNames.Count);
        Console.Clear();
        viewModel.CreateAndFormatComparisonReport(viewModel.RobotsNames[chosenFirstName], viewModel.RobotsNames[chosenSecondName]);
    }
    #endregion

    #region Choise
    private static void CreateRobotOption()
    {
        Console.WriteLine("Hey man. Let's create a robot");
        Console.Write("Input robot name: ");
        string robotName = Console.ReadLine();

        Console.WriteLine($"Choose arms from the list:");
        DisplayNumberedList(viewModel.ExistingArms);
        int chosenArms = ChooseItemFromList(viewModel.ExistingArms.Count);
        Console.WriteLine($"Choose body from the list:");
        DisplayNumberedList(viewModel.ExistingBodies);
        int chosenBody = ChooseItemFromList(viewModel.ExistingBodies.Count);
        Console.WriteLine($"Choose core from the list:");
        DisplayNumberedList(viewModel.ExistingCores);
        int chosenCore = ChooseItemFromList(viewModel.ExistingCores.Count);
        Console.WriteLine($"Choose legs from the list:");
        DisplayNumberedList(viewModel.ExistingLegs);
        int chosenLegs = ChooseItemFromList(viewModel.ExistingLegs.Count);
        viewModel.CreateRobot(robotName, viewModel.ExistingArms[chosenArms], viewModel.ExistingBodies[chosenBody], 
            viewModel.ExistingCores[chosenCore], viewModel.ExistingLegs[chosenLegs]);
    }

    private static void ChoosePartTypes(int chosenPart, out string chosenFirstPart, out string chosenSecondPart)
    {
        chosenFirstPart = string.Empty;
        chosenSecondPart = string.Empty;

        switch (viewModel.Parts[chosenPart])
        {
            case "Arms":
                (chosenFirstPart, chosenSecondPart) = ChooseTwoPartTypesFromList(viewModel.ExistingArms, "arms");
                break;
            case "Body":
                (chosenFirstPart, chosenSecondPart) = ChooseTwoPartTypesFromList(viewModel.ExistingBodies, "body");
                break;
            case "Core":
                (chosenFirstPart, chosenSecondPart) = ChooseTwoPartTypesFromList(viewModel.ExistingCores, "core");
                break;
            case "Legs":
                (chosenFirstPart, chosenSecondPart) = ChooseTwoPartTypesFromList(viewModel.ExistingLegs, "legs");
                break;
        }
    }

    private static (string, string) ChooseTwoPartTypesFromList(List<string> partsList, string partName)
    {
        Console.WriteLine($"Choose first {partName} from the list:");
        DisplayNumberedList(partsList);
        int firstPartIndex = ChooseItemFromList(partsList.Count);
        string firstPart = partsList[firstPartIndex];

        Console.WriteLine($"Choose second {partName} from the list:");
        DisplayNumberedList(partsList);
        int secondPartIndex = ChooseItemFromList(partsList.Count);
        string secondPart = partsList[secondPartIndex];

        return (firstPart, secondPart);
    }

    private static int ChoosePartsFromList()
    {
        Console.WriteLine($"Choose part from the list:");
        DisplayNumberedList(viewModel.Parts);
        int chosenPart = ChooseItemFromList(viewModel.Parts.Count);
        Console.WriteLine($"You choose {viewModel.Parts[chosenPart]}");
        Console.WriteLine("Now choose two parts for creating report:");
        return chosenPart;
    }

    private static int ChooseItemFromList(int listCount)
    {
        while (true)
        {
            string input = Console.ReadLine();
            try
            {
                int index = int.Parse(input) - 1;
                if (index < 0 || index >= listCount)
                    throw new ArgumentOutOfRangeException(null, "Item with this index not exist");
                return index;
            }
            catch (FormatException ex) 
            {
                Console.WriteLine("Please input number");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    #endregion

    #region Display
    private static void DisplayMainMenu()
    {
        List<string> optionsMenu = new()
        {
            "Create robot", "Create report for robots", "Create report for parts", "Exit"
        };
        Console.WriteLine("Choose number of option from menu: ");
        DisplayNumberedList(optionsMenu);
    }

    private static void DisplayNumberedList(List<string> itemsList)
    {
        for (int i = 0; i < itemsList.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {itemsList[i]}");
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
