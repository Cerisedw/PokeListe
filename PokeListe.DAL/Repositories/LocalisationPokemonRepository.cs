using PokeListe.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.DAL.Repositories
{
    public sealed class LocalisationPokemonRepository : BaseRepository<int, LocalisationPokemon>
    {

        public LocalisationPokemonRepository(string Cnstr) : base(Cnstr)
        {

        }

        public override bool Delete(int key)
        {
            return base.delete(key);
        }

        public override LocalisationPokemon Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<LocalisationPokemon> GetAll()
        {
            return base.getAll(createItem);
        }

        public override LocalisationPokemon Insert(LocalisationPokemon item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalisationPokemon> GetAllFromLoc(int idLoc)
        {
            //  ORDER BY LocalisationPokemon.Lieu ASC  ne fonctionne pas encore car dans mon mapper j'utilise deux listes dont l'une ne sera pas triée.
            CustomCommand = "SELECT * FROM LocalisationPokemon WHERE LocalisationPokemon.IdLocalisation = @Id;";
            return base.getAllFromCustomCommand(idLoc, createItem);
        }

        protected override Dictionary<string, object> itemToDictio(LocalisationPokemon item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdLocalisationPokemon"] = item.id;
            dictio["IdLocalisation"] = item.IdLocalisation;
            dictio["IdPokemon"] = item.IdPokemon;
            dictio["TauxApp"] = item.TauxApp;
            dictio["Lieu"] = item.Lieu;
            return dictio;
        }


        private LocalisationPokemon createItem(SqlDataReader d)
        {
            return new LocalisationPokemon()
            {
                IdLocalisationPokemon = (int)d["IdLocalisationPokemon"],
                IdLocalisation = (int)d["IdLocalisation"],
                IdPokemon = (int)d["IdPokemon"],
                TauxApp = (int)d["TauxApp"],
                Lieu = d["Lieu"].ToString(),

            };
        }
    }
}
