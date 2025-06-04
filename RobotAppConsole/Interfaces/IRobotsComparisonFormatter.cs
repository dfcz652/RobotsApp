using RobotApp.Services.Reports;

namespace RobotAppConsole.Interfaces
{
    public interface IRobotsComparisonFormatter
    {
        string Format(RobotComparisonReport report);
    }
}