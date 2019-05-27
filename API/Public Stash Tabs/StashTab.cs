using System;
using System.Collections.Generic;
using ExileNET.API.Items;
using Newtonsoft.Json.Linq;

namespace ExileNET.API.PublicStashTabs
{
    public class StashTab
    {
        public StashTab(JObject rawData)
        {
            if (rawData["id"] != null)
                Id = rawData["id"].ToString();
            if (rawData["public"] != null)
                Public = bool.Parse(rawData["public"].ToString());
            if (rawData["accountName"] != null)
                AccountName = rawData["accountName"].ToString();
            if (rawData["lastCharacterName"] != null)
                LastCharacterName = rawData["lastCharacterName"].ToString();
            if (rawData["Stash Tab"] != null)
                StashName = rawData["Stash Tab"].ToString();
            if (rawData["stashType"] != null)
                StashType = (StashType) Enum.Parse(typeof(StashType),rawData["stashType"].ToString());
            
            if (rawData["league"] != null)
                League = rawData["league"].ToString();
            if (rawData["items"] != null && rawData["items"].HasValues)
            {
                Items = new List<Item>();
                foreach (JObject obj in rawData["items"])
                {
                    Item item = new Item(obj);
                    Items.Add(item);
                }
            }
        }

        /// <summary>
        ///     The Stash Tab ID
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     Is the Stash Tab Public?
        /// </summary>
        public bool Public { get; internal set; }

        /// <summary>
        ///     Account Name who the Stash Tab belongs to.
        /// </summary>
        public string AccountName { get; internal set; }

        /// <summary>
        ///     Last Character on Account
        /// </summary>
        public string LastCharacterName { get; internal set; }

        /// <summary>
        ///     Stash Tab Name (if Applicable)
        /// </summary>
        public string StashName { get; internal set; }

        /// <summary>
        ///     Premium or Normal Stash Tab Type
        /// </summary>
        public StashType StashType { get; internal set; }

        /// <summary>
        ///     League the Stash Tab belong to.
        /// </summary>
        public string League { get; internal set; }

        /// <summary>
        ///     Items in the Stash Tab
        /// </summary>
        public List<Item> Items { get; internal set; }
    }
}