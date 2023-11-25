using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object usuario)
        {
            Usuario usr = usuario != null ? (Usuario)usuario : null;
            if (usr != null && usr.Id != 0)
                return true;
            else
                return false;
        }

        public static bool isAdmin(object usuario)
        {
            Usuario usr = usuario != null ? (Usuario)usuario : null;
            if (usr != null)
            {
                if (usr.PerfilAcceso.Nivel_Acceso == 3)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool isRecep(object usuario)
        {
            Usuario usr = usuario != null ? (Usuario)usuario : null;
            if (usr != null)
            {
                if (usr.PerfilAcceso.Nivel_Acceso == 2)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
