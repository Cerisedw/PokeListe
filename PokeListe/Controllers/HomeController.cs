using PokeListe.DAL.Repositories;
using PokeListe.Models;
using PokeListe.Models.Models;
using PokeListe.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeListe.Controllers
{
    public class HomeController : Controller
    {
        public string cnString = ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString;
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
            PokemonView poke = PokemonTools.PokeToPokeView(pr.Get(id));
            return View(poke);
        }
        public ActionResult AllTypes()
        {
            TypePokeRepository tr = new TypePokeRepository(cnString);
            List<TypeView> listeTypes = TypeTools.ListTypeToListTypeView(tr.GetAll());
            return View(listeTypes);
        }
        public ActionResult GetType(int id)
        {
            TypePokeRepository tr = new TypePokeRepository(cnString);
            TypeView type = TypeTools.TypeToTypeView(tr.Get(id));
            return View(type);
        }
    }
}