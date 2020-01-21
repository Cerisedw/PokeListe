using PokeListe.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeListe.Session
{
    public static class SessionUtils
    {
        public static UtilisateurViewSimple ConnectedUser
        {
            get
            {
                if (HttpContext.Current.Session["ConnectedUser"] != null)
                {
                    return (UtilisateurViewSimple)HttpContext.Current.Session["ConnectedUser"];
                }
                return null;
            }
            set { HttpContext.Current.Session["ConnectedUser"] = value; }
        }

        public static bool IsConnected
        {
            get
            {
                if (HttpContext.Current.Session["IsConnected"] != null)
                {
                    return (bool)HttpContext.Current.Session["IsConnected"];
                }
                return false;
            }
            set { HttpContext.Current.Session["IsConnected"] = value; }
        }

    }

}