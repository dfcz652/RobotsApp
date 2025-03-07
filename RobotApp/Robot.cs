using RobotApp.RobotParts;

namespace RobotApp
{
    internal class Robot
    {

        public RobotPartBase Core { get; set; }

        public RobotPartBase Body { get; set; }

        public RobotPartBase Arms { get; set; }

        public RobotPartBase Legs { get; set; }

        public void AddCore(RobotPartBase robotPart)
        {
            Core = robotPart;
        }

        public void AddBody(RobotPartBase robotPart)
        {
            Body = robotPart;
        }

        public void AddArms(RobotPartBase robotPart)
        {
            Arms = robotPart;
        }

        public void AddLegs(RobotPartBase robotPart)
        {
            Legs = robotPart;
        }
    }
}
