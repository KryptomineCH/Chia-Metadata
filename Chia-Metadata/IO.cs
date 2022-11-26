using System.Text;
using System.Text.Json;

namespace Chia_Metadata
{
    public static class IO
    {
        public static void Save(Metadata data, string path)
        {
            if (!path.EndsWith(".json"))
            {
                path += ".json";
            }
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            string testText = JsonSerializer.Serialize(data,options: options);
            File.WriteAllText(path, testText,Encoding.UTF8);
        }
        public static Metadata Load(string path)
        {
            FileInfo testFile = new FileInfo(path);
            string text = File.ReadAllText(testFile.FullName);
            Metadata json = JsonSerializer.Deserialize<Metadata>(text);
            return json;
        }
        public static Metadata LoadFromJson(string jsonText)
        {
            Metadata json = JsonSerializer.Deserialize<Metadata>(jsonText);
            return json;
        }
        public static Metadata LoadFromByteArray(byte[] input)
        {
            var str = Encoding.UTF8.GetString(input);
            return LoadFromJson(str);
        }
    }
}
