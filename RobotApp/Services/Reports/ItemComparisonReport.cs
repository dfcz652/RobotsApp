namespace RobotApp.Services.Reports
{
    public class ItemComparisonReport
    {
        public string FirstItemName { get; private set; }

        public string SecondItemName { get; private set; }

        public List<ComparisonResult> ComparisonResults { get; private set; }

        public ItemComparisonReport(string firstItemName, string secondItemName, 
            List<ComparisonResult> comparisonResults = null) 
        {
            FirstItemName = firstItemName;
            SecondItemName = secondItemName;
            ComparisonResults = comparisonResults;
        }
    }
}