using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class LoginUtilisateur
    {

        private string _email;
        private string _mdp;

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

        public string Mdp
        {
            get
            {
                return _mdp;
            }

            set
            {
                _mdp = value;
            }
        }
    }
}
