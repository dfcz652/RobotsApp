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
            switch (choosedOption)
            {
                case "1":
                    Console.WriteLine("Hey man. Let's create a robot");
                    Console.Write("Input robot name: ");
                    string robotName = Console.ReadLine();
                    Console.WriteLine("Choose arms from existing: ");
                    foreach (string arms in viewModel.ExistingArms)
                    {
                        Console.WriteLine(arms);
                    }
                    string choosedArms = Console.ReadLine();

                    Console.WriteLine("Choose body from existing: ");
                    foreach (string body in viewModel.ExistingBodies)
                    {
                        Console.WriteLine(body);
                    }
                    string choosedBody = Console.ReadLine();
                    Console.WriteLine("Choose core from existing: ");
                    foreach (string core in viewModel.ExistingCores)
                    {
                        Console.WriteLine(core);
                    }
                    string choosedCore = Console.ReadLine();
                    Console.WriteLine("Choose legs from existing: ");
                    foreach (string legs in viewModel.ExistingLegs)
                    {
                        Console.WriteLine(legs);
                    }
                    string choosedLegs = Console.ReadLine();

                    var robot = viewModel.CreateRobot(robotName, choosedArms, choosedBody, choosedCore, choosedLegs);
                    Console.WriteLine($"{robotName} created. Return to menu.");
                    Thread.Sleep(2000);
                    break;
            }
            Console.Clear();
        }
        Console.WriteLine(viewModel.FormattedReport);
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
