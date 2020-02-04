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
    public static class LocalisationTools
    {

        public static LocalisationView LocalisationToLocalisationView(Localisation loc)
        {
            return new LocalisationView()
            {
                IdLocalisation = loc.id,
                Nom = loc.Nom,
                Description = loc.Description,
                Img = loc.Img,
            };
        }
        public static LocalisationViewSimple LocalisationToLocalisationViewSimple(Localisation loc)
        {
            return new LocalisationViewSimple()
            {
                IdLocalisation = loc.id,
                Nom = loc.Nom,
                Img = loc.Img,
            };
        }

        public static List<LocalisationView> ListlocToListlocview(IEnumerable<Localisation> listeLoc)
        {
            List<LocalisationView> listeLocView = new List<LocalisationView>();
            foreach (Localisation loc in listeLoc)
            {
                listeLocView.Add(LocalisationToLocalisationView(loc));
            }
            return listeLocView;
        }
        public static List<LocalisationViewSimple> ListlocToListlocviewSimple(IEnumerable<Localisation> listeLoc)
        {
            List<LocalisationViewSimple> listeLocView = new List<LocalisationViewSimple>();
            foreach (Localisation loc in listeLoc)
            {
                listeLocView.Add(LocalisationToLocalisationViewSimple(loc));
            }
            return listeLocView;
        }

        public static LocalisationView AddListToLocView(LocalisationView locV)
        {
            List<PokemonView> listePokeV = PokemonTools.listFromLoc(locV.IdLocalisation);
            List<LocalisationPokemonView> listeLPV = LocalisationPokemonTools.ListLPViewWithIdLoc(locV.IdLocalisation);
            List<InfoPokemonLoc> listeIPL = new List<InfoPokemonLoc>();

            for (int i = 0; i < listePokeV.Count; i++)
            {
                InfoPokemonLoc ipl = new InfoPokemonLoc()
                {
                    IdPokemon = listePokeV[i].IdPokemon,
                    Nom = listePokeV[i].Nom,
                    Img = listePokeV[i].Img,
                    TauxApp = listeLPV[i].TauxApp,
                    Lieu = listeLPV[i].Lieu,
                    Types = TypeTools.TypeViewSimpleFromId(listePokeV[i].IdPokemon),

                };
                listeIPL.Add(ipl);
            }
            locV.listeInfoPokeLoc = listeIPL;
            return locV;
        }

        public static List<LocalisationViewSimple> ListeLVSFromIdPoke(int idPoke)
        {
            LocalisationRepository lr = new LocalisationRepository(dbConnect.DbString);
            List<LocalisationViewSimple> listelvs = ListlocToListlocviewSimple(lr.GetAllFromIdPoke(idPoke));
            return (listelvs == null) ? new List<LocalisationViewSimple>() : listelvs;
        }

    }
}
