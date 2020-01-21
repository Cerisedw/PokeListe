using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class PokemonViewBool
    {
        private int _idPokemon;
        private string _nom;
        private int _numero;
        private string _img;
        private bool _obtenu;

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

        public bool Obtenu
        {
            get
            {
                return _obtenu;
            }

            set
            {
                _obtenu = value;
            }
        }
        public List<TypeViewSimple> Types { get; set; }
    }
}
