using PokeListe.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Entities.Models
{
    [Table("Stat", "IdStat")]
    public class Stat : IEntities<int>
    {

        private int _idStat;
        private int _hp;
        private int _atk;
        private int _def;
        private int _atkSpe;
        private int _defSpe;
        private int _vit;

        public int id
        {
            get
            {
                return IdStat;
            }
        }

        public int IdStat
        {
            get
            {
                return _idStat;
            }

            set
            {
                _idStat = value;
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
    }
}
