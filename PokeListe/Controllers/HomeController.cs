using PokeListe.DAL.Repositories;
using PokeListe.Models;
using PokeListe.Models.Models;
using PokeListe.Session;
using PokeListe.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUtilisateur loginUt)
        {
            UtilisateurRepository ur = new UtilisateurRepository(cnString);
            UtilisateurView utilisateurLog = UtilisateurTools.UtilisateurToUtilisateurView(ur.getByLogin(UtilisateurTools.LoginToUtilisateur(loginUt)));
            if(utilisateurLog != null)
            {
                SessionUtils.IsConnected = true;
                SessionUtils.ConnectedUser = utilisateurLog;
                //return RedirectToAction("", new { controller = "Home", area = "Utilisateur" });
                return RedirectToAction("Index", new { controller = "Home", area = "" });
            }
            else
            {
                ViewBag.ErrorLoginMessage = "Erreur Login/Mot de passe";
                return View("Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUtilisateur reUt, HttpPostedFileBase file)
        {
            if (file.ContentLength > 150000)
            {
                ViewBag.ErrorMessage = "Le fichier est trop lourd.";
                return View("Login");
            }

            if (!ModelState.IsValid)
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        ViewBag.ErrorMessage += error.ErrorMessage + "<br>";
                        return View("Login");
                    }
                }
            }
            else
            {
                reUt.Img = file.FileName;
                UtilisateurRepository ur = new UtilisateurRepository(cnString);
                UtilisateurView utView = UtilisateurTools.UtilisateurToUtilisateurView(ur.Insert(UtilisateurTools.RegisterUtilisateurToUtilisateur(reUt)));
                if (utView != null)
                {
                    if (file != null)
                    {
                        try
                        {
                            file.SaveAs(Path.Combine(HttpContext.Server.MapPath("/Content/Img/Utilisateurs/"), file.FileName));
                        }
                        catch (Exception)
                        {
                            ViewBag.ErrorMessage = "L'image n'a pas pu être sauvée";
                            // peut etre delete l'utilisateur ici ?
                            throw;
                        }
                        ViewBag.SuccessMessage = "Vous pouvez vous connecter";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Erreur lors de l'insertion";
                    }

                }
            }
            return View("Login");
        }

        public ActionResult LogOff()
        {
            SessionUtils.ConnectedUser = null;
            SessionUtils.IsConnected = false;

            return RedirectToAction("Index", new { controller = "Home", area = "" });
        }


    }
}