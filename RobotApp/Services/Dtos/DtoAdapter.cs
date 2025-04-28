using RobotApp.RobotData.Base;

namespace RobotApp.Services.Dtos
{
    public static class DtoAdapter
    {
        public static RobotCharacteristicDto ToRobotCharacteristicDto(this RobotCharacteristicBase characteristic)
        {
            var dto = new RobotCharacteristicDto();

            dto.Name = characteristic.GetType().Name;
            dto.Value = characteristic.Value;

            return dto;
        }
    }
}