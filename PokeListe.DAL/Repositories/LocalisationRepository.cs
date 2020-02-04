using PokeListe.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.DAL.Repositories
{
    public sealed class LocalisationRepository : BaseRepository<int, Localisation>
    {
        public LocalisationRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "";
            UpdateCommand = "";
        }

        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Localisation Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Localisation> GetAll()
        {
            return base.getAll(createItem);
        }

        public override Localisation Insert(Localisation item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Localisation> GetAllFromIdPoke(int idPoke)
        {
            CustomCommand = "SELECT * FROM Localisation INNER JOIN LocalisationPokemon ON Localisation.IdLocalisation = LocalisationPokemon.IdLocalisation WHERE LocalisationPokemon.IdPokemon = @Id;";
            return base.getAllFromCustomCommand(idPoke, createItem);
        }

        protected override Dictionary<string, object> itemToDictio(Localisation item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdLocalisation"] = item.id;
            dictio["Nom"] = item.Nom;
            dictio["Description"] = item.Description;
            dictio["Img"] = item.Img;
            return dictio;
        }


        private Localisation createItem(SqlDataReader d)
        {
            return new Localisation()
            {
                IdLocalisation = (int)d["IdLocalisation"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                Img = d["Img"].ToString(),
            };
        }
    }
}
