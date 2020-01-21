using PokeListe.DAL.Repositories;
using PokeListe.Entities.Models;
using PokeListe.Models.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Tools.Mappers
{
    public static class UtilisateurTools
    {

        public static Utilisateur RegisterUtilisateurToUtilisateur(RegisterUtilisateur reUt)
        {
            return new Utilisateur()
            {
                Pseudo = reUt.Pseudo,
                Email = reUt.Email,
                Mdp = reUt.Mdp,
                Img = reUt.Img
            };
        }

        public static UtilisateurView RegisterToUtilisateurView(RegisterUtilisateur reUt)
        {
            return new UtilisateurView()
            {
                Pseudo = reUt.Pseudo,
                Email = reUt.Email,
                Mdp = reUt.Mdp,
                Img = reUt.Img
            };
        }

        public static UtilisateurView UtilisateurToUtilisateurView(Utilisateur util)
        {
            if (util == null) return null; 
            return new UtilisateurView()
            {
                IdUtilisateur = util.id,
                Pseudo = util.Pseudo,
                Email = util.Email,
                //Mdp = util.Mdp,
                Img = util.Img
            };
        }

        public static Utilisateur UtilisateurViewToUtilisateur(UtilisateurView utv)
        {
            return new Utilisateur()
            {
                IdUtilisateur = utv.IdUtilisateur,
                Pseudo = utv.Pseudo,
                Email = utv.Email,
                Mdp = utv.Mdp,
                Img = utv.Img
            };
        }

        public static UtilisateurViewSimple UtilisateurViewToSimple(UtilisateurView uv)
        {
            UtilisateurPokemonRepository upr = new UtilisateurPokemonRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            return new UtilisateurViewSimple()
            {
                IdUtilisateur = uv.IdUtilisateur,
                Pseudo = uv.Pseudo,
                Email = uv.Email,
                Img = uv.Img,
                ListePoke = upr.GetAllFromUser(uv.IdUtilisateur).Select(m => m.IdPokemon).ToList()
            };
        }

        public static Utilisateur LoginToUtilisateur(LoginUtilisateur loginU)
        {
            return new Utilisateur()
            {
                Email = loginU.Email,
                Mdp = loginU.Mdp
            };
        }
    }
}
