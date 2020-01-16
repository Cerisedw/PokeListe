using PokeListe.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.DAL.Repositories
{
    public sealed class UtilisateurRepository : BaseRepository<int, Utilisateur>
    {
        public UtilisateurRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "INSERT INTO Utilisateur(Pseudo, Email, Mdp, Img) " +
                "OUTPUT INSERTED.IdUtilisateur " +
                "VALUES(@Pseudo, @Email, @Mdp, @Img);";
            UpdateCommand = "";
        }
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Utilisateur Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Utilisateur> GetAll()
        {
            return base.getAll(createItem);
        }

        public override Utilisateur Insert(Utilisateur item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            int id = insert(Parameters);
            item.IdUtilisateur = id;
            return item;
        }

        public Utilisateur getByLogin(Utilisateur item)
        {
            CustomCommand = @"SELECT * FROM Utilisateur WHERE Email = @Email AND Mdp = @Mdp;";
            Dictionary<string, object> Parameters = itemToDictio(item);
            return base.getByLogin(Parameters, createItem);
        }

        protected override Dictionary<string, object> itemToDictio(Utilisateur item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdUtilisateur"] = item.id;
            dictio["Pseudo"] = item.Pseudo;
            dictio["Email"] = item.Email;
            dictio["Mdp"] = item.HashMDP;
            dictio["Img"] = item.Img;
            return dictio;
        }

        private Utilisateur createItem(SqlDataReader d)
        {
            return new Utilisateur()
            {
                IdUtilisateur = (int)d["IdUtilisateur"],
                Pseudo = d["Pseudo"].ToString(),
                Email = d["Email"].ToString(),
                Mdp = d["Mdp"].ToString(),
                Img = d["Img"].ToString()
            };
        }
    }
}
