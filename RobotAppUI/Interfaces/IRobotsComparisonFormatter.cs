using RobotAppUI.Reports;

namespace RobotAppUI.Interfaces
{
    public interface IRobotsComparisonFormatter
    {
        string Format(RobotComparisonReport report);
    }
}