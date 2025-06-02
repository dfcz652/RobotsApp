using static DisplayNameService.SerializationDisplayNames;

namespace DisplayNameService
{
    public static class DisplayNameProvider
    {
        public static string GetDisplayName(string name)
        {
            var displayNames = DeserializeCharacteristicDisplayNamesFromJson(@"Data\DisplayNames.json");

            string characteristicDisplayName = GetDisplayNameByName(displayNames, name);

            return characteristicDisplayName;
        }

        private static string GetDisplayNameByName(CharacteristicDisplayNames displayNames, string name)
        {
            CharacteristicDisplayName characteristicDisplayName = displayNames.Characteristics
                .FirstOrDefault(c => c.Name == name);

            if (characteristicDisplayName == null)
            {
                throw new InvalidDataException($"Display name not found");
            }
            return characteristicDisplayName.DisplayName;
        }
    }
}