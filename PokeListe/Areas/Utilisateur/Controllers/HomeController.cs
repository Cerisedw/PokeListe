using PokeListe.DAL.Repositories;
using PokeListe.Entities.Infra;
using PokeListe.Models.Models;
using PokeListe.Session;
using PokeListe.Tools;
using PokeListe.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeListe.Areas.Utilisateur.Controllers
{
    public class HomeController : Controller
    {
        public string cnString = dbConnect.DbString;

        // GET: Utilisateur/Home
        public ActionResult Index()
        {
            PokemonRepository pr = new PokemonRepository(cnString);
            List<PokemonView> pokemonList = PokemonTools.ListPokeToListPokeView(pr.getAllFromUser(SessionUtils.ConnectedUser.IdUtilisateur));
            return View(pokemonList);
        }

        public ActionResult AllList()
        {
            UtilisateurPokemonRepository upr = new UtilisateurPokemonRepository(cnString);
            PokemonRepository pr = new PokemonRepository(cnString);
            TypePokeRepository tpr = new TypePokeRepository(cnString);
            SessionUtils.listTypes = TypeTools.ListTypeToListTypeSimple(tpr.GetAll());
            List<PokemonView> listePoke = PokemonTools.ListPokeToListPokeView(pr.GetAll());
            SessionUtils.ConnectedUser.ListePoke = upr.GetAllFromUser(SessionUtils.ConnectedUser.IdUtilisateur).Select(m => m.IdPokemon).ToList();
            return View(listePoke);
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(UtilisateurView u, HttpPostedFileBase file)
        {
            UtilisateurRepository ur = new UtilisateurRepository(cnString);
            u.IdUtilisateur = SessionUtils.ConnectedUser.IdUtilisateur;
            if (file != null)
            {
                string[] dir = Directory.GetFiles(HttpContext.Server.MapPath("/Content/img/Utilisateurs"), file.FileName);
                if (dir.Count() > 0)
                {
                    foreach (string imgPath in dir)
                    {
                        System.IO.File.Delete(imgPath);
                    }
                }
                u.Img = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("/Content/Img/Utilisateurs/"), file.FileName));
                } catch (Exception)
                {
                    ViewBag.ErrorMessage = "L'image n'a pas pu être sauvée";
                    throw;
                }
            }else
            {
                u.Img = SessionUtils.ConnectedUser.Img;
            }
            if (ur.Update(UtilisateurTools.UtilisateurViewToUtilisateur(u)))
            {
                SessionUtils.ConnectedUser = UtilisateurTools.UtilisateurViewToSimple(u);
                return RedirectToAction("Index", new { controller = "Home", area = "Utilisateur" });
            }
            else
            {
                ViewBag.ErrorMessage = "Probleme lors de l'insertion.";
                return View();
            }
        }

        [HttpPost]
        public string AddPoke(int id)
        {
            UtilisateurPokemonRepository upr = new UtilisateurPokemonRepository(cnString);
            int idUt = SessionUtils.ConnectedUser.IdUtilisateur;
            if (upr.Insert(UtilisateurPokemonTools.CompositeToUtilisateurPoke(idUt, id)) == null)
            {
                return "K O";
            }
            return "O K";
        }

        // retour en string qui retourne Ko ou Ok pour savoir si on peut changer la couleur du bouton ou pas en JS
        [HttpPost]
        public string DelPoke(int id)
        {
            UtilisateurPokemonRepository upr = new UtilisateurPokemonRepository(cnString);
            int idUt = SessionUtils.ConnectedUser.IdUtilisateur;
            if(!upr.DelFromUser(new CompositeKey<int, int>() { PK1 = idUt, PK2 = id }))
            {
                return "KO";
            }
            return "OK";
        }


        public ActionResult FilterByType(int id)
        {
            PokemonRepository pr = new PokemonRepository(cnString);
            List<PokemonView> listePoke = PokemonTools.ListPokeToListPokeView(pr.getAllFromType(id));
            return View("AllList", listePoke);
        }
    }
}