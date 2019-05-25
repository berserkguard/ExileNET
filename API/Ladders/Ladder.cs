using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ExileNET.Ladders
{
    public class Ladder
    {
        public Ladder(JObject rawData)
        {
            if (rawData["total"] != null)
                Total = int.Parse(rawData["total"].ToString());
            if (rawData["cached_since"] != null)
                LastCache = rawData["cached_since"].ToString();
            if (rawData["entries"] != null && rawData["entries"].HasValues)
            {
                Entries = new List<Entry>();
                foreach (JObject obj in rawData["entries"])
                {
                    var entry = new Entry(obj);
                    Entries.Add(entry);
                }
            }

            if (rawData["title"] != null)
                Title = rawData["title"].ToString();
            if (rawData["startTime"] != null)
                StartTime = long.Parse(rawData["startTime"].ToString());
        }

        /// <summary>
        ///     Total Number of Entries
        /// </summary>
        public int Total { get; internal set; }

        /// <summary>
        ///     The Last Cached Date
        /// </summary>
        public string LastCache { get; internal set; }

        /// <summary>
        ///     The Ladder Entries
        /// </summary>
        public List<Entry> Entries { get; internal set; }

        /// <summary>
        ///     The Ladder Title
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        ///     Gets the Ladder Start Time and Date as a UNIX Timestamp
        /// </summary>
        public long StartTime { get; internal set; }
    }
}