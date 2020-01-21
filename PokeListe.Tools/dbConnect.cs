using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeListe.Tools
{
    public static class dbConnect
    {
        public static string DbString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString;
            }
        }
    }
}
