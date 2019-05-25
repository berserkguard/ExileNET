using Newtonsoft.Json.Linq;

namespace ExileNET.Leagues
{
    public class LeagueRuleSet
    {
        public LeagueRuleSet(JObject rawData)
        {
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["id"] != null)
                Id = rawData["id"].ToString();
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
        }

        /// <summary>
        ///     The Ruleset Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The Ruleset ID
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     The Ruleset Description
        /// </summary>
        public string Description { get; internal set; }
    }
}