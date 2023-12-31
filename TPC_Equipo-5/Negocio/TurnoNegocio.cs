﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio
{
    public class TurnoNegocio
    {
        public List<Turno> GetPorPacienteId(int pacienteId)
        {
            List<Turno> objs = new List<Turno>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"SELECT 
	                                            t.ID,
	                                            t.Fecha,
	                                            m.Apellido + ', ' + m.Nombre Medico,
	                                            p.Apellido + ', ' + p.Nombre Paciente,
	                                            t.Estado,
	                                            CASE
		                                            WHEN t.Estado = 1 THEN 'Activo'
		                                            WHEN t.Estado = 2 THEN 'Cancelado'
		                                            WHEN t.Estado = 3 THEN 'Completado'
		                                            WHEN t.Estado = 4 THEN 'Ausente'
		                                            ELSE ''
	                                            END EstadoStr
                                            FROM Turno t
	                                            INNER JOIN Medico m ON m.Id = t.MedicoID
	                                            INNER JOIN Paciente p ON p.Id = t.PacienteID
                                            WHERE p.Id = @pacienteId
                                            ORDER BY t.Fecha DESC");
                accesoDatos.setearParametro("@pacienteId", pacienteId);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Turno obj = new Turno();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Fecha = (DateTime)accesoDatos.Lector["Fecha"];
                    obj.MedicoStr = accesoDatos.Lector["Medico"].ToString();
                    obj.PacienteStr = accesoDatos.Lector["Paciente"].ToString();
                    obj.Estado = (TurnoEstado)accesoDatos.Lector["Estado"];
                    obj.EstadoStr = accesoDatos.Lector["EstadoStr"].ToString();
                    obj.EstadoValor = Convert.ToInt32(accesoDatos.Lector["Estado"].ToString());
                    objs.Add(obj);
                }
                return objs;
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

        public List<Turno> GetActivosUrgente()
        {
            List<Turno> objs = new List<Turno>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"SELECT 
	                                            t.ID, t.Fecha, 
	                                            m.Apellido + ', ' + m.Nombre Medico, 
	                                            p.Apellido + ', ' + p.Nombre Paciente, 
	                                            CASE
		                                            WHEN t.Estado = 1 THEN 'Activo'
		                                            WHEN t.Estado = 2 THEN 'Cancelado'
		                                            WHEN t.Estado = 3 THEN 'Completado'
		                                            WHEN t.Estado = 4 THEN 'Ausente'
		                                            ELSE ''
	                                            END EstadoStr, t.Estado 
                                            FROM Turno t
	                                            INNER JOIN Medico m ON m.Id = t.MedicoID
	                                            INNER JOIN Paciente p ON p.ID = t.PacienteID
                                            WHERE CAST(t.Fecha AS DATE) <= CAST(DATEADD(DAY, 1, GETDATE()) AS DATE)
                                            AND t.Estado = 1
                                            ORDER BY t.Fecha DESC");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Turno obj = new Turno();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Fecha = (DateTime)accesoDatos.Lector["Fecha"];
                    obj.MedicoStr = accesoDatos.Lector["Medico"].ToString();
                    obj.PacienteStr = accesoDatos.Lector["Paciente"].ToString();
                    obj.Estado = (TurnoEstado)accesoDatos.Lector["Estado"];
                    obj.EstadoStr = accesoDatos.Lector["EstadoStr"].ToString();
                    obj.EstadoValor = Convert.ToInt32(accesoDatos.Lector["Estado"].ToString());
                    objs.Add(obj);
                }
                return objs;
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

        public List<TurnoDisponibleCalendario> TurnoDisponibleCalendarioGet(int especialidadId)
        {
            List<TurnoDisponibleCalendario> objs = new List<TurnoDisponibleCalendario>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearProcedimiento(@"CalendarioTurnosDisponiblesGet");
                accesoDatos.setearParametro("@especialidadId", especialidadId);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    TurnoDisponibleCalendario obj = new TurnoDisponibleCalendario();
                    obj.Id = Convert.ToInt32(accesoDatos.Lector["Id"]);
                    obj.MedicoId = Convert.ToInt32(accesoDatos.Lector["MedicoId"]);
                    obj.MedicoStr = accesoDatos.Lector["MedicoStr"].ToString();
                    obj.Fecha = (DateTime)accesoDatos.Lector["FechaHora"];
                    obj.Hora = (TimeSpan)accesoDatos.Lector["HoraDesde"];
                    objs.Add(obj);
                }
                return objs;
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

        public List<Turno> ListarBuscador(DateTime? fechaDesde, DateTime? fechaHasta, int estado, Medico medico = null)
        {
            List<Turno> objs = new List<Turno>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearProcedimiento("TurnosBuscadorGet");
                accesoDatos.setearParametro("@fechaDesde", fechaDesde);
                accesoDatos.setearParametro("@fechaHasta", fechaHasta);
                accesoDatos.setearParametro("@estado", estado);
                if (medico != null)
                    accesoDatos.setearParametro("@idMedico", medico.Id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Turno obj = new Turno();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Fecha = (DateTime)accesoDatos.Lector["Fecha"];
                    obj.MedicoStr = accesoDatos.Lector["Medico"].ToString();
                    obj.PacienteStr = accesoDatos.Lector["Paciente"].ToString();
                    obj.Estado = (TurnoEstado)accesoDatos.Lector["Estado"];
                    obj.EstadoStr = accesoDatos.Lector["EstadoStr"].ToString();
                    obj.EstadoValor = Convert.ToInt32(accesoDatos.Lector["Estado"].ToString());
                    objs.Add(obj);
                }
                return objs;
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

        public void Guardar(Turno obj)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                if (obj.Id > 0)
                {
                    accesoDatos.setearConsulta(@"UPDATE Turno SET Fecha = @fecha, MedicoID = @medicoId, PacienteID = @pacienteId, Observaciones = @observaciones, Estado = @estado, EspecialidadID = @especialidadId WHERE ID = @id");
                    accesoDatos.setearParametro("@id", obj.Id);
                }
                else
                {
                    accesoDatos.setearConsulta("INSERT INTO Turno VALUES (@fecha, @medicoId, @pacienteId, @observaciones, @estado, @especialidadId)");
                }
                accesoDatos.setearParametro("@fecha", obj.Fecha);
                accesoDatos.setearParametro("@medicoId", obj.Medico.Id);
                accesoDatos.setearParametro("@pacienteId", obj.Paciente.Id);
                accesoDatos.setearParametro("@observaciones", obj.Observaciones);
                accesoDatos.setearParametro("@estado", obj.Estado);
                accesoDatos.setearParametro("@especialidadId", obj.Especialidad.Id);

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

        public Turno Get(int id)
        {
            Turno obj = new Turno();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta(@"SELECT * FROM Turno WHERE ID = @id");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    obj.Id = Convert.ToInt32(accesoDatos.Lector["Id"]);
                    obj.Fecha = (DateTime)accesoDatos.Lector["Fecha"];
                    obj.Medico = new MedicoNegocio().Get(Convert.ToInt32(accesoDatos.Lector["MedicoID"]));
                    obj.Paciente = new PacienteNegocio().Get(Convert.ToInt32(accesoDatos.Lector["PacienteID"]));
                    obj.Observaciones = accesoDatos.Lector["Observaciones"].ToString();
                    obj.Estado = (TurnoEstado)accesoDatos.Lector["Estado"];
                    obj.Especialidad = new EspecialidadNegocio().Get(Convert.ToInt32(accesoDatos.Lector["EspecialidadID"]));
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

        public List<Turno> TurnosPorMedico(int id)
        {
            List<Turno> turnosLista = new List<Turno>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT t.ID, t.Fecha, p.Apellido + ', ' + p.Nombre as Paciente, e.Descripcion as Especialidad," +
                    " CASE WHEN t.Estado = 1 THEN 'Activo' " +
                    "WHEN t.Estado = 2 THEN 'Cancelado' " +
                    "WHEN t.Estado = 3 THEN 'Completado' " +
                    "WHEN t.Estado = 4 THEN 'Ausente' " +
                    "ELSE '' " +
                    "END " +
                    "EstadoStr, t.Estado FROM Turno t " +
                    "INNER JOIN Medico m ON m.Id = t.MedicoID " +
                    "INNER JOIN Paciente p ON p.ID = t.PacienteID " +
                    "INNER JOIN Especialidad e on t.EspecialidadID = e.ID " +
                    "WHERE t.MedicoID = @idMedico AND t.Estado = 1 ORDER BY t.Fecha ASC");
                accesoDatos.setearParametro("@idMedico", id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Turno obj = new Turno();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Fecha = (DateTime)accesoDatos.Lector["Fecha"];
                    obj.PacienteStr = accesoDatos.Lector["Paciente"].ToString();
                    obj.Estado = (TurnoEstado)accesoDatos.Lector["Estado"];
                    obj.EstadoStr = accesoDatos.Lector["EstadoStr"].ToString();
                    obj.EstadoValor = Convert.ToInt32(accesoDatos.Lector["Estado"].ToString());
                    obj.EspecialidadStr = accesoDatos.Lector["Especialidad"].ToString();
                    turnosLista.Add(obj);
                }
                return turnosLista;
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
