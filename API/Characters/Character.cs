using Newtonsoft.Json.Linq;

namespace ExileNET.API.Characters
{
    public class Character
    {
        public Character(JObject rawData)
        {
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["level"] != null)
                Level = int.Parse(rawData["level"].ToString());
            if (rawData["class"] != null)
                Class = rawData["class"].ToString();
            if (rawData["id"] != null)
                Id = rawData["id"].ToString();
            if (rawData["experience"] != null)
                Experience = long.Parse(rawData["experience"].ToString());
        }

        /// <summary>
        ///     The Characters Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The Characters Level
        /// </summary>
        public int Level { get; internal set; }

        /// <summary>
        ///     The Characters Class
        /// </summary>
        public string Class { get; internal set; }

        /// <summary>
        ///     The Characters ID
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     The Characters Total Experience
        /// </summary>
        public long Experience { get; internal set; }
    }
}