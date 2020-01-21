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
                Img = type.Img,
            };
        }

        public static TypeViewSimple TypeToTypeSimple(TypePoke type)
        {
            return new TypeViewSimple()
            {
                IdType = type.id,
                Nom = type.Nom,
                Img = type.Img,
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

        public static List<TypeViewSimple> ListTypeToListTypeSimple(IEnumerable<TypePoke> listeTypes)
        {
            List<TypeViewSimple> listeView = new List<TypeViewSimple>();
            foreach (TypePoke type in listeTypes)
            {
                listeView.Add(TypeToTypeSimple(type));
            }
            return listeView;
        }

        public static List<TypeViewSimple> TypeViewSimpleFromPokemon(Pokemon pokemon)
        {
            TypePokeRepository tr = new TypePokeRepository(dbConnect.DbString);
            return ListTypeToListTypeSimple(tr.GetAllFromIdPokemon(pokemon.IdPokemon));
        }

        public static TypeView AddListsToType(TypeView typeV)
        {
            TypePokeRepository tr = new TypePokeRepository(dbConnect.DbString);
            List<TypeViewSimple> listeFaibl = ListTypeToListTypeSimple(tr.GetAllFaiblesse(typeV.IdType));
            List<TypeViewSimple> listeResist = ListTypeToListTypeSimple(tr.GetAllResist(typeV.IdType));
            List<TypeViewSimple> listeImmun = ListTypeToListTypeSimple(tr.GetAllImmun(typeV.IdType));
            typeV.Faiblesse = listeFaibl;
            typeV.Resistance = listeResist;
            typeV.Immunite = listeImmun;
            return typeV;
        }

    }
}
