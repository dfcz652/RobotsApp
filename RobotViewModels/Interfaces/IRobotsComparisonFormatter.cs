using RobotApp.Services.Reports;

namespace RobotViewModels.Interfaces
{
    public interface IRobotsComparisonFormatter
    {
        string Format(ItemComparisonReport report);
    }
}