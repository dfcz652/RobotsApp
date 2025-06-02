using System.Xml.Serialization;

namespace DisplayNameService
{
    public class CharacteristicDisplayNames
    {
        public List<CharacteristicDisplayName> Characteristics { get; set; } = new List<CharacteristicDisplayName>();
    }

    public class CharacteristicDisplayName
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}
