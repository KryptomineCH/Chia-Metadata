using System.Text.RegularExpressions;

namespace Chia_Metadata
{
    /// <summary>
    /// a general attribute which can be used to further describe the nft.<br/>
    /// for example: Colorfulness: 5
    /// </summary>
    public class MetadataAttribute
    {
        /// <summary>
        /// represents an attribute for an nft which can be displayed on explorers like a tag
        /// </summary>
        /// <param name="Trait_Type"></param>
        /// <param name="Value"></param>
        public MetadataAttribute(string Trait_Type, string Value)
        {
            trait_type = Trait_Type;
            value = Value;
        }
        /// <summary>
        /// represents an attribute for an nft which can be displayed on explorers like bar
        /// </summary>
        /// <param name="Trait_Type"></param>
        /// <param name="Value"></param>
        /// <param name="Min_Value"></param>
        /// <param name="Max_Value"></param>
        public MetadataAttribute(string Trait_Type, int Value, int? Min_Value = null, int? Max_Value = null)
        {
            trait_type = Trait_Type;
            value = Value;
            min_value = Min_Value;
            max_value = Max_Value;
        }
        /// <summary>
        /// this constructor is for the json deserializer
        /// </summary>
        public MetadataAttribute() { }
        /// <summary>
        ///  the attribute name, eg sharpness
        /// </summary>
        public string? trait_type { get; set; }
        /// <summary>
        /// the value of the attribute, eg 10
        /// </summary>
        public object? value { get; set; }
        /// <summary>
        /// optional: the minimum value atribute to provide a possible range
        /// </summary>
        public int? min_value{get;set;}
        /// <summary>
        /// optional: the maximum value attribute to provide a possible range
        /// </summary>
        public int? max_value { get; set; }
        /// <summary>
        /// This function checks if the MetadataAttribute object matches the filter.
        /// </summary>
        /// <param name="filter">The filter to match the MetadataAttribute object against</param>
        /// <returns>True if the MetadataAttribute object matches the filter, False otherwise</returns>
        public bool AttributeMatchesFilter( MetadataAttribute filter)
        {
            if (trait_type != filter.trait_type)
            {
                return false;
            }
            if (filter.value != null || filter.min_value != null || filter.max_value != null)
            { // a filter is present
                if (value == null)
                {
                    return false;
                }
                string? attributeValueString = value.ToString();
                if (filter.value != null && !string.IsNullOrEmpty(attributeValueString))
                {
                    string? filterValueString = filter.value.ToString();
                    // compare the filter value if applicable
                    if (!string.IsNullOrEmpty(filterValueString) && filterValueString != "*" && filterValueString != "Value" && filterValueString != ".*" )
                    {
                        if (!Regex.IsMatch(attributeValueString, filterValueString))
                        {
                            return false;
                        }
                    }
                }
                // compare filter values
                double attributeValue;
                if (filter.min_value != null)
                {
                    if (double.TryParse(attributeValueString, out attributeValue))
                    {
                        if (attributeValue < filter.min_value)
                        {
                            return false;
                        }
                    }
                }
                if (filter.max_value != null)
                {
                    if (double.TryParse(attributeValueString, out attributeValue))
                    {
                        if (attributeValue > filter.max_value)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
