using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ExileNET.API.PublicStashTabs
{
    public class Stash
    {
        public Stash(JObject rawData)
        {
            if (rawData["next_change_id"] != null)
                NextChangeId = rawData["next_change_id"].ToString();
            if (rawData["stashes"] != null && rawData["stashes"].HasValues)
            {
                Entries = new List<StashTab>();
                foreach (JObject obj in rawData["stashes"])
                {
                    var stash = new StashTab(obj);
                    Entries.Add(stash);
                }
            }
        }

        /// <summary>
        ///     The Next Change ID for the API
        /// </summary>
        public string NextChangeId { get; internal set; }

        /// <summary>
        ///     The Retrieved Stashes
        /// </summary>
        public List<StashTab> Entries { get; internal set; }
    }
}