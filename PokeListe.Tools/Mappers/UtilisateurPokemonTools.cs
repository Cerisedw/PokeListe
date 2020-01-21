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
    public static class UtilisateurPokemonTools
    {

        public static UtilisateurPokemon CompositeToUtilisateurPoke(int idUt, int idPoke)
        {
            return new UtilisateurPokemon()
            {
                IdUtilisateur = idUt,
                IdPokemon = idPoke
            };
        }




    }
}
