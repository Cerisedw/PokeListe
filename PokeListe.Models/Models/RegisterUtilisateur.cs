using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Models.Models
{
    public class RegisterUtilisateur
    {
        private string _pseudo;
        private string _email;
        private string _mdp;
        private string _confirmMdp;
        private string _img;

        [Required(ErrorMessage = "Il faut écrire un pseudo")]
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

        [Required]
        [DataType(DataType.EmailAddress)]
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

        [Required]
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

        [Compare("Mdp", ErrorMessage = "Les mots de passe ne correspondent pas")] //You can localize your Error message 
        public string ConfirmMdp
        {
            get
            {
                return _confirmMdp;
            }

            set
            {
                _confirmMdp = value;
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
