﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chia_Metadata
{
    public class Collection
    {
        public Collection(string name, string iD, string description, string link, string iconLink, string bannerLink)
        {
            Name = name;
            ID = iD;
            Description = description;
            Weblink = link;
            IconLink = iconLink;
            BannerLink = bannerLink;

        }
        /// <summary>
        /// the collection name. eg pokemon nft
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the collection id, eg "e43fcfe6-1d5c-4d6e-82da-5de3aa8b3b57"
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// the collection description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// weblink to the collection
        /// </summary>
        public string Weblink { get; set; }
        /// <summary>
        /// link to the collection icon
        /// </summary>
        public string IconLink { get; set; }
        /// <summary>
        /// link to the collections background banner
        /// </summary>
        public string BannerLink { get; set; }
    }
}