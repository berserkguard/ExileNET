using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ExileNET.API.Items
{
    public class ItemRequirement
    {
        public ItemRequirement(JObject rawData)
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
        }

        /// <summary>
        ///     The Requirement Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The Requirement Values
        /// </summary>
        public List<ItemValue> Values { get; internal set; }

        /// <summary>
        ///     The Requirement Display Mode
        /// </summary>
        public int DisplayMode { get; internal set; }
    }
}