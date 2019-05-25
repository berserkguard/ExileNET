using Newtonsoft.Json.Linq;

namespace ExileNET.API.Items
{
    public class Socket
    {
        public Socket(JObject rawData)
        {
            if (rawData["group"] != null)
                Group = int.Parse(rawData["group"].ToString());
            if (rawData["attr"] != null)
                Attribute = ConvertToAttribute(rawData["attr"].ToString());
            if (rawData["sColour"] != null)
                Colour = ConvertToSocketColour(rawData["sColour"].ToString());
        }

        /// <summary>
        ///     The Socket Group Number
        /// </summary>
        public int Group { get; internal set; }

        /// <summary>
        ///     The Socket Attribute
        /// </summary>
        public Attribute Attribute { get; internal set; }

        /// <summary>
        ///     The Socket Colour
        /// </summary>
        public SocketColour Colour { get; internal set; }

        /// <summary>
        ///     Converts the Output of the Exile API to Attribute Enum
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static Attribute ConvertToAttribute(string text)
        {
            switch (text)
            {
                case "D":
                    return Attribute.Dexterity;
                case "S":
                    return Attribute.Strength;
                case "I":
                    return Attribute.Intelligence;
                default:
                    return Attribute.None;
            }
        }

        /// <summary>
        ///     Converts the Output of the Exile API to Socket Colour Enum.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static SocketColour ConvertToSocketColour(string text)
        {
            switch (text)
            {
                case "G":
                    return SocketColour.Green;
                case "B":
                    return SocketColour.Blue;
                case "R":
                    return SocketColour.Red;
                default:
                    return SocketColour.None;
            }
        }
    }

    public enum Attribute
    {
        None,
        Strength,
        Dexterity,
        Intelligence
    }

    public enum SocketColour
    {
        None,
        Green,
        Red,
        Blue
    }
}