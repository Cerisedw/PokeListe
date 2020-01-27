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
    public static class PokemonTools
    {
        public static PokemonView PokeToPokeView(Pokemon poke)
        {
            return new PokemonView()
            {
                IdPokemon = poke.IdPokemon,
                Nom = poke.Nom,
                Numero = poke.Numero,
                Description = poke.Description,
                Img = poke.Img,
                Obtention = poke.Obtention,
                IdStat = poke.IdStat,
                Stat = StatTools.AddStatToPokemonView(poke),
                Types = TypeTools.TypeViewSimpleFromPokemon(poke)
            };
        }

        public static PokemonViewBool PokeToPokeBool(Pokemon poke)
        {
            return new PokemonViewBool()
            {
                IdPokemon = poke.id,
                Nom = poke.Nom,
                Numero = poke.Numero,
                Img = poke.Img,
                Types = TypeTools.TypeViewSimpleFromPokemon(poke),
            };
        }

        public static List<PokemonView> ListPokeToListPokeView(IEnumerable<Pokemon> listePoke)
        {
            List<PokemonView> listePokeView = new List<PokemonView>();
            foreach (Pokemon poke in listePoke)
            {
                listePokeView.Add(PokeToPokeView(poke));
            }
            return listePokeView;
        }

        public static List<PokemonViewBool> ListToListePokeBool(IEnumerable<Pokemon> listePoke)
        {
            List<PokemonViewBool> listeBool = new List<PokemonViewBool>();
            foreach (Pokemon poke in listePoke)
            {
                listeBool.Add(PokeToPokeBool(poke));
            }
            return listeBool;
        }
    }

}
