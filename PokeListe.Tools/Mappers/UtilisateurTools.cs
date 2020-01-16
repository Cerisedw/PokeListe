using PokeListe.Entities.Models;
using PokeListe.Models.Models;
using System;
using System.Collections.Generic;
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

        public static UtilisateurView UtilisateurToUtilisateurView(Utilisateur util)
        {
            if (util == null) return null; 
            return new UtilisateurView()
            {
                IdUtilisateur = util.id,
                Pseudo = util.Pseudo,
                Email = util.Email,
                Mdp = util.Mdp,
                Img = util.Img
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
