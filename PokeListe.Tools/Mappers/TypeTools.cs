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
    public static class TypeTools
    {

        public static TypeView TypeToTypeView (TypePoke type)
        {
            return new TypeView()
            {
                IdType = type.id,
                Nom = type.Nom,
                Img = type.Img
            };
        }

        public static List<TypeView> ListTypeToListTypeView (IEnumerable<TypePoke> listeTypes)
        {
            List<TypeView> listeView = new List<TypeView>();
            foreach (TypePoke type in listeTypes)
            {
                listeView.Add(TypeToTypeView(type));
            }
            return listeView;
        }

        public static List<TypeView> TypeViewFromPokemon(Pokemon pokemon)
        {
            TypePokeRepository tr = new TypePokeRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            return ListTypeToListTypeView(tr.GetAllFromIdPokemon(pokemon.IdPokemon));
        }

    }
}
