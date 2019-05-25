using System;
using ExileNET.API;

namespace ExileNET.Networking
{
    public class Client
    {
        /// <summary>
        ///     The Client User Agent
        /// </summary>
        private const string User_Agent = "";

        /// <summary>
        ///     The Path of Exile API Url
        /// </summary>
        private readonly string Api_Url = "http://api.pathofexile.com/";

        /// <summary>
        ///     Gets the Client Connection Status
        /// </summary>
        public bool IsConnected;

        public Client()
        {
            Api = new ExileAPI(User_Agent, Api_Url);
        }

        public ExileAPI Api { get; internal set; }

        /// <summary>
        ///     Raises the Connected Event
        /// </summary>
        protected event EventHandler<ConnectedEventArgs> Connected;

        /// <summary>
        ///     Overridable OnConnected Method. Raises Connection Event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnConnected(ConnectedEventArgs e)
        {
            Connected?.Invoke(this, e);
        }
    }
}