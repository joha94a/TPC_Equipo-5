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
                accesoDatos.setearConsulta("SELECT P.Id, P.DNI, P.Nombre, P.Apellido, P.Fecha_Nacimiento, P.Genero, P.Direccion, P.Telefono, P.Mail, P.Observaciones FROM Paciente P;");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.DNI = (int)accesoDatos.Lector["DNI"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)accesoDatos.Lector["Apellido"];
                    aux.Fecha_Nacimiento = (DateTime)accesoDatos.Lector["Fecha_Nacimiento"];
                    aux.Genero = (string)accesoDatos.Lector["Genero"];
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

        public List<Paciente> listarPacientesFiltrado(string dni, string nombre, string apellido, DateTime? fechaNacimientoDesde, DateTime? fechaNacimientoHasta)
        {
            List<Paciente> pacientes = new List<Paciente>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                //accesoDatos.setearConsulta(@"SELECT Id, DNI, Nombre, Apellido, Fecha_Nacimiento, Genero, Direccion, Telefono, Mail, Observaciones 
                //                            FROM Paciente 
                //                            WHERE 
                //                                (@dni = '' OR DNI LIKE '%' + @dni + '%')
                //                            AND (@nombre = '' OR Nombre LIKE '%' + @nombre + '%')
                //                            AND (@apellido = '' OR Apellido LIKE '%' + @apellido + '%')
                //                            AND (@fechaDesde IS NULL OR Fecha_Nacimiento >= @fechaDesde) 
                //                            AND (@fechaHasta IS NULL OR Fecha_Nacimiento <= @fechaHasta)");
                accesoDatos.setearProcedimiento("PacientesGet");
                accesoDatos.setearParametro("@dni", dni);
                accesoDatos.setearParametro("@nombre", nombre);
                accesoDatos.setearParametro("@apellido", apellido);
                accesoDatos.setearParametro("@fechaDesde", fechaNacimientoDesde);
                accesoDatos.setearParametro("@fechaHasta", fechaNacimientoHasta);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.DNI = (int)accesoDatos.Lector["DNI"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)accesoDatos.Lector["Apellido"];
                    aux.Fecha_Nacimiento = (DateTime)accesoDatos.Lector["Fecha_Nacimiento"];
                    aux.Genero = (string)accesoDatos.Lector["Genero"];
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
                if (paciente.Id > 0)
                {
                    accesoDatos.setearConsulta(@"UPDATE Paciente set 
                                                DNI = @DNI, 
                                                Nombre = @Nombre, 
                                                Apellido = @Apellido, 
                                                Fecha_Nacimiento = @Fecha_Nacimiento, 
                                                Genero = @Genero, 
                                                Direccion = @Direccion, 
                                                Telefono = @Telefono, 
                                                Mail = @Mail, 
                                                Observaciones = @Observaciones
                                                WHERE ID = @id");
                    accesoDatos.setearParametro("@id", paciente.Id);
                }
                else
                {
                    accesoDatos.setearConsulta("INSERT INTO Paciente values (@DNI, @Nombre, @Apellido, @Fecha_Nacimiento, @Genero, @Direccion, @Telefono, @Mail, @Observaciones);");
                }
                accesoDatos.setearParametro("@DNI", paciente.DNI);
                accesoDatos.setearParametro("@Nombre", paciente.Nombre);
                accesoDatos.setearParametro("@Apellido", paciente.Apellido);
                accesoDatos.setearParametro("@Fecha_Nacimiento", paciente.Fecha_Nacimiento);
                accesoDatos.setearParametro("@Genero", paciente.Genero);
                accesoDatos.setearParametro("@Direccion", paciente.Direccion);
                accesoDatos.setearParametro("@Telefono", paciente.Telefono);
                accesoDatos.setearParametro("@Mail", paciente.Mail);
                accesoDatos.setearParametro("@Observaciones", paciente.Observaciones);
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

        public void Delete(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("DELETE Paciente WHERE ID = @id");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public Paciente Get(int id)
        {
            Paciente obj = new Paciente();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"SELECT ID, DNI, Nombre, Apellido, Fecha_Nacimiento, Genero, Direccion, Telefono, Mail, Observaciones FROM Paciente WHERE ID = @id");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();

                accesoDatos.Lector.Read();
                obj.Id = (int)accesoDatos.Lector["Id"];
                obj.DNI = (int)accesoDatos.Lector["DNI"];
                obj.Nombre = (string)accesoDatos.Lector["Nombre"];
                obj.Apellido = (string)accesoDatos.Lector["Apellido"];
                obj.Fecha_Nacimiento = (DateTime)accesoDatos.Lector["Fecha_Nacimiento"];
                obj.Genero = (string)accesoDatos.Lector["Genero"];
                obj.Direccion = (string)accesoDatos.Lector["Direccion"];
                obj.Telefono = (string)accesoDatos.Lector["Telefono"];
                obj.Mail = (string)accesoDatos.Lector["Mail"];
                obj.Observaciones = (string)accesoDatos.Lector["Observaciones"];

                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public Paciente GetPorDNI(int dni, int id)
        {
            Paciente obj = new Paciente();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"SELECT ID, DNI, Nombre, Apellido, Fecha_Nacimiento, Genero, Direccion, Telefono, Mail, Observaciones FROM Paciente WHERE DNI = @dni AND ID != @id");
                accesoDatos.setearParametro("@dni", dni);
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();


                while (accesoDatos.Lector.Read())
                {
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.DNI = (int)accesoDatos.Lector["DNI"];
                    obj.Nombre = (string)accesoDatos.Lector["Nombre"];
                    obj.Apellido = (string)accesoDatos.Lector["Apellido"];
                    obj.Fecha_Nacimiento = (DateTime)accesoDatos.Lector["Fecha_Nacimiento"];
                    obj.Genero = (string)accesoDatos.Lector["Genero"];
                    obj.Direccion = (string)accesoDatos.Lector["Direccion"];
                    obj.Telefono = (string)accesoDatos.Lector["Telefono"];
                    obj.Mail = (string)accesoDatos.Lector["Mail"];
                    obj.Observaciones = (string)accesoDatos.Lector["Observaciones"];
                }
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
