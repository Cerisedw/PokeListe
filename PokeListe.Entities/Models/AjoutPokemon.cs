using PokeListe.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Entities.Models
{
    public class AjoutPokemon
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
        private int _idType1;
        private int _idType2;

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

        public int IdType1
        {
            get
            {
                return _idType1;
            }

            set
            {
                _idType1 = value;
            }
        }

        public int IdType2
        {
            get
            {
                return _idType2;
            }

            set
            {
                _idType2 = value;
            }
        }


    }
}
