using RobotApp.RobotParts;

namespace RobotApp
{
    internal class Robot
    {
        public CoreBase Core { get; set; }

        public BodyBase Body { get; set; }

        public ArmsBase Arms { get; set; }

        public LegsBase Legs { get; set; }

        public void AddCore(CoreBase robotPart)
        {
            Core = robotPart;
        }

        public void AddBody(BodyBase robotPart)
        {
            Body = robotPart;
        }

        public void AddArms(ArmsBase robotPart)
        {
            Arms = robotPart;
        }

        public void AddLegs(LegsBase robotPart)
        {
            Legs = robotPart;
        }
    }
}
