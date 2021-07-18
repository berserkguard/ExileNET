using System.Collections.Generic;
using System.Threading.Tasks;
using ExileNET.API.PublicStashTabs;
using ExileNET.Enums;
using ExileNET.Ladders;
using ExileNET.Leagues;
using ExileNET.Networking;
using ExileNET.PVP;
using Newtonsoft.Json.Linq;

namespace ExileNET.API
{
    public class ExileAPI
    {
        private readonly string Api_Url;
        private readonly string User_Agent;

        public ExileAPI(string user_agent, string api_url)
        {
            User_Agent = user_agent;
            Api_Url = api_url;
        }

        /// <summary>
        ///     Retrieves the Public Stashes, allows for optional next change id.
        /// </summary>
        /// <param name="nextChangeId">Optional Next Change ID</param>
        /// <returns></returns>
        public async Task<Stash> GetPublicStashesAsync(string nextChangeId = null)
        {
            var request = new Request(User_Agent);
            if (nextChangeId == null)
                await request.Get($"{Api_Url}public-stash-tabs/");
            else
                await request.Get($"{Api_Url}public-stash-tabs/?id={nextChangeId}");

            return new Stash(JObject.Parse(request.Response));
        }

        /// <summary>
        ///     Retrieves the specified account's stash tab for the given index (within the character's league).
        /// </summary>
        /// <returns></returns>
        public async Task<StashTab> GetAccountStashTabAsync(string poesessid, string accountName, string realm, string league, int tabIdx, bool includeTabs = false)
        {
            var request = new Request(User_Agent);

            var headers = new System.Net.WebHeaderCollection();
            headers.Add("POESESSID", poesessid);

            string tabs = (includeTabs ? "1" : "0");
            var endpoint = $"{Api_Url}character-window/get-stash-items?accountName={accountName}&realm={realm}&league={league}&tabIndex={tabIdx}&tabs={tabs}";

            await request.Get(endpoint, headers);

            return new StashTab(JObject.Parse(request.Response));
        }

        /// <summary>
        ///     Retrieves a List of All Leagues on the Desired Platform (Default PC)
        /// </summary>
        /// <param name="platform">The Desired Platform</param>
        /// <returns></returns>
        public async Task<List<League>> GetAllLeaguesAsync(Platform platform = Platform.Pc)
        {
            var request = new Request(User_Agent);

            string realm = platform.ToString().ToLower();

            await request.Get($"{Api_Url}leagues?realm={realm}");

            List<League> leagues = new List<League>();

            foreach (JObject obj in JArray.Parse(request.Response))
            {
                League league = new League(obj);
                leagues.Add(league);
            }

            return leagues;
        }

        /// <summary>
        ///     Retrieves a List of all Leagues associated with the given Season.
        /// </summary>
        /// <param name="season">The Chosen Season</param>
        /// <param name="platform">The Desired Platform</param>
        /// <returns></returns>
        public async Task<List<League>> GetLeaguesBySeasonAsync(string season, Platform platform = Platform.Pc)
        {
            var request = new Request(User_Agent);

            string realm = platform.ToString().ToLower();

            await request.Get($"{Api_Url}leagues?realm={realm}&type=season&season={season}");

            List<League> leagues = new List<League>();

            foreach (JObject obj in JArray.Parse(request.Response))
            {
                League league = new League(obj);
                leagues.Add(league);
            }

            return leagues;
        }

        /// <summary>
        ///     Retrieves a List of all Event Leagues on the given Platform. (Default PC)
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public async Task<List<League>> GetEventLeaguesAsync(Platform platform = Platform.Pc)
        {
            var request = new Request(User_Agent);

            string realm = platform.ToString().ToLower();

            await request.Get($"{Api_Url}leagues?realm={realm}&type=event");

            List<League> leagues = new List<League>();

            foreach (JObject obj in JArray.Parse(request.Response))
            {
                League league = new League(obj);
                leagues.Add(league);
            }

            return leagues;
        }

        /// <summary>
        ///     Retrieves a Current League by the given ID.
        /// </summary>
        /// <param name="leagueId">The League ID</param>
        /// <param name="platform">The Desired Platform</param>
        /// <returns></returns>
        public async Task<League> GetLeagueByIdAsync(string leagueId, Platform platform = Platform.Pc)
        {
            var request = new Request(User_Agent);

            string realm = platform.ToString().ToLower();

            await request.Get($"{Api_Url}leagues/{leagueId}?realm={realm}");

            return new League(JObject.Parse(request.Response));
        }


        /// <summary>
        ///     Retrieves a List of All League Rule Sets.
        /// </summary>
        /// <returns></returns>
        public async Task<List<LeagueRuleSet>> GetAllLeagueRuleSetsAsync()
        {
            var request = new Request(User_Agent);

            await request.Get($"{Api_Url}league-rules");

            List<LeagueRuleSet> ruleSets = new List<LeagueRuleSet>();

            foreach (JObject obj in JArray.Parse(request.Response))
            {
                LeagueRuleSet ruleSet = new LeagueRuleSet(obj);
                ruleSets.Add(ruleSet);
            }

            return ruleSets;
        }

        /// <summary>
        ///     Retrieves the Specified League Rule Set
        /// </summary>
        /// <param name="ruleSetId">The League Rule Set ID</param>
        /// <returns></returns>
        public async Task<LeagueRuleSet> GetLeagueRuleSetByIdAsync(string ruleSetId)
        {
            var request = new Request(User_Agent);

            await request.Get($"{Api_Url}league-rules/{ruleSetId}");

            return new LeagueRuleSet(JObject.Parse(request.Response));
        }

        /// <summary>
        ///     Retrieves the Specified Ladder
        /// </summary>
        /// <param name="ladderId">The Ladder ID (Name)</param>
        /// <param name="platform">The Desired Platform</param>
        /// <returns></returns>
        public async Task<Ladder> GetLadderByIdAsync(string ladderId, Platform platform = Platform.Pc)
        {
            var request = new Request(User_Agent);
            string realm = platform.ToString().ToLower();

            await request.Get($"{Api_Url}ladders/{ladderId}?realm={realm}");

            return new Ladder(JObject.Parse(request.Response));
        }

        /// <summary>
        /// Retrieves the PvP Season by ID
        /// </summary>
        /// <param name="seasonId">The Season ID</param>
        /// <param name="platform">The Desired Platform</param>
        /// <returns></returns>
        public async Task<List<Season>> GetPvPSeasonById(string seasonId, Platform platform = Platform.Pc)
        {
            var request = new Request(User_Agent);
            string realm = platform.ToString().ToLower();

            await request.Get($"{Api_Url}pvp-matches?type=season&season={seasonId}&realm={realm}");

            List<Season> seasonList = new List<Season>();

            foreach (JObject obj in JArray.Parse(request.Response))
            {
                Season season = new Season(obj);
                seasonList.Add(season);
            }

            return seasonList;
        }
    }
}