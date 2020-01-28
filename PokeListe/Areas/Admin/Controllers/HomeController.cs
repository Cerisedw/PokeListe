using PokeListe.DAL.Repositories;
using PokeListe.Models.Models;
using PokeListe.Session;
using PokeListe.Tools;
using PokeListe.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeListe.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        public string cnString = dbConnect.DbString;

        // GET: Admin/Home
        [HttpGet]
        public ActionResult Index()
        {
            TypePokeRepository tpr = new TypePokeRepository(cnString);
            SessionUtils.listTypes = TypeTools.ListTypeToListTypeSimple(tpr.GetAll());
            return View();
        }
        [HttpPost]
        public ActionResult Index(AddPokemon ap, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string[] dir = Directory.GetFiles(HttpContext.Server.MapPath("/Content/Img/pokedex"), file.FileName);
                if (dir.Count() > 0)
                {
                    foreach (string imgPath in dir)
                    {
                        System.IO.File.Delete(imgPath);
                    }
                }

                ap.Img = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("/Content/Img/pokedex/"), file.FileName));
                }
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "L'image n'a pas pu être sauvée";
                    throw;
                }
                PokemonRepository pr = new PokemonRepository(cnString);
                int id = pr.insertPokemon(PokemonTools.AddPokeToAjoutPoke(ap));
                ViewBag.insertMessage = (id == 0) ? "Erreur lors de l'insertion" : "Insertion réussie";
            }
            TypePokeRepository tpr = new TypePokeRepository(cnString);
            SessionUtils.listTypes = TypeTools.ListTypeToListTypeSimple(tpr.GetAll());
            return View();
        }


    }
}