using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ExileNET.Leagues
{
    public class League
    {
        public League(JObject rawData)
        {
            if (rawData["id"] != null)
                Name = rawData["id"].ToString();
            if (rawData["realm"] != null)
                Platform = rawData["realm"].ToString();
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if (rawData["registerAt"] != null)
                RegisteredDate = rawData["registerAt"].ToString();
            if (rawData["url"] != null)
                URL = rawData["url"].ToString();
            if (rawData["startAt"] != null)
                StartDate = rawData["startAt"].ToString();
            if (rawData["endAt"] != null)
                EndDate = rawData["endAt"].ToString();
            if (rawData["delveEvent"] != null)
                DelveActive = bool.Parse(rawData["delveEvent"].ToString());
            if (rawData["rules"] != null && rawData["rules"].HasValues)
            {
                Rules = new List<LeagueRuleSet>();
                foreach (JObject obj in rawData["rules"])
                {
                    LeagueRuleSet ruleSet = new LeagueRuleSet(obj);
                    Rules.Add(ruleSet);
                }
            }
        }

        /// <summary>
        ///     The Name of the League
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The League Platform
        /// </summary>
        public string Platform { get; internal set; }

        /// <summary>
        ///     The League Description
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        ///     The Leagues Registered Date
        /// </summary>
        public string RegisteredDate { get; internal set; }

        /// <summary>
        ///     The League URL
        /// </summary>
        public string URL { get; internal set; }

        /// <summary>
        ///     The Leagues Start Date
        /// </summary>
        public string StartDate { get; internal set; }


        /// <summary>
        ///     The Leagues End Date
        /// </summary>
        public string EndDate { get; internal set; }

        /// <summary>
        ///     The Leagues Delve Activation Status
        /// </summary>
        public bool DelveActive { get; internal set; }

        /// <summary>
        ///     The League Rules
        /// </summary>
        public List<LeagueRuleSet> Rules { get; internal set; }
    }
}