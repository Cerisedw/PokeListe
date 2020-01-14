using PokeListe.Entities.Models;
using PokeListe.Models.Models;
using System;
using System.Collections.Generic;
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
                IdStat = poke.IdStat
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
    }

}
