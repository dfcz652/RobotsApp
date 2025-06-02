using System.Xml.Serialization;

namespace DisplayNameService
{
    public class SerializationDisplayNamesXml
    {
        public static void SerializeDictionaryToXml(CharacteristicDisplayNames displayNames, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CharacteristicDisplayNames));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StreamWriter writer = new(filename))
            {
                serializer.Serialize(writer, displayNames, namespaces);
            }
        }

        public static CharacteristicDisplayNames DeserializeDictionaryFromXml(string filename)
        {
            XmlSerializer serializer = new(typeof(CharacteristicDisplayNames));

            using (StreamReader reader = new(filename))
            {
                CharacteristicDisplayNames characteristicDisplayNames = (CharacteristicDisplayNames)serializer.Deserialize(reader);

                return characteristicDisplayNames;
            }
        }
    }
}