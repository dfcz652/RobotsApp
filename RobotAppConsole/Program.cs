using RobotViewModels;

public class Program
{
    private static void Main(string[] args)
    {
        ViewModel viewModel = new();

        bool showMenu = true;
        while (showMenu)
        {
            string choosedOption = DisplayMenuAndChoiceOfOption(viewModel);
            try
            {
                switch (choosedOption)
                {
                    case "1":
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

                        var robot = viewModel.CreateRobot(robotName, chosenArms, chosenBody, chosenCore, chosenLegs);
                        viewModel.CreatedRobots.Add(robot);

                        DisplayMessageAndPause($"{robotName} created. Return to menu.", 2000);
                        break;
                    case "2":
                        if (viewModel.CreatedRobots.Count != 2)
                        {
                            DisplayMessageAndReturnToMenu("You must create two robots for creating report");
                            break;
                        }
                        Console.WriteLine("Your comparison report: ");
                        viewModel.FormattedReport = viewModel.CreateAndFormatComparisonReport(
                            viewModel.CreatedRobots[0], viewModel.CreatedRobots[1]);
                        Console.WriteLine(viewModel.FormattedReport);
                        Console.WriteLine("Press any key for return to menu");
                        Console.ReadKey(true);
                        break;
                    case "3":
                        showMenu = false;
                        DisplayMessageAndPause("Bye!", 2000);
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

    private static void DisplayMessageAndPause(string message, int milliseconds)
    {
        Console.WriteLine(message);
        Thread.Sleep(milliseconds);
    }

    private static void DisplayMessageAndReturnToMenu(string message = "")
    {
        Console.Clear();
        if (message != "")
        {
            Console.WriteLine(message);
        }
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
