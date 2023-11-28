using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class HorarioNegocio
    {
        public List<Horario> Get()
        {
            List<Horario> horarios = new List<Horario>();
            AccesoDatos accesoDatos = new AccesoDatos();
            MedicoNegocio medicoNegocio = new MedicoNegocio();

            try
            {
                accesoDatos.setearConsulta(@"SELECT H.ID, H.Hora_Inicio, H.Hora_Fin, H.Dia, H.IDMedico
                                            FROM Horario H 
                                            INNER JOIN Medico M ON H.IDMedico = M.ID
                                            ORDER BY M.Apellido, M.Nombre, H.Dia, H.Hora_Inicio, H.Hora_Fin");

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Horario obj = new Horario();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Hora_Inicio = (TimeSpan)accesoDatos.Lector["Hora_Inicio"];
                    obj.Hora_Fin = (TimeSpan)accesoDatos.Lector["Hora_Fin"];
                    obj.Dia = (Dia)accesoDatos.Lector["Dia"];
                    obj.Medico = medicoNegocio.Get(int.Parse(accesoDatos.Lector["IDMedico"].ToString()));
                    horarios.Add(obj);
                }
                return horarios;
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
        public Horario Get(int id)
        {
            Horario obj = new Horario();
            AccesoDatos accesoDatos = new AccesoDatos();
            MedicoNegocio medicoNegocio = new MedicoNegocio();

            try
            {
                accesoDatos.setearConsulta(@"SELECT ID, Hora_Inicio, Hora_Fin, Dia, IDMedico FROM Horario WHERE ID = @id");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();

                accesoDatos.Lector.Read();
                obj.Id = (int)accesoDatos.Lector["Id"];
                obj.Hora_Inicio = (TimeSpan)accesoDatos.Lector["Hora_Inicio"];
                obj.Hora_Fin = (TimeSpan)accesoDatos.Lector["Hora_Fin"];
                obj.Dia = (Dia)accesoDatos.Lector["Dia"];
                obj.Medico = medicoNegocio.Get(int.Parse(accesoDatos.Lector["IDMedico"].ToString()));

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
        public void Save(Horario obj)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                if(obj.Id > 0)
                {
                    accesoDatos.setearConsulta("UPDATE Horario set Hora_Inicio = @desde, Hora_Fin = @hasta, Dia = @dia, IDMedico = @idMedico WHERE ID = @id");
                    accesoDatos.setearParametro("@id", obj.Id);
                }
                else
                {
                    accesoDatos.setearConsulta("INSERT INTO Horario values (@desde, @hasta, @dia, @idMedico);");
                }
                accesoDatos.setearParametro("@desde", obj.Hora_Inicio);
                accesoDatos.setearParametro("@hasta", obj.Hora_Fin);
                accesoDatos.setearParametro("@dia", obj.Dia);
                accesoDatos.setearParametro("@idMedico", obj.Medico.Id);
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
        public void Delete(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("DELETE Horario WHERE ID = @id");
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


        public List<Horario> Get(Dia? dia, TimeSpan? desde, TimeSpan? hasta)
        {
            List<Horario> horarios = new List<Horario>();
            AccesoDatos accesoDatos = new AccesoDatos();
            MedicoNegocio medicoNegocio = new MedicoNegocio();

            try
            {
                accesoDatos.setearProcedimiento(@"HorariosGet");
                accesoDatos.setearParametro("@desde", desde);
                accesoDatos.setearParametro("@hasta", hasta);
                accesoDatos.setearParametro("@dia", dia);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Horario obj = new Horario();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Hora_Inicio = (TimeSpan)accesoDatos.Lector["Hora_Inicio"];
                    obj.Hora_Fin = (TimeSpan)accesoDatos.Lector["Hora_Fin"];
                    obj.Dia = (Dia)accesoDatos.Lector["Dia"];
                    obj.Medico = medicoNegocio.Get(int.Parse(accesoDatos.Lector["IDMedico"].ToString()));
                    horarios.Add(obj);
                }
                return horarios;
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

        public List<Horario> obtenerHorarioPorMedico(int idMedico)
        {

            AccesoDatos accesoDatos = new AccesoDatos();
            List<Horario> horarios = new List<Horario>();
            try
            {
                accesoDatos.setearConsulta("select ID, Dia, Hora_Inicio, Hora_Fin from Horario where IDMedico = @Id");
                accesoDatos.setearParametro("@id", idMedico);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Horario aux = new Horario();
                    aux.Id = (int)accesoDatos.Lector["ID"];
                    aux.Dia = (Dia)(int)accesoDatos.Lector["Dia"];
                    aux.Hora_Inicio = (TimeSpan)accesoDatos.Lector["Hora_Inicio"];
                    aux.Hora_Fin = (TimeSpan)accesoDatos.Lector["Hora_Fin"];

                    horarios.Add(aux);
                }

                return horarios;
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
