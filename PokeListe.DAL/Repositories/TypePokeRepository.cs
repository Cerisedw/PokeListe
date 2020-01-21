using PokeListe.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.DAL.Repositories
{
    public sealed class TypePokeRepository : BaseRepository<int, TypePoke>
    {
        public TypePokeRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "";
            UpdateCommand = "";
        }
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override TypePoke Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<TypePoke> GetAll()
        {
            return base.getAll(createItem);
        }

        public override TypePoke Insert(TypePoke item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypePoke> GetAllFromIdPokemon(int key)
        {
            CustomCommand = @"SELECT Type.* FROM Type INNER JOIN PokemonType ON Type.IdType = PokemonType.IdType WHERE PokemonType.IdPokemon = @Id;";
            return base.getAllFromCustomCommand(key, createItem);
        }

        public IEnumerable<TypePoke> GetAllFaiblesse(int key)
        {
            CustomCommand = @"SELECT Type.* FROM Type INNER JOIN Faiblesse ON Type.IdType = Faiblesse.TypeB WHERE Faiblesse.TypeA = @Id;";
            return base.getAllFromCustomCommand(key, createItem);
        }

        public IEnumerable<TypePoke> GetAllResist(int key)
        {
            CustomCommand = @"SELECT Type.* FROM Type INNER JOIN Resistance ON Type.IdType = Resistance.TypeB WHERE Resistance.TypeA = @Id;";
            return base.getAllFromCustomCommand(key, createItem);
        }
        public IEnumerable<TypePoke> GetAllImmun(int key)
        {
            CustomCommand = @"SELECT Type.* FROM Type INNER JOIN Immunite ON Type.IdType = Immunite.TypeB WHERE Immunite.TypeA = @Id;";
            return base.getAllFromCustomCommand(key, createItem);
        }

        protected override Dictionary<string, object> itemToDictio(TypePoke item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdType"] = item.id;
            dictio["Nom"] = item.Nom;
            dictio["Img"] = item.Img;
            return dictio;
        }

        private TypePoke createItem(SqlDataReader d)
        {
            return new TypePoke()
            {
                IdType = (int)d["IdType"],
                Nom = d["Nom"].ToString(),
                Img = d["Img"].ToString()
            };
        }
    }
}
