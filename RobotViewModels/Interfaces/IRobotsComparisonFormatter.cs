using RobotApp.RobotData.Base;
using RobotApp.Services.Dtos;
using RobotApp.Services.Reports;

namespace RobotViewModels.Interfaces
{
    public interface IRobotsComparisonFormatter
    {
        string FormatTwoItems(ItemComparisonReport report);

        string FormatPartDetails(string itemName, List<ItemCharacteristicDto> characteristics);
        List<string> FormatRobotCharacteristics(List<RobotCharacteristicBase> robotCharacteristics);
    }
}