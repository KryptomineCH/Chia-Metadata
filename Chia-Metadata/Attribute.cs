using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chia_Metadata
{
    public class Attribute
    {
        public Attribute(string name, string value, int? min = null, int? max = null)
        {
            Name = name;
            Value = value;
            MinValue = min;
            MaxValue = max;
        }
        /// <summary>
        ///  the attribute name, eg sharpness
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the value of the attribute, eg 10
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// optional: the minimum value atribute to provide a possible range
        /// </summary>
        public int? MinValue{get;set;}
        /// <summary>
        /// optional: the maximum value attribute to provide a possible range
        /// </summary>
        public int? MaxValue { get; set; }
    }
}
