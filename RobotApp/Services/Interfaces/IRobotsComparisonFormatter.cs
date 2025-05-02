using RobotApp.RobotData;
using RobotAppTests.Tests;

namespace RobotApp.Services.Interfaces
{
    public interface IRobotsComparisonFormatter
    {
        void Format(RobotComparisonReport report);
    }
}