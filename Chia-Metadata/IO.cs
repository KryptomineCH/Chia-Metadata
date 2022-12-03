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
            try
            {
                Metadata json = JsonSerializer.Deserialize<Metadata>(text);
                return json;
            }
            catch (Exception ex)
            {
                { }
            }
            throw new Exception("metadata could not be loaded!");
        }
        public static Metadata LoadFromJson(string jsonText)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                 
            WriteIndented = true
            };
            Metadata json = JsonSerializer.Deserialize<Metadata>(jsonText);
            return json;
        }
        public static Metadata LoadFromByteArray(byte[] input)
        {

            using (var stream = new MemoryStream(input))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    Metadata json = JsonSerializer.Deserialize<Metadata>(stream);
                    return json;
                }
            }
            //if (input[0] == utf8Bom[0]|| input[0] == utf8Bom[1] || input[0] == utf8Bom[2])
            //{
            //    input = input.Slice(utf8Bom.Length);
            //}
            //var str = Encoding.UTF8.GetString(input);
            //return LoadFromJson(str);
        }
    }
}
