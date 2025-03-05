using RobotsWarApp2.Models.Characteristics;
using RobotsWarApp2.Models.RobotParts;
using RobotsWarApp2.Services;

internal class Program
{

    public static void Main(string[] args)
    {

        //Arms arms = new Arms();

        //Legs legs = new Legs();

        //arms.AddCharacteristic(new RobotCharacteristicBase("Hp", 200));
        //arms.AddCharacteristic(new RobotCharacteristicBase("Shield", 20));

        //legs.AddCharacteristic(new RobotCharacteristicBase("Speed", 10));

        //arms.PrintCharacteristics();
        //legs.PrintCharacteristics();

        RobotService robotService = new RobotService(); 
        Console.WriteLine("Select robot core: \n" + 
            "1 - Light\n" + 
            "2 - Medium\n" + 
            "3 - Heavy\n"); 
        string? selectedCoreType = Console.ReadLine(); 
        RobotPartBase robotCore = robotService.CreatePart(selectedCoreType); 
        
        Console.WriteLine(robotCore.PrintCharacteristics);
    }
}