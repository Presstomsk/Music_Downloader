using System.Net.Http;
using System;

namespace Music_Downloader.Services
{
    public class HTTP
    {

        public string Search(string artistName)
        {
            return GetData("https://youtube-music1.p.rapidapi.com/v2/search?query", artistName);
        }

        public string GetDownloadUrl(string id)
        {
            return GetData("https://youtube-music1.p.rapidapi.com/get_download_url?id", $"{id}&ext=mp3");
        }

        private string GetData(string uri, string artistName)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{uri}={artistName}"),
                Headers =
                    {
                        { "X-RapidAPI-Key", "0a81c7a01fmsh3d548f019ea092cp1c7bbajsn695ffc1d3e57" },
                        { "X-RapidAPI-Host", "youtube-music1.p.rapidapi.com" },
                    },
            };
            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync();
                return body.Result;
            }
        }
        
    }
}
