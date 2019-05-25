using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ExileNET.PVP
{
    public class Season
    {
        /// <summary>
        /// The Season ID
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The Platform
        /// </summary>
        public string Platform { get; internal set; }

        /// <summary>
        /// The Season Start Date
        /// </summary>
        public string StartDate { get; internal set; }

        /// <summary>
        /// The Season End Date
        /// </summary>
        public string EndDate { get; internal set; }

        /// <summary>
        /// The Season URL
        /// </summary>
        public string Url { get; internal set; }

        /// <summary>
        /// The Seasons Description
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// The Glicko Rating Active Status
        /// </summary>
        public bool GlickoRatings { get; internal set; }

        /// <summary>
        /// The PvP Status
        /// </summary>
        public bool PvP { get; internal set; }

        /// <summary>
        /// The Season Style
        /// </summary>
        public string Style { get; internal set; }

        /// <summary>
        /// The Season Register Date
        /// </summary>
        public string RegisterDate { get; internal set; }

        public Season(JObject rawData)
        {
            if (rawData["id"] != null)
                Id = rawData["id"].ToString();
            if (rawData["realm"] != null)
                Platform = rawData["realm"].ToString();
            if (rawData["startAt"] != null)
                StartDate = rawData["startAt"].ToString();
            if (rawData["endAt"] != null)
                EndDate = rawData["endAt"].ToString();
            if (rawData["url"] != null)
                Url = rawData["url"].ToString();
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if (rawData["glickoRatings"] != null)
                GlickoRatings = bool.Parse(rawData["glickoRatings"].ToString());
            if (rawData["pvp"] != null)
                PvP = bool.Parse(rawData["pvp"].ToString());
            if (rawData["style"] != null)
                Style = rawData["style"].ToString();
            if (rawData["registerAt"] != null)
                RegisterDate = rawData["registerAt"].ToString();
        }

    }
}
