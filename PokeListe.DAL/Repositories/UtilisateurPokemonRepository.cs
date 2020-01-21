using PokeListe.Entities.Infra;
using PokeListe.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.DAL.Repositories
{
    public sealed class UtilisateurPokemonRepository : BaseRepository<CompositeKey<int, int>, UtilisateurPokemon>
    {
        public UtilisateurPokemonRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "INSERT INTO UtilisateurPokemon(IdUtilisateur, IdPokemon) OUTPUT INSERTED.IdPokemon " +
                "VALUES (@IdUtilisateur, @IdPokemon);";
            UpdateCommand = "UPDATE UtilisateurPokemon " +
                "SET IdUtilisateur=@IdUtilisateur, IdPokemon=@IdPokemon " +
                "WHERE IdUtilisateur=@IdUtilisateur;";
        }
        public override bool Delete(CompositeKey<int, int> key)
        {
            return base.delete(key);
        }

        public override UtilisateurPokemon Get(CompositeKey<int, int> key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<UtilisateurPokemon> GetAll()
        {
            return base.getAll(createItem);
        }

        public override UtilisateurPokemon Insert(UtilisateurPokemon item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            base.insert(Parameters);
            return item;
        }

        //public IEnumerable<UtilisateurPokemon> GetAllFromPokemon(int idUser)
        //{
        //    CustomCommand = @"SELECT UtilisateurPokemon.* FROM UtilisateurPokemon INNER JOIN Pokemon ON UtilisateurPokemon.IdPokemon = Pokemon.IdPokemon WHERE UtilisateurPokemon.IdUtilisateur = @Id;";

        //}


        protected override Dictionary<string, object> itemToDictio(UtilisateurPokemon item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdUtilisateur"] = item.IdUtilisateur;
            dictio["IdPokemon"] = item.IdPokemon;
            return dictio;
        }

        private UtilisateurPokemon createItem(SqlDataReader d)
        {
            return new UtilisateurPokemon()
            {
                IdUtilisateur = (int)d["IdUtilisateur"],
                IdPokemon = (int)d["IdPokemon"],
            };
        }
    }
}
