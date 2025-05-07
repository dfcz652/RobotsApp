using RobotApp.Services.Reports;

namespace RobotApp.Services.Interfaces
{
    public interface IRobotsComparisonFormatter
    {
        string Format(RobotComparisonReport report);
    }
}