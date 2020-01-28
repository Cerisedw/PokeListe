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

        public static bool isAdmin
        {
            get
            {
                if (IsConnected && ConnectedUser.Email == "admin@admin.com")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<TypeViewSimple> listTypes
        {
            get
            {
                if (HttpContext.Current.Session["listeTypes"] != null)
                {
                    return (List<TypeViewSimple>)HttpContext.Current.Session["listeTypes"];
                }
                return null;
            }
            set { HttpContext.Current.Session["listeTypes"] = value; }
        }

    }

}