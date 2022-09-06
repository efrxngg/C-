using ConsumoApiSpotify.Dao;
using ConsumoApiSpotify.Entitys;
using System;
using System.Collections;
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

        //<summary>
        //Obtiene la lista de artistas por Nombre
        //</summary>
        public List<Item> GetAllArtistByName(string artistaName)
        {
            var result = spotifyServices.SearchForItem(artistaName);
            var listaArtitas = (from art in result.artists.items select art).ToList();
            return listaArtitas;
        }
        //<summary>
        //Obtiene la lista de artistas populares por Nombre
        //</summary>
        public List<Item> GetAllArtitstByNamePopular(string artistaName)
        {
            return GetAllArtistByName(artistaName).OrderByDescending((art) => art.popularity).ToList(); ;
        }

        //<summary>
        //Obtiene la lista de artistas por seguidores por Nombre
        //</summary>
        public List<Item> GetAllArtitstByNameFollows(string artistaName)
        {
            return GetAllArtistByName(artistaName).OrderByDescending((follow) => follow.followers.total).ToList();
        }

    }
}
