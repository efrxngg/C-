using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsumoApiSpotify.Entitys;
using Newtonsoft.Json;
using RestSharp;
using static System.Console;

namespace ConsumoApiSpotify.Dao
{
    public class Rest
    {
        private Rest() { }
        private static Rest _instance;
        public static Rest GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Rest();
            }
            return _instance;
        }

        #region Crendenciales
        private const string CLIENTE_ID = "6991557a70ff4fef80417efdacd770bb";
        private const string CLIENTE_SECRET = "b2ed10dbad94493a96939d3ae8058744";
        #endregion

        #region Metodos
        public async Task<Token> GetTokenAsync()
        {
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(CLIENTE_ID + ":" + CLIENTE_SECRET));

            var client = new RestClient("https://accounts.spotify.com");
            var request = new RestRequest("api/token");
            request.AddHeader("Authorization", $"Basic {auth}");
            request.AddHeader("Content-type", "application/x-www-form-urlencoded");
            request.AddBody("grant_type=client_credentials");
            var response = await client.ExecutePostAsync<Token>(request);

            return JsonConvert.DeserializeObject<Token>(response.Content);

        }
        #endregion
    }
}
