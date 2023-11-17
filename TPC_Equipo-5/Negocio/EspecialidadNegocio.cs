using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> Get()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta(@"SELECT ID, Codigo, Descripcion FROM Especialidad");

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Especialidad obj = new Especialidad();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Codigo = (string)accesoDatos.Lector["Codigo"];
                    obj.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    especialidades.Add(obj);
                }
                return especialidades;
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
        public List<Especialidad> Get(string cod, string desc)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta(@"SELECT ID, Codigo, Descripcion FROM Especialidad 
                                            WHERE Codigo LIKE '%' + @cod + '%' AND Descripcion LIKE '%'+ @desc +'%'");
                accesoDatos.setearParametro("@cod", cod);
                accesoDatos.setearParametro("@desc", desc);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Especialidad obj = new Especialidad();
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Codigo = (string)accesoDatos.Lector["Codigo"];
                    obj.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    especialidades.Add(obj);
                }
                return especialidades;
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
        public Especialidad Get(string cod, int id)
        {
            Especialidad obj = new Especialidad();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta(@"SELECT ID, Codigo, Descripcion FROM Especialidad WHERE Codigo = @cod AND Id != @id");
                accesoDatos.setearParametro("@cod", cod);
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    obj.Id = (int)accesoDatos.Lector["Id"];
                    obj.Codigo = (string)accesoDatos.Lector["Codigo"];
                    obj.Descripcion = (string)accesoDatos.Lector["Descripcion"];
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
        public Especialidad Get(int id)
        {
            Especialidad obj = new Especialidad();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"SELECT ID, Codigo, Descripcion FROM Especialidad WHERE ID = @id");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();

                accesoDatos.Lector.Read();
                obj.Id = (int)accesoDatos.Lector["Id"];
                obj.Codigo = (string)accesoDatos.Lector["Codigo"];
                obj.Descripcion = (string)accesoDatos.Lector["Descripcion"];

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
        public void Save(Especialidad obj)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                if (obj.Id > 0)
                {
                    accesoDatos.setearConsulta("UPDATE Especialidad set Codigo = @codigo, Descripcion = @descripcion WHERE ID = @id");
                    accesoDatos.setearParametro("@id", obj.Id);
                }
                else
                {
                    accesoDatos.setearConsulta("INSERT INTO Especialidad values (@codigo, @Descripcion);");
                }
                accesoDatos.setearParametro("@codigo", obj.Codigo);
                accesoDatos.setearParametro("@Descripcion", obj.Descripcion);
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
                accesoDatos.setearConsulta("DELETE Especialidad WHERE ID = @id");
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

        public List<Especialidad> obtenerEspPorMedico(int idMedico) {

            AccesoDatos accesoDatos = new AccesoDatos();
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                accesoDatos.setearConsulta("select e.ID, e.Codigo, e.Descripcion from Medico_Especialidad me inner join Especialidad e on me.IDEspecialidad = e.ID where me.IDMedico = @id");
                accesoDatos.setearParametro("@id", idMedico);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Id = (int)accesoDatos.Lector["ID"];
                    aux.Codigo = (string)accesoDatos.Lector["Codigo"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                   
                    especialidades.Add(aux);
                }

                return especialidades;
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
