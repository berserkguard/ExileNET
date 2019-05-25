using Newtonsoft.Json.Linq;

namespace ExileNET.API.Accounts
{
    public class Twitch
    {
        public Twitch(JObject rawData)
        {
            if (rawData["name"] != null)
                AccountName = rawData["name"].ToString();
        }

        /// <summary>
        ///     The Associated Twitch Account Name
        /// </summary>
        public string AccountName { get; internal set; }
    }
}