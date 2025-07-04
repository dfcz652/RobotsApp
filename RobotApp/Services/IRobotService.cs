using RobotApp.RobotData;
using RobotApp.RobotData.Base;
using RobotApp.Services.Reports;

namespace RobotApp.Services
{
    public interface IRobotService
    {
        ItemComparisonReport CreateRobotComparisonReport(RobotCharacteristicsBase robot1, RobotCharacteristicsBase robot2);
    }
}
