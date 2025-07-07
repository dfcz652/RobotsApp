using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.Services.Reports;

namespace RobotApp.Services
{
    public interface IItemComparisonService
    {
        ItemComparisonReport CreateItemComparisonReport(RobotCharacteristicsBase item1, RobotCharacteristicsBase item2);
    }
}
