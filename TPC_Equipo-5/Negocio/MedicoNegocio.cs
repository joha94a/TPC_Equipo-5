using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MedicoNegocio
    {
        public List<Medico> listarMedicos()
        {
            List<Medico> medicos = new List<Medico>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("select m.Nombre, m.Apellido, m.Telefono, m.Mail from Medico m;");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)accesoDatos.Lector["Apellido"];
                    aux.Telefono = (string)accesoDatos.Lector["Telefono"];
                    aux.Mail = (string)accesoDatos.Lector["Mail"];

                    medicos.Add(aux);
                }

                return medicos;
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
