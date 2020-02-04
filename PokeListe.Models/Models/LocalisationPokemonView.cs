using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class LocalisationPokemonView
    {

        private int _idLocalisationPokemonView;
        private int _idLocalisation;
        private int _idPokemon;
        private int _tauxApp;
        private string _lieu;

        public int IdLocalisationPokemonView
        {
            get
            {
                return _idLocalisationPokemonView;
            }

            set
            {
                _idLocalisationPokemonView = value;
            }
        }

        public int IdLocalisation
        {
            get
            {
                return _idLocalisation;
            }

            set
            {
                _idLocalisation = value;
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
    }
}
