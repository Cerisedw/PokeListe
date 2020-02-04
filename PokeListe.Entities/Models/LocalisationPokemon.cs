using PokeListe.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Entities.Models
{
    [Table("LocalisationPokemon", "IdLocalisationPokemon")]
    public class LocalisationPokemon : IEntities<int>
    {

        private int _idLocalisationPokemon;
        private int _idLocalisation;
        private int _idPokemon;
        private int _tauxApp;
        private string _lieu;

        public int IdLocalisationPokemon
        {
            get
            {
                return _idLocalisationPokemon;
            }

            set
            {
                _idLocalisationPokemon = value;
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

        public int id
        {
            get
            {
                return _idLocalisationPokemon;
            }
        }
    }
}
