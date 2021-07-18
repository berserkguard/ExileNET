using Newtonsoft.Json.Linq;
using System;

namespace ExileNET.API.Items
{
    public class ItemValue
    {
        public ItemValue(JArray rawData)
        {
            if (rawData.Count != 2)
            {
                throw new System.Exception("Unexpected size!");
            }
            Label = rawData[0].ToString();
            Value = Int32.Parse(rawData[1].ToString());
        }

        /// <summary>
        ///     The string Label of the Property
        /// </summary>
        public string Label { get; internal set; }

        /// <summary>
        ///     The numeric Value of the Property
        /// </summary>
        public int Value { get; internal set; }
    }
}