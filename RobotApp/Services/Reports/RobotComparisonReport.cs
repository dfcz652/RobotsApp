using RobotApp.Services.Reports;

    public class RobotComparisonReport
    {
        public string FirstRobotName { get; set; } = null;

        public string SecondRobotName { get; set; } = null;

        public List<ComparisonResult> ComparisonResults { get; set; } = [];
    }