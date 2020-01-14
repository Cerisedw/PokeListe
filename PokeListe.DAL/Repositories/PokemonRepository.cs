using PokeListe.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.DAL.Repositories
{
    public sealed class PokemonRepository : BaseRepository<int, Pokemon>
    {
        public PokemonRepository (string Cnstr) : base(Cnstr)
        {
            InsertCommand = "INSERT INTO Pokemon(Nom, Numero, Description, Img, Obtention) " +
                "OUTPUT INSERTED.IdPokemon " +
                "VALUES(@Nom, @Numero, @Description, @Img, @Obtention);";
            UpdateCommand = "";
        }
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Pokemon Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Pokemon> GetAll()
        {
            return base.getAll(createItem);
        }

        public override Pokemon Insert(Pokemon item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            int id = insert(Parameters);
            item.IdPokemon = id;
            return item;

        }

        // Methode du repo
        // Transforme un objet en dictionnaire pour le Base Repository
        protected override Dictionary<string, object> itemToDictio(Pokemon item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdPokemon"] = item.id;
            dictio["Nom"] = item.Nom;
            dictio["Numero"] = item.Numero;
            dictio["Description"] = item.Description;
            dictio["Img"] = item.Img;
            dictio["Obtention"] = item.Obtention;
            dictio["IdStat"] = item.IdStat;
            return dictio;
        }

        // Méthode qu'on envoit au Base Repository pour créer l'objet Membre
        private Pokemon createItem(SqlDataReader d)
        {
            return new Pokemon()
            {
                IdPokemon = (int)d["IdPokemon"],
                Nom = d["Nom"].ToString(),
                Numero = (int)d["Numero"],
                Description = d["Description"].ToString(),
                Img = d["Img"].ToString(),
                Obtention = d["Obtention"].ToString(),
                IdStat = (int)d["IdStat"]
            };
        }

    }
}
