﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chia_Metadata_CHIP_0007_std
{
    public class Metadata
    {
        public string Format = "CHIP-0007";
        /// <summary>
        /// the name of the NFT, EG Pikachu
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// a descriptive text such as
        /// "Electric-type Pokémon with stretchy cheeks"
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// which tool was used for minting (optional)
        /// </summary>
        public string MintingTool { get; set; }
        /// <summary>
        /// is this content for adults only or otherwise sensitive?
        /// </summary>
        public bool SensitiveContent { get; set; }
        /// <summary>
        /// this is the nth nft of the collection
        /// </summary>
        public int SeriesNumber { get; set; }
        /// <summary>
        /// the total size of the collection
        /// </summary>
        public int SeriesTotal { get; set; }
        /// <summary>
        /// the attributes of this nft, eg color, subset, rarity, sharpness, abilities, health, attack, ...
        /// </summary>
        public List<Attribute> Attributes { get; set; }
        /// <summary>
        /// the collection which this NFT belongs to
        /// </summary>
        public Collection Collection { get; set; }
    }
}
