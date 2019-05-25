using Newtonsoft.Json.Linq;

namespace ExileNET.API.Accounts
{
    public class Account
    {
        public Account(JObject rawData)
        {
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["realm"] != null)
                Platform = rawData["realm"].ToString();
            if (rawData["challenges"] != null)
                Challenges = new Challenge(JObject.Parse(rawData["challenges"].ToString()));
            if (rawData["twitch"] != null)
                Twitch = new Twitch(JObject.Parse(rawData["twitch"].ToString()));
        }

        /// <summary>
        ///     The Account Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The Account Platform
        /// </summary>
        public string Platform { get; internal set; }

        /// <summary>
        ///     The Accounts Challenges
        /// </summary>
        public Challenge Challenges { get; internal set; }

        /// <summary>
        ///     The Associated Twitch Account Information
        /// </summary>
        public Twitch Twitch { get; internal set; }
    }
}