using DisplayNameService;
using RobotApp.RobotData.Base;

namespace RobotApp.Services.Dtos
{
    public static class DtoAdapter
    {
        public static RobotCharacteristicDto ToRobotCharacteristicDto(this RobotCharacteristicBase characteristic)
        {
            var dto = new RobotCharacteristicDto();

            dto.Name = characteristic.GetType().Name;
            dto.DisplayName = DisplayNameProvider.GetDisplayName(dto.Name);
            dto.Value = characteristic.Value;

            return dto;
        }

        public static List<RobotCharacteristicDto> ToRobotCharacteristicsDtoList(this List<RobotCharacteristicBase> characteristics)
        {
            var dtoCharacteristics = new List<RobotCharacteristicDto>();

            foreach (var characteristic in characteristics)
            {
                dtoCharacteristics.Add(characteristic.ToRobotCharacteristicDto());
            }

            return dtoCharacteristics;
        }
    }
}