using static DisplayNameService.SerializationDisplayNamesXml;
using static DisplayNameService.SerializationDisplayNamesJson;

namespace DisplayNameService
{
    public class DisplayNameProvider
    {

        public string GetDisplayNameFromJson(string name)
        {
            var displayNames = DeserializeCharacteristicDisplayNamesFromJson(@"Data\DisplayNames.json");

            string characteristicDisplayName = GetDisplayNameByName(displayNames, name);

            return characteristicDisplayName;
        }

        public string GetDisplayNameFromXml(string name)
        {
            var displayNames = DeserializeDictionaryFromXml(@"Data\DisplayNames.xml");

            string characteristicDisplayName = GetDisplayNameByName(displayNames, name);

            return characteristicDisplayName;
        }

        private string GetDisplayNameByName(CharacteristicDisplayNames displayNames, string name)
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
