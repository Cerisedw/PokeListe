using PokeListe.Entities.Infra;
using PokeListe.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Entities.Models
{
    [Table("UtilisateurPokemon", "IdUtilisateur", "IdPokemon")]
    public class UtilisateurPokemon : IEntities<CompositeKey<int, int>>
    {
        private int _idUtilisateur;
        private int _idPokemon;

        public int IdUtilisateur
        {
            get
            {
                return _idUtilisateur;
            }

            set
            {
                _idUtilisateur = value;
            }
        }

        public int IdPokemon
        {
            get
            {
                return _idPokemon;
            }

            set
            {
                _idPokemon = value;
            }
        }

        public CompositeKey<int, int> id
        {
            get
            {
                return new CompositeKey<int, int>() { PK1 = IdUtilisateur, PK2 = IdPokemon };
            }
        }
    }
}
