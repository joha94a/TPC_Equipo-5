using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio
{
    public class PacienteNegocio
    {
        public List<Paciente> listarPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT P.Id, P.DNI, P.Nombre, P.Apellido, P.Fecha_Nacimiento, P.Genero, P.Direccion, P.Telefono, P.Mail, P.Observaciones FROM Pacientes P;");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.DNI = (int)accesoDatos.Lector["DNI"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)accesoDatos.Lector["Apellido"];
                    aux.Fecha_Nacimiento = (DateTime)accesoDatos.Lector["Fecha_Nacimiento"];
                    aux.Genero = (char)accesoDatos.Lector["Genero"];
                    if (!(accesoDatos.Lector["Direccion"] is DBNull))
                        aux.Direccion = (string)accesoDatos.Lector["Direccion"];
                    if (!(accesoDatos.Lector["Telefono"] is DBNull))
                        aux.Telefono = (string)accesoDatos.Lector["Telefono"];
                    aux.Mail = (string)accesoDatos.Lector["Mail"];
                    if (!(accesoDatos.Lector["Observaciones"] is DBNull))
                        aux.Observaciones = (string)accesoDatos.Lector["Observaciones"];

                    pacientes.Add(aux);
                }

                return pacientes;
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

        public List<Paciente> listarPacientesFiltrado(string filtro)
        {
            List<Paciente> pacientes = new List<Paciente>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT P.Id, P.DNI, P.Nombre, P.Apellido, P.Fecha_Nacimiento, P.Genero, P.Direccion, P.Telefono, P.Mail, P.Observaciones FROM Pacientes P WHERE P.DNI like '%@filtro%' OR P.Nombre like '%@filtro%' OR P.Apellido like '%@filtro%' OR P.Direccion like '%@filtro%' OR P.Mail like '%@filtro%';");
                accesoDatos.setearParametro("@filtro", filtro);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.DNI = (int)accesoDatos.Lector["DNI"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)accesoDatos.Lector["Apellido"];
                    aux.Fecha_Nacimiento = (DateTime)accesoDatos.Lector["Fecha_Nacimiento"];
                    aux.Genero = (char)accesoDatos.Lector["Genero"];
                    if (!(accesoDatos.Lector["Direccion"] is DBNull))
                        aux.Direccion = (string)accesoDatos.Lector["Direccion"];
                    if (!(accesoDatos.Lector["Telefono"] is DBNull))
                        aux.Telefono = (string)accesoDatos.Lector["Telefono"];
                    aux.Mail = (string)accesoDatos.Lector["Mail"];
                    if (!(accesoDatos.Lector["Observaciones"] is DBNull))
                        aux.Observaciones = (string)accesoDatos.Lector["Observaciones"];

                    pacientes.Add(aux);
                }

                return pacientes;
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

        public void agregar(Paciente paciente)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO Pacientes values (@DNI, @Nombre, @Apellido, @Fecha_Nacimiento, @Genero, @Direccion, @Telefono, @Mail, @Observaciones);");
                accesoDatos.setearParametro("@DNI", paciente.DNI);
                accesoDatos.setearParametro("@DNI", paciente.Nombre);
                accesoDatos.setearParametro("@DNI", paciente.Apellido);
                accesoDatos.setearParametro("@DNI", paciente.Fecha_Nacimiento);
                accesoDatos.setearParametro("@DNI", paciente.Genero);
                accesoDatos.setearParametro("@DNI", paciente.Direccion);
                accesoDatos.setearParametro("@DNI", paciente.Telefono);
                accesoDatos.setearParametro("@DNI", paciente.Mail);
                accesoDatos.setearParametro("@DNI", paciente.Observaciones);
                accesoDatos.ejecutarAccion();
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
