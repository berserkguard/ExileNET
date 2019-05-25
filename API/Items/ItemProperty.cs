using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ExileNET.API.Items
{
    public class ItemProperty
    {
        public ItemProperty(JObject rawData)
        {
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["values"] != null && rawData["values"].HasValues)
            {
                Values = new List<ItemValue>();
                foreach (JObject obj in rawData["values"])
                {
                    var value = new ItemValue(obj);
                    Values.Add(value);
                }
            }

            if (rawData["displayMode"] != null)
                DisplayMode = int.Parse(rawData["displayMode"].ToString());
            if (rawData["type"] != null)
                Type = int.Parse(rawData["type"].ToString());
        }

        /// <summary>
        ///     The Property Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The Values of the Property
        /// </summary>
        public List<ItemValue> Values { get; internal set; }


        /// <summary>
        ///     The Property Display Mode
        /// </summary>
        public int DisplayMode { get; internal set; }

        /// <summary>
        ///     The Property Type ID
        /// </summary>
        public int Type { get; internal set; }
    }
}