﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class TypeViewSimple
    {

        private int _idType;
        private string _nom;
        private string _img;

        public int IdType
        {
            get
            {
                return _idType;
            }

            set
            {
                _idType = value;
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
