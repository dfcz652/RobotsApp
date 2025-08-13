using RobotApp.RobotData.Base;
using RobotApp.Services.Reports;

namespace RobotApp.Services
{
    public interface IItemComparisonService
    {
        ItemComparisonReport CreateReportForTwoItems(RobotCharacteristicsBase item1, RobotCharacteristicsBase item2);
    }
}
