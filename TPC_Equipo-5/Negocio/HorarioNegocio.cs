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

            try
            {
                accesoDatos.setearConsulta(@"SELECT ID, Hora_Inicio, Hora_Fin, Dia FROM Horario");

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Horario obj = new Horario();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Hora_Inicio = (TimeSpan)accesoDatos.Lector["Hora_Inicio"];
                    obj.Hora_Fin = (TimeSpan)accesoDatos.Lector["Hora_Fin"];
                    obj.Dia = (Dia)accesoDatos.Lector["Dia"];
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
    }
}
