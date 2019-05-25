using Newtonsoft.Json.Linq;

namespace ExileNET.API.Items
{
    public class ItemValue
    {
        public ItemValue(JObject rawData)
        {
            if (rawData["0"] != null)
                Value = rawData["0"].ToString();
        }

        /// <summary>
        ///     The Value of the Property
        /// </summary>
        public string Value { get; internal set; }
    }
}