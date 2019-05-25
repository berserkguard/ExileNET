using Newtonsoft.Json.Linq;

namespace ExileNET.API.Accounts
{
    public class Challenge
    {
        public Challenge(JObject rawData)
        {
            if (rawData["total"] != null)
                Total = int.Parse(rawData["total"].ToString());
        }

        /// <summary>
        ///     The Total Challenges Completed
        /// </summary>
        public int Total { get; internal set; }
    }
}