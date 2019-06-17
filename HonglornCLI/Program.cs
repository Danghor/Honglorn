using System.Configuration;
using HonglornBL;

namespace HonglornCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var honglorn = new Honglorn(ConfigurationManager.ConnectionStrings["HonglornDb"]);

            var games = honglorn.GetGames();
        }
    }
}