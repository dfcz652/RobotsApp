using DisplayNameService;
using static DisplayNameService.SerializationDisplayNamesXml;

namespace DisplayNameServiceTests
{
    public class SerializationDisplayNamesXmlTests
    {
        private CharacteristicDisplayNames displayNames = new()
        {
            Characteristics = new List<CharacteristicDisplayName>
            {
                new CharacteristicDisplayName { Name = "ActionSpeed", DisplayName = "Action speed" },
                new CharacteristicDisplayName { Name = "Armor", DisplayName = "Armor" },
                new CharacteristicDisplayName { Name = "Dmg", DisplayName = "Damage" }
            }
        };

        [Fact]
        public void SerializeDictionaryToXmlFile_ShouldCreateCorrectXml()
        {
            string actualFilename = @"Data\SerializationDictionary.xml";
            string expectedFilename = @"Data\CharacteristicDisplayNames.xml";

            SerializeDictionaryToXml(displayNames, actualFilename);

            string actualXml = File.ReadAllText(actualFilename);
            string expectedXml = File.ReadAllText(expectedFilename);

            Assert.Equal(expectedXml, actualXml);
        }

        [Fact]
        public void DeserializeXmlFileToDictionary_ShouldReturnCorrectDictionary()
        {
            CharacteristicDisplayNames actual = DeserializeDictionaryFromXml(@"Data\CharacteristicDisplayNames.xml");

            TestUtils.AssertEqualsCharacteristicDisplayNames(displayNames, actual);
        }
    }
}
