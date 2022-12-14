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
            List<MetadataAttribute> Attributes = null,
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
                attributes = Attributes.ToList();
            }
            collection = Collection;
        }
        /// <summary>
        /// this constructos is for the json deserializer
        /// </summary>
        public Metadata() { 
            attributes = new List<MetadataAttribute> ();
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
        public List<MetadataAttribute> attributes { get; set; }
        /// <summary>
        /// the collection which this NFT belongs to
        /// </summary>
        public Collection collection { get; set; }
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
