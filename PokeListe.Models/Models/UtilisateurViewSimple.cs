﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class UtilisateurViewSimple
    {
        private int _idUtilisateur;
        private string _pseudo;
        private string _email;
        private string _img;

        public int IdUtilisateur
        {
            get
            {
                return _idUtilisateur;
            }

            set
            {
                _idUtilisateur = value;
            }
        }

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }

            set
            {
                _pseudo = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
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

        public List<int> ListePoke { get; set; }

        public UtilisateurViewSimple()
        {
            ListePoke = new List<int>();
        }
    }
}
