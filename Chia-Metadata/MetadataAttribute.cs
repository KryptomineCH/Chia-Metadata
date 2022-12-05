namespace Chia_Metadata
{
    /// <summary>
    /// a general attribute which can be used to further describe the nft.<br/>
    /// for example: Colorfulness: 5
    /// </summary>
    public class MetadataAttribute
    {
        public MetadataAttribute(string Trait_Type, string Value)
        {
            trait_type = Trait_Type;
            value = Value;
        }
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
        public string trait_type { get; set; }
        /// <summary>
        /// the value of the attribute, eg 10
        /// </summary>
        public object value { get; set; }
        /// <summary>
        /// optional: the minimum value atribute to provide a possible range
        /// </summary>
        public int? min_value{get;set;}
        /// <summary>
        /// optional: the maximum value attribute to provide a possible range
        /// </summary>
        public int? max_value { get; set; }
    }
}
