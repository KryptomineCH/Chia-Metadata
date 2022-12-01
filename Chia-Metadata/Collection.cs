using Chia_Metadata_CHIP_0007_std;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chia_Metadata
{
    public class Collection
    {
        public Collection(
            string Name, string ID, string Description,  
            string IconLink, string BannerLink,
            List<CollectionAttribute> socialMedia = null)
        {
            name = Name;
            id = ID;
            attributes = new List<CollectionAttribute>();
            attributes.Add(new CollectionAttribute("description", Description));
            attributes.Add(new CollectionAttribute("icon", IconLink));
            attributes.Add(new CollectionAttribute("banner", BannerLink));
            if (socialMedia != null) attributes.AddRange(socialMedia);
        }
        public Collection(
            string Name, string ID, List<CollectionAttribute> Attributes = null)
        {
            name = Name;
            id = ID;
            attributes = Attributes;
        }
        public Collection() { 
            attributes = new List<CollectionAttribute>();
        }
        /// <summary>
        /// the collection name. eg pokemon nft
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// the collection id, eg "e43fcfe6-1d5c-4d6e-82da-5de3aa8b3b57"
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// attributes contains description as well as some additional attributes like contact, twitter, discord etc.
        /// </summary>
        public List<CollectionAttribute> attributes { get; set; }
        public string GetAttribute(string type)
        {
            foreach (CollectionAttribute attribute in attributes)
            {
                if (attribute.type == type)
                {
                    return attribute.value;
                }
            }
            return "";
        }
        public void SetAttribute(string type, string description)
        {
            bool attributeExisted = false;
            foreach (CollectionAttribute attribute in attributes)
            {
                if (attribute.type == type)
                {
                    attributeExisted = true;
                    attribute.value = description;
                    break;
                }
            }
            if (!attributeExisted)
            {
                attributes.Add(new CollectionAttribute(type, description));
            }
        }
        public void UpdateOrAddAttributes(CollectionAttribute[] attributes)
        {
            foreach(CollectionAttribute attribute in attributes)
            {
                SetAttribute(attribute.type, attribute.value);
            }
        }
    }
}
