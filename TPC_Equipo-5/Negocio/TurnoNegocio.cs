using Dominio;
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
        public List<Turno> GetParaBuscador()
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
	                                            INNER JOIN Paciente p ON p.Id = t.PacienteID");
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

        public object ListarBuscador(DateTime? fechaDesde, DateTime? fechaHasta, int estado)
        {
            List<Turno> objs = new List<Turno>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearProcedimiento("TurnosBuscadorGet");
                accesoDatos.setearParametro("@fechaDesde", fechaDesde);
                accesoDatos.setearParametro("@fechaHasta", fechaHasta);
                accesoDatos.setearParametro("@estado", estado);
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
    }
}
