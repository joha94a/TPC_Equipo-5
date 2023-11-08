using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            AccesoDatos accesoDatos = new AccesoDatos();
            PerfilAccesoNegocio perfilAccesoNegocio = new PerfilAccesoNegocio();

            try
            {
                accesoDatos.setearConsulta("SELECT ID, Nombre_Usuario, Contrasena, PerfilAccesoID, MedicoID, Activo FROM Usuario WHERE Activo = 1;");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)accesoDatos.Lector["ID"];
                    aux.Nombre_Usuario = (string)accesoDatos.Lector["Nombre_Usuario"];
                    aux.Contrasena = (string)accesoDatos.Lector["Contrasena"];
                    if (!(accesoDatos.Lector["PerfilAccesoID"] is DBNull))
                    {
                        aux.PerfilAcceso = perfilAccesoNegocio.obtener((int)accesoDatos.Lector["PerfilAccesoID"]);
                    }
                    if (!(accesoDatos.Lector["MedicoID"] is DBNull))
                    {
                        // TODO: Traer Medico usando PerfilAccesoNegocio
                        // aux.Medico = 
                    }
                    aux.Activo = (bool)accesoDatos.Lector["Activo"];

                    usuarios.Add(aux);
                }

                return usuarios;
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

        public void agregar(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO Usuario VALUES (@Nombre_Usuario, @PerfilAccesoId, @MedicoId, 1);");
                accesoDatos.setearParametro("@Nombre_Usuario", usuario.Nombre_Usuario);
                accesoDatos.setearParametro("@PerfilAccesoId", usuario.PerfilAcceso.Id);
                accesoDatos.setearParametro("@MedicoId", usuario.Medico.Id);
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

        public void modificar(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("UPDATE Usuario SET Nombre_Usuario = @Nombre_Usuario, PerfilAccesoId = @PerfilAccesoId, MedicoId = @MedicoId WHERE ID = @Id");
                accesoDatos.setearParametro("@Id", usuario.Id);
                accesoDatos.setearParametro("@Nombre_Usuario", usuario.Nombre_Usuario);
                accesoDatos.setearParametro("@PerfilAccesoId", usuario.PerfilAcceso.Id);
                accesoDatos.setearParametro("@MedicoId", usuario.Medico.Id);
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

        public void baja(int id)
        {

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("UPDATE Usuario SET Activo = 0 WHERE ID = @Id");
                accesoDatos.setearParametro("@Id", id);
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

        public List<Usuario> listarFiltrado(string filtro)
        {
            List<Usuario> usuarios = new List<Usuario>();
            AccesoDatos accesoDatos = new AccesoDatos();
            PerfilAccesoNegocio perfilAccesoNegocio = new PerfilAccesoNegocio();

            try
            {
                accesoDatos.setearConsulta("SELECT ID, Nombre_Usuario, Contrasena, PerfilAccesoID, MedicoID, Activo FROM Usuario WHERE Activo = 1 AND UPPER(Nombre_Usuario) LIKE @filtro;");
                accesoDatos.setearParametro("@filtro", "%" + filtro.ToUpper() + "%");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)accesoDatos.Lector["ID"];
                    aux.Nombre_Usuario = (string)accesoDatos.Lector["Nombre_Usuario"];
                    aux.Contrasena = (string)accesoDatos.Lector["Contrasena"];
                    if (!(accesoDatos.Lector["PerfilAccesoID"] is DBNull))
                    {
                        aux.PerfilAcceso = perfilAccesoNegocio.obtener((int)accesoDatos.Lector["PerfilAccesoID"]);
                    }
                    if (!(accesoDatos.Lector["MedicoID"] is DBNull))
                    {
                        // TODO: Traer Medico usando PerfilAccesoNegocio
                        // aux.Medico = 
                    }
                    aux.Activo = (bool)accesoDatos.Lector["Activo"];

                    usuarios.Add(aux);
                }

                return usuarios;
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
