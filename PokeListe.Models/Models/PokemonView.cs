using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeListe.Models.Models
{
    public class PokemonView
    {
        private int _idPokemon;
        private string _nom;
        private int _numero;
        private string _description;
        private string _img;
        private string _obtention;
        private int _IdStat;

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

        public StatView Stat { get; set; }
        public List<TypeView> Types { get; set;  }

    }
}