using RobotApp.RobotData.Base;

namespace RobotApp.Services.Dtos
{
    public static class DtoAdapter
    {
        public static ItemCharacteristicDto ToRobotCharacteristicDto(this RobotCharacteristicBase characteristic)
        {
            var dto = new ItemCharacteristicDto();

            dto.Name = characteristic.GetType().Name;
            dto.Value = characteristic.Value;

            return dto;
        }

        public static List<ItemCharacteristicDto> ToRobotCharacteristicsDtoList(this List<RobotCharacteristicBase> characteristics)
        {
            var dtoCharacteristics = new List<ItemCharacteristicDto>();

            foreach (var characteristic in characteristics)
            {
                dtoCharacteristics.Add(characteristic.ToRobotCharacteristicDto());
            }

            return dtoCharacteristics;
        }
    }
}