using DisplayNameService;

namespace DisplayNameServiceTests
{
    public class SerializationDisplayNamesTests
    {
        private CharacteristicDisplayNames characteristicDisplayNames = new()
        {
            Characteristics = new List<CharacteristicDisplayName>
            {
                new CharacteristicDisplayName { Name = "ActionSpeed", DisplayName = "Action speed" },
                new CharacteristicDisplayName { Name = "Armor", DisplayName = "Armor" },
                new CharacteristicDisplayName { Name = "Dmg", DisplayName = "Damage" }
            }
        };

        [Fact]
        public void SerializeCharacteristicDisplayNamesToJsonFile_ShouldCreateCorrectJson()
        {
            string actualFilename = @"Data\SerializationDictionary.json";
            string expectedFilename = @"Data\CharacteristicDisplayNames.json";

            SerializationDisplayNames.SerializeCharacteristicDisplayNamesToJson(characteristicDisplayNames, actualFilename);

            string actualJson = File.ReadAllText(actualFilename);
            string expectedJson = File.ReadAllText(expectedFilename);
            Assert.Equal(expectedJson, actualJson);
        }

        [Fact]
        public void DeserializeJsonFileToCharacteristicDisplayNames_ShouldReturnCorrectCharacteristicDisplayNames()
        {
            var actualDictionary = SerializationDisplayNames.DeserializeCharacteristicDisplayNamesFromJson(@"Data\CharacteristicDisplayNames.json");

            TestUtils.AssertEqualsCharacteristicDisplayNames(characteristicDisplayNames, actualDictionary);
        }
    }
}
