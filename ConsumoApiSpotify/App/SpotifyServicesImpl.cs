using ConsumoApiSpotify.Dao;
using ConsumoApiSpotify.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsumoApiSpotify.App
{
    public class SpotifyServicesImpl
    {
        private SpotifyServices? spotifyServices = new();

        public List<Item> GetAllArtistByName(string artistaName)
        {
            var result = spotifyServices.SearchForItem(artistaName);

            var listaArtitas = (from art in result.artists.items select art).ToList();

            var popular = listaArtitas.OrderByDescending((art) => art.popularity);
            var seguidores = listaArtitas.OrderByDescending((follow) => follow.followers.total);
            return listaArtitas;
        }
    }
}
