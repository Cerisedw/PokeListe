using PokeListe.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Entities.Models
{
    [Table("Type", "IdType")]
    public class Type : IEntities<int>
    {
        private int _idType;
        private string _nom;
        private string _img;

        public int id
        {
            get
            {
                return IdType;
            }
        }

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
