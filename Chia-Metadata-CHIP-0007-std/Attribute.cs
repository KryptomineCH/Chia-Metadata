using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chia_Metadata
{
    public class Attribute
    {
        /// <summary>
        ///  the attribute name, eg sharpness
        /// </summary>
        public string AttributeName { get; set; }
        /// <summary>
        /// the value of the attribute, eg 10
        /// </summary>
        public string AttributeValue { get; set; }
        /// <summary>
        /// optional: the minimum value atribute to provide a possible range
        /// </summary>
        public int? MinAttributeValue{get;set;}
        /// <summary>
        /// optional: the maximum value attribute to provide a possible range
        /// </summary>
        public int? MaxAttributeValue { get; set; }
    }
}
