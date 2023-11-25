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
    }
}
