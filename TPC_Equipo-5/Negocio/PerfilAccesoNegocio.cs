using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PerfilAccesoNegocio
    {
        public List<PerfilAcceso> listar()
        {
            List<PerfilAcceso> perfilesAcceso = new List<PerfilAcceso>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT ID, Codigo, Descripcion, Nivel_Acceso FROM PerfilAcceso;");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    PerfilAcceso aux = new PerfilAcceso();
                    aux.Id = (int)accesoDatos.Lector["ID"];
                    aux.Codigo = (string)accesoDatos.Lector["Codigo"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.Nivel_Acceso = (int)accesoDatos.Lector["Nivel_Acceso"];

                    perfilesAcceso.Add(aux);
                }

                return perfilesAcceso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public PerfilAcceso obtener(int id)
        {
            PerfilAcceso perfilAcceso = new PerfilAcceso();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT Codigo, Descripcion, Nivel_Acceso FROM PerfilAcceso WHERE ID = @id;");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    perfilAcceso.Id = id;
                    perfilAcceso.Codigo = (string)accesoDatos.Lector["Codigo"];
                    perfilAcceso.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    perfilAcceso.Nivel_Acceso = (int)accesoDatos.Lector["Nivel_Acceso"];
                }

                return perfilAcceso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
