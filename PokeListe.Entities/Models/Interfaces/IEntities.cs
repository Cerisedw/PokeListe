using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Entities.Models.Interfaces
{
    public interface IEntities<TKey>
    {
        TKey id { get; }
    }
}
