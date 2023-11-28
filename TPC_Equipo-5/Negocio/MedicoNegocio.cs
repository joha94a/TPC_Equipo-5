using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                accesoDatos.setearConsulta("select m.ID, m.Nombre, m.Apellido, m.Telefono, m.Mail from Medico m");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = (int)accesoDatos.Lector["ID"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)accesoDatos.Lector["Apellido"];
                    aux.Telefono = (string)accesoDatos.Lector["Telefono"];
                    aux.Mail = (string)accesoDatos.Lector["Mail"];

                    EspecialidadNegocio espNegocio = new EspecialidadNegocio();
                    aux.Especialidades = espNegocio.obtenerEspPorMedico(aux.Id);

                    HorarioNegocio horarioNegocio = new HorarioNegocio();
                    aux.Horarios = horarioNegocio.obtenerHorarioPorMedico(aux.Id);

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

        public void agregar(Medico medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                if (medico.Id > 0)
                {
                    accesoDatos.setearConsulta(@"UPDATE Medico set 
                                                Nombre = @Nombre, 
                                                Apellido = @Apellido,
                                                Telefono = @Telefono, 
                                                Mail = @Mail
                                                WHERE ID = @id");
                    accesoDatos.setearParametro("@id", medico.Id);
                }
                else
                {
                    accesoDatos.setearConsulta("INSERT INTO Medico values (@Nombre, @Apellido, @Telefono, @Mail);");
                }
                
                accesoDatos.setearParametro("@Nombre", medico.Nombre);
                accesoDatos.setearParametro("@Apellido", medico.Apellido);
                accesoDatos.setearParametro("@Telefono", medico.Telefono);
                accesoDatos.setearParametro("@Mail", medico.Mail);
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

        public void modificar(Medico medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("UPDATE Medico SET Nombre = @nombre, Apellido = @apellido, Telefono = @telefono, Mail = @mail where ID = @Id");
                accesoDatos.setearParametro("@nombre", medico.Nombre);
                accesoDatos.setearParametro("@apellido", medico.Apellido);
                accesoDatos.setearParametro("@telefono", medico.Telefono);
                accesoDatos.setearParametro("@mail", medico.Mail);

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

        public void eliminar(int id)
        {

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("DELETE FROM Medico WHERE ID = @Id");
                accesoDatos.setearParametro("Id", id);
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

        public List<Medico> filtrar(string campo, string criterio)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Medico> medicos = new List<Medico>();

            try
            {
                string consulta = "SELECT m.Nombre, m.Apellido, m.Telefono, m.Mail from Medico m  WHERE ";

                if (campo == "Nombre")
                {
                    consulta += "m.Nombre = '" + criterio + "'";
                }
                else if (campo == "Apellido")
                {
                    consulta += "m.Apellido = '" + criterio + "'";
                }
                else if (campo == "Telefono")
                {
                    consulta += "m.Telefono = '" + criterio + "'";
                }
                else if (campo == "Mail")
                {
                    consulta += "m.Mail = '" + criterio + "'";
                }

                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Medico aux = new Medico();
                    
                   aux.Nombre = (string)accesoDatos.Lector["nombre"];
                   aux.Apellido = (string)accesoDatos.Lector["apellido"];
                   aux.Telefono = (string)accesoDatos.Lector["telefono"];
                   aux.Mail = (string)accesoDatos.Lector["mail"];

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

        public List<Medico> listarMedicoFiltrado(string filtro)
        {
            List<Medico> medicos = new List<Medico>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("select m.ID, m.Nombre, m.Apellido, m.Telefono, m.Mail from Medico m WHERE UPPER(m.Nombre) LIKE @filtro OR UPPER(m.Apellido) LIKE @filtro OR UPPER(m.Telefono) LIKE @filtro OR UPPER(m.Mail) LIKE @filtro;");
                accesoDatos.setearParametro("@filtro", "%" + filtro.ToUpper() + "%");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = int.Parse(accesoDatos.Lector["ID"].ToString());
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

        public List<Medico> listarMedicoFiltrado(string nombre, string apellido, string mail, string especialidad)
        {
            List<Medico> medicos = new List<Medico>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                if (especialidad == "")
                {
                    accesoDatos.setearConsulta("select m.ID, m.Nombre, m.Apellido, m.Telefono, m.Mail from medico m WHERE UPPER(m.Nombre) LIKE @Nombre AND UPPER(m.Apellido) LIKE @Apellido AND UPPER(m.Mail) LIKE @Mail;");
                }
                else
                {
                    accesoDatos.setearConsulta("select m.ID, m.Nombre, m.Apellido, m.Telefono, m.Mail, e.Descripcion from medico m left join Medico_Especialidad me on m.id = me.IDMedico left join Especialidad e on me.IDEspecialidad = e.ID WHERE e.Descripcion = @Especialidad;");

                }

                accesoDatos.setearParametro("@Nombre", "%" + nombre.ToUpper() + "%");
                accesoDatos.setearParametro("@Apellido", "%" + apellido.ToUpper() + "%");
                accesoDatos.setearParametro("@Mail", "%" + mail.ToUpper() + "%");
                accesoDatos.setearParametro("@Especialidad", especialidad);

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = int.Parse(accesoDatos.Lector["ID"].ToString());
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)accesoDatos.Lector["Apellido"];
                    aux.Telefono = (string)accesoDatos.Lector["Telefono"];
                    aux.Mail = (string)accesoDatos.Lector["Mail"];

                    EspecialidadNegocio espNegocio = new EspecialidadNegocio();
                    aux.Especialidades = espNegocio.obtenerEspPorMedico(aux.Id);

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

        public int RelacionesDeEspecialidad(int especialidadId)
        {
            int medicos = 0;

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"SELECT COUNT(m.Id) medicos FROM Medico m
                                            INNER JOIN Medico_Especialidad me ON me.IDMedico = m.Id
                                            INNER JOIN Especialidad e ON e.Id = me.IDEspecialidad
                                            WHERE e.Id = @especialidadId");
                accesoDatos.setearParametro("@especialidadId", especialidadId);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    medicos = (int)accesoDatos.Lector["medicos"];
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

        public int RelacionesDeHorarios(int horarioId)
        {

            // ToDo: REVISAR
            // Ya no es válido con los cambios en BD.

            int medicos = 0;

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"SELECT COUNT(m.Id) medicos FROM Medico m
                                            INNER JOIN Medico_Horario mh ON mh.IDMedico = m.Id
                                            INNER JOIN Horario h ON h.Id = mh.IDHorario
                                            WHERE h.Id = @horarioId");
                accesoDatos.setearParametro("@horarioId", horarioId);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    medicos = (int)accesoDatos.Lector["medicos"];
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

        public Medico Get(int id)
        {
            Medico obj = new Medico();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("select m.ID, m.Nombre, m.Apellido, m.Telefono, m.Mail from Medico m WHERE m.Id = @id");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    obj.Id = (int)accesoDatos.Lector["ID"];
                    obj.Nombre = (string)accesoDatos.Lector["Nombre"];
                    obj.Apellido = (string)accesoDatos.Lector["Apellido"];
                    obj.Telefono = (string)accesoDatos.Lector["Telefono"];
                    obj.Mail = (string)accesoDatos.Lector["Mail"];

                    EspecialidadNegocio espNegocio = new EspecialidadNegocio();
                    obj.Especialidades = espNegocio.obtenerEspPorMedico(obj.Id);
                }

                return obj;
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
