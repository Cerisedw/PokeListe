using PokeListe.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.DAL.Repositories
{
    public sealed class StatRepository : BaseRepository<int, Stat>
    {
        public StatRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "";
            UpdateCommand = "";
        }
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Stat Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Stat> GetAll()
        {
            return base.getAll(createItem);
        }

        public override Stat Insert(Stat item)
        {
            throw new NotImplementedException();
        }

        protected override Dictionary<string, object> itemToDictio(Stat item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdStat"] = item.id;
            dictio["Hp"] = item.Hp;
            dictio["Atk"] = item.Atk;
            dictio["Def"] = item.Def;
            dictio["AtkSpe"] = item.AtkSpe;
            dictio["DefSpe"] = item.DefSpe;
            dictio["Vit"] = item.Vit;
            return dictio;
        }

        private Stat createItem(SqlDataReader d)
        {
            return new Stat()
            {
                IdStat = (int)d["IdStat"],
                Hp = (int)d["Hp"],
                Atk = (int)d["Atk"],
                Def = (int)d["Def"],
                AtkSpe = (int)d["AtkSpe"],
                DefSpe = (int)d["DefSpe"],
                Vit = (int)d["Vit"]
            };
        }

    }
}
