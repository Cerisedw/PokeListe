using PokeListe.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Entities.Models
{
    [Table("Localisation", "IdLocalisation")]
    public class Localisation : IEntities<int>
    {

        private int _idLocalisation;
        private string _nom;
        private string _description;
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

        public int id
        {
            get
            {
                return _idLocalisation;
            }
        }
    }
}
