using System.Text;

namespace Chia_Metadata
{
    internal static class IO
    {
        internal static void Save(Metadata data, string path)
        {
            if (!path.EndsWith(".json"))
            {
                path += ".json";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            sb.Append("\n    \"format\": "+data.Format+",\n");
            sb.Append("    \"name\": " + data.Name+",\n");
            sb.Append("    \"description\": " + data.Description+",\n");
            sb.Append("    \"minting_tool\": " + data.MintingTool+",\n");
            sb.Append("    \"sensitive_content\": " + data.SensitiveContent.ToString()+",\n");
            sb.Append("    \"series_number\": " + data.SeriesNumber+",\n");
            sb.Append("    \"series_total\": " + data.SeriesTotal+",\n");
            if (data.Attributes.Count > 0)
            { // attributes
                sb.Append("    \"attributes\": [\n");
                foreach (Attribute attribute in data.Attributes)
                {
                    sb.Append("        {\n");
                    sb.Append("            \"trait_type\": " + attribute.AttributeName + ",\n");
                    sb.Append("            \"value\": " + attribute.AttributeValue);
                    if (attribute.MinAttributeValue != null)
                    {
                        sb.Append(",\n");
                        sb.Append("            \"min_value\": " + attribute.MinAttributeValue);
                    }
                    if (attribute.MaxAttributeValue != null)
                    {
                        sb.Append(",\n");
                        sb.Append("            \"max_value\": " + attribute.MaxAttributeValue);
                    }
                    sb.Append("        },\n");
                }
                sb.Remove(sb.Length - 2, 1);
                sb.Append("    ],\n");
            }
            if (data.Collection != null)
            { // Collection
                sb.Append("    \"collection\": {\n");
                sb.Append("        \"name\": \"" + data.Collection.Name + ",\n");
                sb.Append("        \"id\": \"" + data.Collection.ID + ",\n");
                sb.Append("        \"attributes\": [\n");
                sb.Append("            {\n");
                sb.Append("                \"type\": \"description\",\n");
                sb.Append("                \"value\": \"" + data.Collection.Description + "\n");
                sb.Append("            },\n");
                sb.Append("            {\n");
                sb.Append("                \"type\": \"icon\",\n");
                sb.Append("                \"value\": \"" + data.Collection.IconLink + "\n");
                sb.Append("            },\n");
                sb.Append("            {\n");
                sb.Append("                \"type\": \"banner\",\n");
                sb.Append("                \"value\": \"" + data.Collection.BannerLink + "\n");
                sb.Append("            },\n");
                sb.Append("            {\n");
                sb.Append("                \"type\": \"website\",\n");
                sb.Append("                \"value\": \"" + data.Collection.Weblink + "\n");
                sb.Append("            }\n");
                sb.Append("        ]\n");
                sb.Append("    }\n");
            }
            sb.Append('}');
            File.WriteAllText(path, sb.ToString());
        }
    }
}
