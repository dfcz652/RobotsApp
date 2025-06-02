using System.Text.Json;

namespace DisplayNameService
{
    public class SerializationDisplayNamesJson
    {
        public static void SerializeCharacteristicDisplayNamesToJson(CharacteristicDisplayNames displayNames, string filename)
        {
            var data = new { displayNames.Characteristics };

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filename, jsonString);
        }

        public static CharacteristicDisplayNames DeserializeCharacteristicDisplayNamesFromJson(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            var data = JsonSerializer.Deserialize<CharacteristicDisplayNames>(jsonString);
            return data;
        }
    }
}