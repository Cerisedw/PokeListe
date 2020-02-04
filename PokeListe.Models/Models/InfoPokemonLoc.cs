using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class InfoPokemonLoc
    {

        private int _idPokemon;
        private string _nom;
        private string _img;
        private int _tauxApp;
        private string _lieu;

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

        public int TauxApp
        {
            get
            {
                return _tauxApp;
            }

            set
            {
                _tauxApp = value;
            }
        }

        public string Lieu
        {
            get
            {
                return _lieu;
            }

            set
            {
                _lieu = value;
            }
        }

        public List<TypeViewSimple> Types { get; set; }

    }
}
