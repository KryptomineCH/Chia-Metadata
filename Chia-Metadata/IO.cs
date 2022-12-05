using System.Text;
using System.Text.Json;

namespace Chia_Metadata
{
    /// <summary>
    /// IO Class is used to load/save ant compile/decompile metadata <--> json
    /// </summary>
    public static class IO
    {
        /// <summary>
        /// saves metada to path as json
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
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
            Encoding utf8WithoutBom = new UTF8Encoding(false); // IMPORTANT: no bom
            File.WriteAllText(path, testText, utf8WithoutBom);
        }
        /// <summary>
        /// loads metadata from a json file on disk
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// loads metadata from json string, eg from a webrequest
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static Metadata LoadFromJson(string jsonText)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                 
            WriteIndented = true
            };
            Metadata json = JsonSerializer.Deserialize<Metadata>(jsonText);
            return json;
        }
        /// <summary>
        /// loads metadata from a string represented as byte array. For example from a webrequest or bytestream
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
        }
    }
}
