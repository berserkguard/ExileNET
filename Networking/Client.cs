using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ExileNET.API;

namespace ExileNET.Networking
{
    public class Client
    {
        /// <summary>
        ///     The Client User Agent
        /// </summary>
        private const string UserAgent = "";

        /// <summary>
        ///     The Path of Exile API Url
        /// </summary>
        private const string ApiUrl = "http://api.pathofexile.com/";

        /// <summary>
        ///     Gets the Client Connection Status
        /// </summary>
        public bool IsConnected;

        public Client()
        {
            Api = new ExileAPI(UserAgent, ApiUrl);

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

        /// <summary>
        /// Verifies the Connection to the Path of Exile API
        /// </summary>
        /// <returns></returns>
        public async Task VerifyConnectionAsync()
        {
            var request = new Request(UserAgent);

            var urlToTest = $"{ApiUrl}leagues";

            var status = await request.GetStatusAsync(urlToTest);

            if (status.ToString().StartsWith("2"))
            {
                var e = new ConnectedEventArgs
                {
                    Status = status,
                    URL = urlToTest
                };

                IsConnected = true;

                OnConnected(e);
            }
        }
    }
}