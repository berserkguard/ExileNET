using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ExileNET.API.Items
{
    public class Vaal
    {
        public Vaal(JObject rawData)
        {
            if (rawData["baseTypeName"] != null)
                BaseTypeName = rawData["baseTypeName"].ToString();
            if (rawData["properties"] != null && rawData["properties"].HasValues)
            {
                Properties = new List<ItemProperty>();
                foreach (JObject obj in rawData["properties"])
                {
                    var property = new ItemProperty(obj);
                    Properties.Add(property);
                }
            }

            if (rawData["explicitMods"] != null && rawData["explicitMods"].HasValues)
            {
                ExplicitMods = new List<string>();
                foreach (string mod in rawData["explicitMods"]) ExplicitMods.Add(mod);
            }

            if (rawData["secDescrText"] != null)
                SecondaryDescriptionText = rawData["secDescrText"].ToString();
        }

        /// <summary>
        ///     The Base Type Name of this Vaal Skill
        /// </summary>
        public string BaseTypeName { get; internal set; }

        /// <summary>
        ///     The Vaal Properties
        /// </summary>
        public List<ItemProperty> Properties { get; internal set; }

        /// <summary>
        ///     The Vaal Explicit Mods
        /// </summary>
        public List<string> ExplicitMods { get; internal set; }

        /// <summary>
        ///     The Secondary Description Text
        /// </summary>
        public string SecondaryDescriptionText { get; internal set; }
    }
}