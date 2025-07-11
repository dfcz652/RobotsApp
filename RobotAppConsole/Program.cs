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
            string chosenOption = DisplayMenuAndChoiceOfOption(viewModel);
            try
            {
                switch (chosenOption)
                {
                    case "1":// Create robot
                        Console.WriteLine("Hey man. Let's create a robot");
                        Console.Write("Input robot name: ");
                        string robotName = Console.ReadLine();
                        string chosenArms = ChooseFromList(viewModel.ExistingArms, "arms");
                        string chosenBody = ChooseFromList(viewModel.ExistingBodies, "body");
                        string chosenCore = ChooseFromList(viewModel.ExistingCores, "core");
                        string chosenLegs = ChooseFromList(viewModel.ExistingLegs, "legs");
                        viewModel.CreateRobot(robotName, chosenArms, chosenBody, chosenCore, chosenLegs);
                        break;
                    case "2":// Create report for robots
                        var chosenFirstName = ChooseFromList(viewModel.RobotsNames, "first robot");
                        var chosenSecondName = ChooseFromList(viewModel.RobotsNames, "second robot");
                        Console.Clear();
                        viewModel.CreateAndFormatComparisonReport(chosenFirstName, chosenSecondName);
                        break;
                    case "3":// Create report for parts
                        string chosenPart = ChoosePartsFromList();
                        string chosenFirstPart, chosenSecondPart;
                        ChoosePartTypes(chosenPart, out chosenFirstPart, out chosenSecondPart);
                        Console.Clear();
                        viewModel.CreateAndFormatComparisonReport(chosenFirstPart, chosenSecondPart);
                        break;
                    case "4":// Exit
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

    private static void ChoosePartTypes(string chosenPart, out string chosenFirstPart, out string chosenSecondPart)
    {
        chosenFirstPart = string.Empty;
        chosenSecondPart = string.Empty;
        switch (chosenPart)
        {
            case "Arms":
                chosenFirstPart = ChooseFromList(viewModel.ExistingArms, "first arms");
                chosenSecondPart = ChooseFromList(viewModel.ExistingArms, "second arms");
                break;
            case "Body":
                chosenFirstPart = ChooseFromList(viewModel.ExistingBodies, "first body");
                chosenSecondPart = ChooseFromList(viewModel.ExistingBodies, "second body");
                break;
            case "Core":
                chosenFirstPart = ChooseFromList(viewModel.ExistingCores, "first core");
                chosenSecondPart = ChooseFromList(viewModel.ExistingCores, "second core");
                break;
            case "Legs":
                chosenFirstPart = ChooseFromList(viewModel.ExistingLegs, "first legs");
                chosenSecondPart = ChooseFromList(viewModel.ExistingLegs, "second legs");
                break;
        }
    }

    private static string ChoosePartsFromList()
    {
        string chosenPart = ChooseFromList(viewModel.Parts, "part");
        Console.WriteLine($"You choose {chosenPart}");
        Console.WriteLine("Now choose two parts for creating report:");
        return chosenPart;
    }

    private static string ChooseFromList(List<string> itemsList, string itemType)
    {
        while (true)
        {
            Console.WriteLine($"Choose {itemType} from the list:");
            for (int i = 0; i < itemsList.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {itemsList[i]}");
            }
            string input = Console.ReadLine();
            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= itemsList.Count)
            {
                return itemsList[selectedIndex - 1];
            }
            Console.WriteLine($"{itemType} with index '{input}' not in the list. Please try again.");
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
        List<string> optionsMenu = new()
        {
            "1. Create robot", "2. Create report for robots", "3. Create report for parts", "4. Exit"
        };

        Console.WriteLine("Choose number of option from menu: ");
        foreach (string option in optionsMenu)
        {
            Console.WriteLine(option);
        }
        return Console.ReadLine();
    }
}
