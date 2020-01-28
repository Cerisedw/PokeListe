using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class AddPokemon
    {
        private string _nom;
        private int _numero;
        private string _description;
        private string _img;
        private string _obtention;
        private int _hp;
        private int _atk;
        private int _def;
        private int _atkSpe;
        private int _defSpe;
        private int _vit;
        private int _type1;
        private int _type2;

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

        public int Hp
        {
            get
            {
                return _hp;
            }

            set
            {
                _hp = value;
            }
        }

        public int Atk
        {
            get
            {
                return _atk;
            }

            set
            {
                _atk = value;
            }
        }

        public int Def
        {
            get
            {
                return _def;
            }

            set
            {
                _def = value;
            }
        }

        public int AtkSpe
        {
            get
            {
                return _atkSpe;
            }

            set
            {
                _atkSpe = value;
            }
        }

        public int DefSpe
        {
            get
            {
                return _defSpe;
            }

            set
            {
                _defSpe = value;
            }
        }

        public int Vit
        {
            get
            {
                return _vit;
            }

            set
            {
                _vit = value;
            }
        }

        public int Type1
        {
            get
            {
                return _type1;
            }

            set
            {
                _type1 = value;
            }
        }

        public int Type2
        {
            get
            {
                return _type2;
            }

            set
            {
                _type2 = value;
            }
        }
    }
}
