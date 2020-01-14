using PokeListe.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Entities.Models
{
    [Table("Pokemon", "IdPokemon")]
    public class Pokemon : IEntities<int>
    {

        private int _idPokemon;
        private string _nom;
        private int _numero;
        private string _description;
        private string _img;
        private string _obtention;
        private int _IdStat;

        public int id
        {
            get
            {
                return IdPokemon;
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

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Img
        {
            get
            {
                return _img;
            }

            set
            {
                _img = value;
            }
        }

        public int IdStat
        {
            get
            {
                return _IdStat;
            }

            set
            {
                _IdStat = value;
            }
        }

        public string Obtention
        {
            get
            {
                return _obtention;
            }

            set
            {
                _obtention = value;
            }
        }

        public Stat Stat { get; set; }

    }
}
