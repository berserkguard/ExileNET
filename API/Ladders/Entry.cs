using ExileNET.API.Accounts;
using ExileNET.API.Characters;
using Newtonsoft.Json.Linq;

namespace ExileNET.Ladders
{
    public class Entry
    {
        public Entry(JObject rawData)
        {
            if (rawData["rank"] != null)
                Rank = int.Parse(rawData["rank"].ToString());
            if (rawData["dead"] != null)
                Dead = bool.Parse(rawData["dead"].ToString());
            if (rawData["online"] != null)
                Online = bool.Parse(rawData["online"].ToString());
            if (rawData["character"] != null)
                Character = new Character(JObject.Parse(rawData["character"].ToString()));
            if (rawData["account"] != null)
                Account = new Account(JObject.Parse(rawData["account"].ToString()));
        }

        /// <summary>
        ///     The Entry Rank
        /// </summary>
        public int Rank { get; internal set; }

        /// <summary>
        ///     The Alive Status
        /// </summary>
        public bool Dead { get; internal set; }

        /// <summary>
        ///     The Online Status
        /// </summary>
        public bool Online { get; internal set; }

        /// <summary>
        ///     The Character Associated with this Entry
        /// </summary>
        public Character Character { get; internal set; }

        /// <summary>
        ///     The Account Associated with this Entry
        /// </summary>
        public Account Account { get; internal set; }
    }
}