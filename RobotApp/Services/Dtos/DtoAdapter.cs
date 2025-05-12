using RobotApp.RobotData.Base;

namespace RobotApp.Services.Dtos
{
    public static class DtoAdapter
    {
        private static readonly Dictionary<string, string> DisplayNames = new Dictionary<string, string>()
        {
            { "ActionSpeed", "Action speed" },
            { "Armor", "Armor" },
            { "Dmg", "Damage" },
            { "Energy", "Energy" },
            { "EnergyCost", "Energy cost"},
            { "EnergyRestoration", "Energy restoration" },
            { "Hp", "Health" },
            { "ImpactDistance", "Impatc distance" },
            { "MovementSpeed", "Movement speed" },
            { "Shield", "Shield"},
            { "ShieldCost", "Shield cost"}
        };

        public static RobotCharacteristicDto ToRobotCharacteristicDto(this RobotCharacteristicBase characteristic)
        {
            var dto = new RobotCharacteristicDto();

            dto.Name = characteristic.GetType().Name;
            dto.DisplayName = DisplayNames[dto.Name];
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