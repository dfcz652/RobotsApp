using RobotApp.Services;
using RobotViewModels;

public class Program
{
    private static ViewModel viewModel = new();
    private static List<string> optionsMenu = new()
        {
            "Create robot", "Compare robots", "Compare parts", "Exit"
        };

    private static void Main(string[] args)
    {
        viewModel.RobotCreated += DisplayMessage_WhenRobotCreated;

        bool showMenu = true;
        while (showMenu)
        {
            DisplayNumberedList(optionsMenu, "option");
            showMenu = HandleMainMenuSelection();
            Console.Clear();
        }
    }

    #region Menu
    private static bool HandleMainMenuSelection()
    {
        int chosenOption = ReadItemIndex(optionsMenu.Count);
        try
        {
            switch (chosenOption)
            {
                case 0:// Create robot
                    CreateRobotOption();
                    break;
                case 1:// Create report for robots
                    CreateReportForRobotsOption();
                    DisplayReport();
                    break;
                case 2:// Create report for parts
                    CreateReportForPartsOption();
                    DisplayReport();
                    break;
                case 3:// Exit
                    DisplayMessageAndReturnToMenu("Bye!");
                    return false;
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
    private static void CreateReportForPartsOption()
    {
        int chosenPart = ChoosePartTypeForReport();
        string chosenFirstPart, chosenSecondPart;
        ChooseParts(chosenPart, out chosenFirstPart, out chosenSecondPart);
        Console.Clear();
        viewModel.CreateAndFormatComparisonReport(chosenFirstPart, chosenSecondPart);
    }

    private static void CreateReportForRobotsOption()
    {
        if (viewModel.RobotsNames.Count == 0)
        {
            DisplayMessageAndReturnToMenu("You must create at least one robot");
            return;
        }
        DisplayNumberedList(viewModel.RobotsNames, "first robot");
        var chosenFirstName = ReadItemIndex(viewModel.RobotsNames.Count);
        DisplayNumberedList(viewModel.RobotsNames, "second robot");
        var chosenSecondName = ReadItemIndex(viewModel.RobotsNames.Count);
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

        DisplayNumberedList(viewModel.ExistingArms, "arms");
        int chosenArms = ReadItemIndex(viewModel.ExistingArms.Count);
        DisplayNumberedList(viewModel.ExistingBodies, "body");
        int chosenBody = ReadItemIndex(viewModel.ExistingBodies.Count);
        DisplayNumberedList(viewModel.ExistingCores, "core");
        int chosenCore = ReadItemIndex(viewModel.ExistingCores.Count);
        DisplayNumberedList(viewModel.ExistingLegs, "legs");
        int chosenLegs = ReadItemIndex(viewModel.ExistingLegs.Count);
        viewModel.CreateRobot(robotName, viewModel.ExistingArms[chosenArms], viewModel.ExistingBodies[chosenBody], 
            viewModel.ExistingCores[chosenCore], viewModel.ExistingLegs[chosenLegs]);
    }

    private static void ChooseParts(int chosenPart, out string chosenFirstPart, out string chosenSecondPart)
    {
        Console.WriteLine("Now choose two parts for creating report:");
        chosenFirstPart = string.Empty;
        chosenSecondPart = string.Empty;
        switch (viewModel.Parts[chosenPart])
        {
            case "Arms":
                (chosenFirstPart, chosenSecondPart) = ChooseTwoPartsFromList(viewModel.ExistingArms, "arms");
                break;
            case "Body":
                (chosenFirstPart, chosenSecondPart) = ChooseTwoPartsFromList(viewModel.ExistingBodies, "body");
                break;
            case "Core":
                (chosenFirstPart, chosenSecondPart) = ChooseTwoPartsFromList(viewModel.ExistingCores, "core");
                break;
            case "Legs":
                (chosenFirstPart, chosenSecondPart) = ChooseTwoPartsFromList(viewModel.ExistingLegs, "legs");
                break;
        }
    }

    private static (string, string) ChooseTwoPartsFromList(List<string> partsList, string partName)
    {
        DisplayNumberedList(partsList, partName);
        int firstPartIndex = ReadItemIndex(partsList.Count);
        string firstPart = partsList[firstPartIndex];

        DisplayNumberedList(partsList, partName);
        int secondPartIndex = ReadItemIndex(partsList.Count);
        string secondPart = partsList[secondPartIndex];
        return (firstPart, secondPart);
    }

    private static int ChoosePartTypeForReport()
    {
        DisplayNumberedList(viewModel.Parts, "part type");
        int chosenPart = ReadItemIndex(viewModel.Parts.Count);
        Console.WriteLine($"You choose {viewModel.Parts[chosenPart]}");
        return chosenPart;
    }

    private static int ReadItemIndex(int listCount)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int index))
            {
                Console.WriteLine("Please input number");
                continue;
            }
            index -= 1;
            if (index < 0 || index >= listCount)
            {
                Console.WriteLine($"You must choose 1 - {listCount}");
                continue;
            }
            return index;
        }
    }
    #endregion

    #region Display
    private static void DisplayNumberedList(List<string> itemsList, string itemType)
    {
        Console.WriteLine($"Choose {itemType} from list:");
        for (int i = 0; i < itemsList.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {itemsList[i]}");
        }
    }

    private static void DisplayReport()
    {
        Console.WriteLine("Your comparison report: ");
        Console.WriteLine(viewModel.FormattedReport);
        Console.WriteLine("Press any key for return to menu");
        Console.ReadKey(true);
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
