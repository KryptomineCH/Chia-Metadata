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
            //StringBuilder sb = new StringBuilder();
            //sb.Append('{');
            //sb.Append("\n    \"format\": \"" + data.format+ "\",\n");
            //sb.Append("    \"name\": \"" + data.name+"\",\n");
            //sb.Append("    \"description\": \"" + data.description+"\",\n");
            //sb.Append("    \"minting_tool\": \"" + data.minting_tool+"\",\n");
            //sb.Append("    \"sensitive_content\": \"" + data.sensitiveContent.ToString()+ "\",\n");
            //sb.Append("    \"series_number\": \"" + data.SeriesNumber+ "\",\n");
            //sb.Append("    \"series_total\": \"" + data.SeriesTotal+ "\",\n");
            //if (data.Attributes.Count > 0)
            //{ // attributes
            //    sb.Append("    \"attributes\": [\n");
            //    foreach (Attribute attribute in data.Attributes)
            //    {
            //        sb.Append("        {\n");
            //        sb.Append("            \"trait_type\": \"" + attribute.Name + "\",\n");
            //        sb.Append("            \"value\": \"" + attribute.Value+ "\"");
            //        if (attribute.MinValue != null)
            //        {
            //            sb.Append(",\n");
            //            sb.Append("            \"min_value\": \"" + attribute.MinValue+ "\"");
            //        }
            //        if (attribute.MaxValue != null)
            //        {
            //            sb.Append(",\n");
            //            sb.Append("            \"max_value\": \"" + attribute.MaxValue+ "\"");
            //        }
            //        sb.Append("        },\n");
            //    }
            //    sb.Remove(sb.Length - 2, 1);
            //    sb.Append("    ],\n");
            //}
            //if (data.Collection != null)
            //{ // Collection
            //    sb.Append("    \"collection\": {\n");
            //    sb.Append("        \"name\": \"" + data.Collection.Name + "\",\n");
            //    sb.Append("        \"id\": \"" + data.Collection.ID + "\",\n");
            //    sb.Append("        \"attributes\": [\n");
            //    sb.Append("            {\n");
            //    sb.Append("                \"type\": \"description\",\n");
            //    sb.Append("                \"value\": \"" + data.Collection.Description + "\"\n");
            //    sb.Append("            },\n");
            //    sb.Append("            {\n");
            //    sb.Append("                \"type\": \"icon\",\n");
            //    sb.Append("                \"value\": \"" + data.Collection.IconLink + "\"\n");
            //    sb.Append("            },\n");
            //    sb.Append("            {\n");
            //    sb.Append("                \"type\": \"banner\",\n");
            //    sb.Append("                \"value\": \"" + data.Collection.BannerLink + "\"\n");
            //    sb.Append("            },\n");
            //    sb.Append("            {\n");
            //    sb.Append("                \"type\": \"website\",\n");
            //    sb.Append("                \"value\": \"" + data.Collection.Weblink + "\"\n");
            //    sb.Append("            }\n");
            //    sb.Append("        ]\n");
            //    sb.Append("    }\n");
            //}
            //sb.Append('}');
            //File.WriteAllText(path, sb.ToString());
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            string testText = JsonSerializer.Serialize(data,options: options);
            File.WriteAllText(path, testText);
        }
        public static Metadata Load(string path)
        {
            FileInfo testFile = new FileInfo(path);
            string text = File.ReadAllText(testFile.FullName);
            Metadata json = JsonSerializer.Deserialize<Metadata>(text);
            return json;
        }
    }
}
