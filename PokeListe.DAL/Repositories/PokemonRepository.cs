using PokeListe.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;

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

        public IEnumerable<Pokemon> getAllFromUser(int idUser)
        {
            CustomCommand = "SELECT Pokemon.* FROM Pokemon INNER JOIN UtilisateurPokemon ON Pokemon.IdPokemon = UtilisateurPokemon.IdPokemon WHERE UtilisateurPokemon.IdUtilisateur = @Id;";
            return base.getAllFromCustomCommand(idUser, createItem);
        }
        public IEnumerable<Pokemon> getAllFromType(int idType)
        {
            CustomCommand = "SELECT Pokemon.* FROM Pokemon INNER JOIN PokemonType ON Pokemon.IdPokemon = PokemonType.IdPokemon WHERE PokemonType.IdType = @Id;";
            return base.getAllFromCustomCommand(idType, createItem);
        }
        public IEnumerable<Pokemon> getAllFromLoc(int idLoc)
        {
            CustomCommand = "SELECT Pokemon.* FROM Pokemon INNER JOIN LocalisationPokemon ON Pokemon.IdPokemon = LocalisationPokemon.IdPokemon WHERE LocalisationPokemon.IdLocalisation = @Id;";
            return base.getAllFromCustomCommand(idLoc, createItem);
        }

        public int insertPokemon(AjoutPokemon ap)
        {
            CustomCommand = "EXEC AjoutPoke @Nom, @Numero, @Description, @Img, @Obtention, @Hp, @Atk, @Def, @AtkSpe, @DefSpe, @Vit, @IdType1, @IdType2;";
            Command cmd = new Command(CustomCommand);
            cmd.AddParameter("Nom", ap.Nom);
            cmd.AddParameter("Numero", ap.Numero);
            cmd.AddParameter("Description", ap.Description);
            cmd.AddParameter("Img", ap.Img);
            cmd.AddParameter("Obtention", ap.Obtention);
            cmd.AddParameter("Hp", ap.Hp);
            cmd.AddParameter("Atk", ap.Atk);
            cmd.AddParameter("Def", ap.Def);
            cmd.AddParameter("AtkSpe", ap.AtkSpe);
            cmd.AddParameter("DefSpe", ap.DefSpe);
            cmd.AddParameter("Vit", ap.Vit);
            cmd.AddParameter("IdType1", ap.IdType1);
            cmd.AddParameter("IdType2", ap.IdType2);
            int id =  (int)_oconn.ExecuteScalar(cmd);
            return id;

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
