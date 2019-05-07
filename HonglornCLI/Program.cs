using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
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