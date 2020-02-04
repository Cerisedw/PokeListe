using PokeListe.DAL.Repositories;
using PokeListe.Entities.Models;
using PokeListe.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Tools.Mappers
{
    public static class LocalisationPokemonTools
    {

        public static LocalisationPokemonView LPToLPView(LocalisationPokemon lp)
        {
            return new LocalisationPokemonView()
            {
                IdLocalisationPokemonView = lp.id,
                IdLocalisation = lp.IdLocalisation,
                IdPokemon = lp.IdPokemon,
                TauxApp = lp.TauxApp,
                Lieu = lp.Lieu,
            };
        }

        public static List<LocalisationPokemonView> listeLPToListLPView(IEnumerable<LocalisationPokemon> listeLp)
        {
            List<LocalisationPokemonView> listeLpView = new List<LocalisationPokemonView>();
            foreach(LocalisationPokemon lp in listeLp)
            {
                listeLpView.Add(LPToLPView(lp));
            }
            return listeLpView;
        }


        public static List<LocalisationPokemonView> ListLPViewWithIdLoc(int idLoc)
        {
            LocalisationPokemonRepository lpr = new LocalisationPokemonRepository(dbConnect.DbString);
            List<LocalisationPokemonView> listeLPV = listeLPToListLPView(lpr.GetAllFromLoc(idLoc));
            return listeLPV;
        }

    }
}
