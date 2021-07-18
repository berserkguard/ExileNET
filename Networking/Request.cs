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
                HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "GET";
                webRequest.UserAgent = User_Agent;

                HttpWebResponse webResponse = (HttpWebResponse) await webRequest.GetResponseAsync();

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
                HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "GET";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";
                webRequest.AllowAutoRedirect = false;

                if (collection != null)
                {
                    for (int i = 0; i < collection.Count; i++)
                    {
                        if (collection.Keys[i].Equals("POESESSID"))
                        {
                            webRequest.CookieContainer = new CookieContainer();
                            webRequest.CookieContainer.Add(new Cookie(collection.Keys[i], collection.Get(i))
                            {
                                Domain = new Uri(url).Host
                            });
                        }
                        else
                        {
                            webRequest.Headers.Add(collection.Keys[i], collection.Get(i));
                        }
                    }
                }

                HttpWebResponse webResponse = (HttpWebResponse) await webRequest.GetResponseAsync();
                WebHeaderCollection Headers = webResponse.Headers;
                ResponseStream = webResponse.GetResponseStream();

                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string response = await reader.ReadToEndAsync();

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
                HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";

                if (collection != null)
                {
                    for (int i = 0; i < collection.Count; i++)
                    {
                        if (collection.Keys[i].Equals("POESESSID"))
                        {
                            webRequest.CookieContainer.Add(new Cookie(collection.Keys[i], collection.Get(i)));
                        }
                        else
                        {
                            webRequest.Headers.Add(collection.Keys[i], collection.Get(i));
                        }
                    }
                }

                string post = JsonConvert.SerializeObject(data);

                using (StreamWriter writer = new StreamWriter(webRequest.GetRequestStream()))
                {
                    await writer.WriteAsync(post);
                    await writer.FlushAsync();
                    writer.Close();
                }

                HttpWebResponse webResponse = (HttpWebResponse) await webRequest.GetResponseAsync();
                WebHeaderCollection header = webResponse.Headers;
                ResponseStream = webResponse.GetResponseStream();

                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string response = await reader.ReadToEndAsync();
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