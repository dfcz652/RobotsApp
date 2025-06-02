using System.Xml.Serialization;

namespace DisplayNameService
{
    public class CharacteristicDisplayNames
    {
        [XmlElement("Characteristic")]
        public List<CharacteristicDisplayName> Characteristics { get; set; } = new List<CharacteristicDisplayName>();
    }

    public class CharacteristicDisplayName
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string DisplayName { get; set; }
    }
}
