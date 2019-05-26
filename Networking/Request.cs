using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExileNET.Networking
{
    public class Request
    {
        private readonly string User_Agent;

        public Request(string useragent)
        {
            User_Agent = useragent;
        }

        public int Status { get; internal set; }

        public string Response { get; internal set; }

        public WebHeaderCollection HeaderCollection { get; internal set; }

        public Stream ResponseStream { get; internal set; }

        public string URL { get; internal set; }

        public async Task<int> GetStatusAsync(string url)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "GET";
                webRequest.UserAgent = User_Agent;

                var webResponse = (HttpWebResponse) await webRequest.GetResponseAsync();

                return (int) webResponse.StatusCode;
            }
            catch (WebException e)
            {
                return (int) e.Status;
            }
            catch (Exception e)
            {
                return 503;
            }
        }

        /// <summary>
        ///     Gets a response from the URL
        /// </summary>
        /// <param name="url">The URL</param>
        /// <param name="collection">Optional Header Collection</param>
        /// <returns></returns>
        public async Task Get(string url, WebHeaderCollection collection = null)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(url);

                webRequest.Method = "GET";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";
                webRequest.AllowAutoRedirect = false;

                if (collection != null)
                    for (var i = 0; i < collection.Count; i++)
                        webRequest.Headers.Add(collection.Keys[i], collection.Get(i));

                var webResponse = (HttpWebResponse) await webRequest.GetResponseAsync();
                var Headers = webResponse.Headers;
                ResponseStream = webResponse.GetResponseStream();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var response = await reader.ReadToEndAsync();

                    Status = (int)webResponse.StatusCode;
                    Response = response;

                    HeaderCollection = Headers;
                }

               
            }
            catch (WebException e)
            {
                Status = (int) e.Status;
                Response = $"{new StreamReader(e.Response.GetResponseStream()).ReadToEnd()}";
            }
        }

        /// <summary>
        ///     Posts a Request to the URL
        /// </summary>
        /// <param name="url">The URL</param>
        /// <param name="data">The Data to POST</param>
        /// <param name="collection">Optional Header Collection</param>
        /// <returns></returns>
        public async Task Post(string url, IDictionary<string, string> data, WebHeaderCollection collection = null)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";

                if (collection != null)
                    for (var i = 0; i < collection.Count; i++)
                        webRequest.Headers.Add(collection.Keys[i], collection.Get(i));

                var post = JsonConvert.SerializeObject(data);

                using (var writer = new StreamWriter(webRequest.GetRequestStream()))
                {
                    await writer.WriteAsync(post);
                    await writer.FlushAsync();
                    writer.Close();
                }

                var webResponse = (HttpWebResponse) await webRequest.GetResponseAsync();
                var header = webResponse.Headers;
                ResponseStream = webResponse.GetResponseStream();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var response = await reader.ReadToEndAsync();
                    Response = response;
                    HeaderCollection = header;
                    URL = webResponse.ResponseUri.ToString();
                }

              
            }
            catch (WebException e)
            {
                Status = (int) e.Status;
                Response = $"{new StreamReader(e.Response.GetResponseStream()).ReadToEnd()}";
            }
        }
    }
}