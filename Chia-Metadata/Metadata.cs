namespace Chia_Metadata
{
    /// <summary>
    /// represents a fully fleged chip-0007 compliant json metadatda file
    /// </summary>
    public class Metadata
    {
        public Metadata(
            string Name,
            string Description,
            string Format = "CHIP-0007",
            string Minting_Tool = "Kryptomine MintingTool",
            bool Sensitive_Content = false,
            ulong Series_Number = 1,
            ulong Series_Total = 1,
            MetadataAttribute[] Attributes = null,
            Collection Collection = null)
        {
            format = Format;
            name = Name;
            description = Description;
            minting_tool = Minting_Tool;
            sensitive_content = Sensitive_Content;
            series_number = Series_Number;
            series_total = Series_Total;
            if (Attributes != null)
            {
                attributes = Attributes.ToArray();
            }
            collection = Collection;
        }
        /// <summary>
        /// this constructos is for the json deserializer
        /// </summary>
        public Metadata() {
            attributes = new MetadataAttribute[] { };
            collection = new Collection();
            format = "CHIP-0007";
        }
        /// <summary>
        /// the metadata standard (eg. CHIP-0007)
        /// </summary>
        public string format { get; set; }
        /// <summary>
        /// the name of the NFT, EG Pikachu
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// a descriptive text such as
        /// "Electric-type Pokémon with stretchy cheeks"
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// which tool was used for minting (optional)
        /// </summary>
        public string minting_tool { get; set; }
        /// <summary>
        /// is this content for adults only or otherwise sensitive?
        /// </summary>
        public bool sensitive_content { get; set; }
        /// <summary>
        /// this is the nth nft of the collection
        /// </summary>
        public ulong series_number { get; set; }
        /// <summary>
        /// the total size of the collection
        /// </summary>
        public ulong series_total { get; set; }
        /// <summary>
        /// the attributes of this nft, eg color, subset, rarity, sharpness, abilities, health, attack, ...
        /// </summary>
        /// <remarks>
        /// this array is primairly for Json serialisation / deserialisation. for lookup the hashset or the dictionary is recommended <br/>
        /// if you need to update the attributes, It is recommended to use the add/remove/update functions.
        /// </remarks>
        public MetadataAttribute[] attributes
        {
            get { return _attributes.ToArray(); }
            set
            {
                _attributes = value.ToList();
                AttributeNames.Clear();
                AttributesDictionary.Clear();
                if (_attributes != null)
                {
                    foreach (var attr in _attributes)
                    {
                        AttributeNames.Add(attr.trait_type);
                        AttributesDictionary[attr.trait_type] = attr;
                    }
                }
            }
        }
        private List<MetadataAttribute> _attributes = new List<MetadataAttribute>();
        public HashSet<string> AttributeNames = new HashSet<string>();
        public Dictionary<string, MetadataAttribute> AttributesDictionary = new Dictionary<string, MetadataAttribute>();
        /// <summary>
        /// the collection which this NFT belongs to
        /// </summary>
        public Collection collection { get; set; }
        /// <summary>
        /// adds an attribute to the collection
        /// </summary>
        /// <param name="attribute"></param>
        public void AddAttribute(MetadataAttribute attribute)
        {
            _attributes.Add(attribute);
            AttributeNames.Add(attribute.trait_type);
            AttributesDictionary[attribute.trait_type] = attribute;
        }
        /// <summary>
        /// removes an attribute from the collection
        /// </summary>
        /// <param name="attribute"></param>
        public void RemoveAttribute(MetadataAttribute attribute)
        {
            _attributes.Remove(attribute);
            AttributeNames.Remove(attribute.trait_type);
            AttributesDictionary.Remove(attribute.trait_type);
        }
        /// <summary>
        /// updates the first instance of a given attribute in the collection
        /// </summary>
        /// <remarks>
        /// either edit the reference or make sure the attribute is unique
        /// </remarks>
        /// <param name="attribute"></param>
        public void UpdateAttribute(MetadataAttribute attribute)
        {
            var index = _attributes.FindIndex(a => a.trait_type == attribute.trait_type);
            if (index != -1)
            {
                attributes[index] = attribute;
                AttributesDictionary[attribute.trait_type] = attribute;
            }
        }
        /// <summary>
        /// Saves the Metadata to the specified path as json file
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            IO.Save(this, path);
        }
    }
}
