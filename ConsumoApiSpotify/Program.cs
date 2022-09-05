using ConsumoApiSpotify.App;
using ConsumoApiSpotify.Utils;
using static System.Console;


class Program
{
    static void  Main(string[] args)
    {
        var api = new SpotifyServicesImpl();
        api.GetAllArtistByName("eminem");

        var test = new Printer();
        test.DrawHeadAndBody("TEST", new List<Object> {"Efren", "Galarza"});
        

    }

}

