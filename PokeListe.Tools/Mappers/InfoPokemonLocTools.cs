using PokeListe.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Tools.Mappers
{
    public static class InfoPokemonLocTools
    {

        public static InfoPokemonLoc addLocToInfoPoke(InfoPokemonLoc ipl, LocalisationPokemonView lpv)
        {
            ipl.TauxApp = lpv.TauxApp;
            ipl.Lieu = lpv.Lieu;
            return ipl;
        }
        public static InfoPokemonLoc addPokeToInfoPoke(InfoPokemonLoc ipl, PokemonView pv)
        {
            ipl.IdPokemon = pv.IdPokemon;
            ipl.Nom = pv.Nom;
            ipl.Img = pv.Img;
            ipl.Types = TypeTools.TypeViewSimpleFromId(pv.IdPokemon);
            return ipl;
        }

        public static List<InfoPokemonLoc> ListPokeLocToListInfo()
        {
            List<InfoPokemonLoc> listeIPL = new List<InfoPokemonLoc>();
            return listeIPL;
        }

    }
}
