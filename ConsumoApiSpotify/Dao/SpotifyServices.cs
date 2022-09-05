using ConsumoApiSpotify.Entitys;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoApiSpotify.Dao
{
    public class SpotifyServices
    {
        #region Token
        private Token? Token;
        public SpotifyServices()
        {
            SeToken().Wait();
        }
        private async Task SeToken()
        {
            var service = Rest.GetInstance();
            Token = await service.GetTokenAsync();

        }
        #endregion
        private RestClient client = new RestClient("https://api.spotify.com/v1");

        public ResultSearch SearchForItem(string item)
        {
            var request = new RestRequest("/search");

            request.AddParameter("q", item);
            request.AddParameter("type", "artist");
            request.AddParameter("limit", 10);
            request.AddParameter("offset", 0);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {Token.access_token}");

            var response = client.ExecuteGet(request);
            var data = JsonConvert.DeserializeObject<ResultSearch>(response.Content);

            return data;
        }
    }
}
