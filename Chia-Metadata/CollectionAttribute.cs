namespace Chia_Metadata_CHIP_0007_std
{
    /// <summary>
    /// a collection attribute is basically a keyvaluepair.
    /// it is used to decompile a json
    /// </summary>
    public class CollectionAttribute
    {
        /// <summary>
        /// a collection attribute is basically a keyvaluepair.
        /// it is used to decompile a json
        /// </summary>
        public CollectionAttribute(string Type, string Value)
        {
            type = Type;
            value = Value;
        }
        /// <summary>
        /// a collection attribute is basically a keyvaluepair.
        /// it is used to decompile a json
        /// </summary>
        public CollectionAttribute() { }
        /// <summary>
        ///  the attribute name, eg sharpness
        /// </summary>
        public string? type { get; set; }
        /// <summary>
        /// the value of the attribute, eg 10
        /// </summary>
        public string? value { get; set; }
    }
}
