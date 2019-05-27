using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ExileNET.API.Items
{
    public class Item
    {
        public Item(JObject rawData)
        {
            if (rawData["verified"] != null)
                Verified = bool.Parse(rawData["verified"].ToString());
            if (rawData["w"] != null)
                Width = int.Parse(rawData["w"].ToString());
            if (rawData["h"] != null)
                Height = int.Parse(rawData["h"].ToString());
            if (rawData["ilvl"] != null)
                iLevel = int.Parse(rawData["ilvl"].ToString());
            if (rawData["icon"] != null)
                IconPath = rawData["icon"].ToString();
            if (rawData["support"] != null)
                Support = bool.Parse(rawData["support"].ToString());
            if (rawData["league"] != null)
                League = rawData["league"].ToString();
            if (rawData["sockets"] != null && rawData["sockets"].HasValues)
            {
                Sockets = new List<Socket>();
                foreach (JObject obj in rawData["sockets"])
                {
                    Socket socket = new Socket(obj);
                    Sockets.Add(socket);
                }
            }

            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["id"] != null)
                Id = rawData["id"].ToString();
            if (rawData["typeLine"] != null)
                Type = rawData["typeLine"].ToString();
            if (rawData["identified"] != null)
                Indentified = bool.Parse(rawData["identified"].ToString());
            if (rawData["corrupted"] != null)
                Corrupted = bool.Parse(rawData["corrupted"].ToString());
            if (rawData["properties"] != null && rawData["properties"].HasValues)
            {
                Properties = new List<ItemProperty>();
                foreach (JObject obj in rawData["properties"])
                {
                    ItemProperty property = new ItemProperty(obj);
                    Properties.Add(property);
                }
            }

            if (rawData["additionalProperties"] != null && rawData["additionalProperties"].HasValues)
            {
                AdditionalProperties = new List<ItemProperty>();
                foreach (JObject obj in rawData["additionalProperties"])
                {
                    ItemProperty property = new ItemProperty(obj);
                    AdditionalProperties.Add(property);
                }
            }

            if (rawData["requirements"] != null && rawData["requirements"].HasValues)
            {
                Requirements = new List<ItemRequirement>();
                foreach (JObject obj in rawData["requirements"])
                {
                    ItemRequirement requirement = new ItemRequirement(obj);
                    Requirements.Add(requirement);
                }
            }

            if (rawData["nextLevelRequirements"] != null && rawData["nextLevelRequirements"].HasValues)
            {
                NextLevelRequirements = new List<ItemRequirement>();
                foreach (JObject obj in rawData["nextLevelRequirements"])
                {
                    ItemRequirement requirement = new ItemRequirement(obj);
                    NextLevelRequirements.Add(requirement);
                }
            }

            if (rawData["talismanTier"] != null)
                TalismanTier = int.Parse(rawData["talismanTier"].ToString());
            if (rawData["descrText"] != null)
                DescriptionText = rawData["descrText"].ToString();
            if (rawData["secDescrText"] != null)
                SecondaryDescriptionText = rawData["secDescrText"].ToString();
            if (rawData["explicitMods"] != null && rawData["explicitMods"].HasValues)
            {
                ExplicitMods = new List<string>();
                foreach (string mod in rawData["explicitMods"]) ExplicitMods.Add(mod);
            }

            if (rawData["implicitMods"] != null && rawData["implicitMods"].HasValues)
            {
                ImplicitMods = new List<string>();
                foreach (string mod in rawData["implicitMods"]) ImplicitMods.Add(mod);
            }

            if (rawData["craftedMods"] != null && rawData["craftedMods"].HasValues)
            {
                CraftedMods = new List<string>();
                foreach (string mod in rawData["craftedMods"]) CraftedMods.Add(mod);
            }

            if (rawData["frameType"] != null)
                FrameType = int.Parse(rawData["frameType"].ToString());
            if (rawData["inventoryId"] != null)
                InventoryId = rawData["inventoryId"].ToString();
            if (rawData["x"] != null)
                X = int.Parse(rawData["x"].ToString());
            if (rawData["y"] != null)
                Y = int.Parse(rawData["y"].ToString());
            if (rawData["vaal"] != null)
                Vaal = new Vaal(JObject.Parse(rawData["vaal"].ToString()));
            if (rawData["socketedItems"] != null && rawData["socketedItems"].HasValues)
            {
                SocketedItems = new List<Item>();
                foreach (JObject obj in rawData["socketedItems"])
                {
                    Item item = new Item(obj);
                    SocketedItems.Add(item);
                }
            }

            if (rawData["flavourText"] != null && rawData["flavourText"].HasValues)
            {
                FlavourText = new List<string>();
                foreach (string text in rawData["flavourText"]) FlavourText.Add(text);
            }
        }

        public bool Verified { get; internal set; }

        /// <summary>
        ///     The Items Inventory Grid Width
        /// </summary>
        public int Width { get; internal set; }

        /// <summary>
        ///     The Items Inventory Grid Height
        /// </summary>
        public int Height { get; internal set; }

        /// <summary>
        ///     The Item Level
        /// </summary>
        public int iLevel { get; internal set; }

        /// <summary>
        ///     The Items Icon Path
        /// </summary>
        public string IconPath { get; internal set; }


        /// <summary>
        ///     Is the Gem Support?
        /// </summary>
        public bool Support { get; internal set; }

        /// <summary>
        ///     The Items League
        /// </summary>
        public string League { get; internal set; }

        /// <summary>
        ///     The Sockets on the Item
        /// </summary>
        public List<Socket> Sockets { get; internal set; }

        /// <summary>
        ///     The Items Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The Item ID
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     The Item Type
        /// </summary>
        public string Type { get; internal set; }


        /// <summary>
        ///     The Items Identification Status
        /// </summary>
        public bool Indentified { get; internal set; }

        /// <summary>
        ///     The Items Corruption Status
        /// </summary>
        public bool Corrupted { get; internal set; }

        /// <summary>
        ///     The Items Properties
        /// </summary>
        public List<ItemProperty> Properties { get; internal set; }

        /// <summary>
        ///     The Items Additional Properties
        /// </summary>
        public List<ItemProperty> AdditionalProperties { get; internal set; }

        /// <summary>
        ///     The Items Requirements
        /// </summary>
        public List<ItemRequirement> Requirements { get; internal set; }

        /// <summary>
        ///     The Talisman Tier
        /// </summary>
        public int TalismanTier { get; internal set; }

        /// <summary>
        ///     The Items Next Level Requirements
        /// </summary>
        public List<ItemRequirement> NextLevelRequirements { get; internal set; }

        /// <summary>
        ///     The Items Description Text
        /// </summary>
        public string DescriptionText { get; internal set; }

        /// <summary>
        ///     The Items Secondary Description
        /// </summary>
        public string SecondaryDescriptionText { get; internal set; }

        /// <summary>
        ///     The Items Flavour Text
        /// </summary>
        public List<string> FlavourText { get; internal set; }

        /// <summary>
        ///     The Items Implicit Modifications
        /// </summary>
        public List<string> ImplicitMods { get; internal set; }

        /// <summary>
        ///     The Items Explicit Modifications
        /// </summary>
        public List<string> ExplicitMods { get; internal set; }

        /// <summary>
        ///     The Items Crafted Modifications
        /// </summary>
        public List<string> CraftedMods { get; internal set; }

        /// <summary>
        ///     The Items Frame Type
        /// </summary>
        public int FrameType { get; internal set; }

        /// <summary>
        ///     The Items Inventory ID
        /// </summary>
        public string InventoryId { get; internal set; }

        /// <summary>
        ///     The Stash X Start Co-ordinate
        /// </summary>
        public int X { get; internal set; }

        /// <summary>
        ///     The Stash Y Start Co-ordinate
        /// </summary>
        public int Y { get; internal set; }

        /// <summary>
        ///     The Items Vaal Properties
        /// </summary>
        public Vaal Vaal { get; internal set; }

        /// <summary>
        ///     The Gems Socketed into this Item
        /// </summary>
        public List<Item> SocketedItems { get; internal set; }
    }
}