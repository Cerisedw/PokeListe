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
    public static class StatTools
    {
        
        public static StatView StatToStatView (Stat stat)
        {
            return new StatView()
            {
                IdStat = stat.id,
                Hp = stat.Hp,
                Atk = stat.Atk,
                Def = stat.Def,
                AtkSpe = stat.AtkSpe,
                DefSpe = stat.DefSpe,
                Vit = stat.Vit
            };
        }

        public static StatView AddStatToPokemonView (Pokemon pokemon)
        {
            StatRepository sr = new StatRepository(dbConnect.DbString);
            return StatToStatView(sr.Get(pokemon.IdStat));
            
        }

    }
}
