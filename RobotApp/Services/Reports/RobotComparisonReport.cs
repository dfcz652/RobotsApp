namespace RobotApp.Services
{
    public class RobotComparisonReport
    {
        public string FirstRobotName { get; set; }

        public string SecondRobotName { get; set; }

        public List<ComparisonResult> ComparisonResults { get; set; } = [];
    }
}