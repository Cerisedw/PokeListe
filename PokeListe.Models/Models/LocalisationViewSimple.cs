using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class LocalisationViewSimple
    {

        private int _idLocalisation;
        private string _nom;
        private string _img;

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
    }
}
