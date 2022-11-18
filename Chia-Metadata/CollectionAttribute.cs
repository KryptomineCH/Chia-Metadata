using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chia_Metadata_CHIP_0007_std
{
    public class CollectionAttribute
    {
        public CollectionAttribute(string Type, string Value)
        {
            type = Type;
            value = Value;
        }
        public CollectionAttribute() { }
        /// <summary>
        ///  the attribute name, eg sharpness
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// the value of the attribute, eg 10
        /// </summary>
        public string value { get; set; }
    }
}
