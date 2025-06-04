namespace RobotAppUI.Reports
{
    public class RobotComparisonReport
    {
        public string FirstRobotName { get; private set; }

        public string SecondRobotName { get; private set; }

        public List<ComparisonResult> ComparisonResults { get; private set; }

        public RobotComparisonReport(string firstRobotName, string secondRobotName, 
            List<ComparisonResult> comparisonResults = null) 
        {
            FirstRobotName = firstRobotName;
            SecondRobotName = secondRobotName;
            ComparisonResults = comparisonResults;
        }
    }
}