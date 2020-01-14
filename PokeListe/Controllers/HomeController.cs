using PokeListe.DAL.Repositories;
using PokeListe.Models;
using PokeListe.Models.Models;
using PokeListe.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeListe.Controllers
{
    public class HomeController : Controller
    {
        public string cnString = @"Data Source=WAD-1\ADMINSQL;Initial Catalog=PokeList;User ID=aspuser;Password=test1234=;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ActionResult Index()
        {
            PokemonRepository pr = new PokemonRepository(cnString);
            List<PokemonView> listePoke = PokemonTools.ListPokeToListPokeView(pr.GetAll());
            return View(listePoke);
        }
        public ActionResult Get(int id)
        {
            ViewBag.Message = "Your application description page.";
            PokemonRepository pr = new PokemonRepository(cnString);
            // Pour le test, c'est un id fixe
            PokemonView poke = PokemonTools.PokeToPokeView(pr.Get(id));
            return View(poke);
        }
    }
}