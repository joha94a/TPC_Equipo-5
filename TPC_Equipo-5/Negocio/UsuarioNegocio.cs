using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
                accesoDatos.setearConsulta("SELECT ID, Nombre_Usuario, PerfilAccesoID, MedicoID, Activo FROM Usuario WHERE Activo = 1;");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)accesoDatos.Lector["ID"];
                    aux.Nombre_Usuario = (string)accesoDatos.Lector["Nombre_Usuario"];
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
                accesoDatos.setearConsulta("INSERT INTO Usuario VALUES (@Nombre_Usuario, @Contrasena, @PerfilAccesoId, @MedicoId, 1);");
                accesoDatos.setearParametro("@Nombre_Usuario", usuario.Nombre_Usuario);
                accesoDatos.setearParametro("@Contrasena", usuario.Contrasena);
                accesoDatos.setearParametro("@PerfilAccesoId", usuario.PerfilAcceso.Id);
                accesoDatos.setearParametro("@MedicoId", usuario.Medico != null ? usuario.Medico.Id : (object)DBNull.Value);
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
                if (usuario.Contrasena != null)
                {
                    accesoDatos.setearConsulta("UPDATE Usuario SET Contrasena = @Contrasena, PerfilAccesoId = @PerfilAccesoId, MedicoId = @MedicoId WHERE ID = @Id");
                    accesoDatos.setearParametro("@Contrasena", usuario.Contrasena);
                }
                else
                    accesoDatos.setearConsulta("UPDATE Usuario SET PerfilAccesoId = @PerfilAccesoId, MedicoId = @MedicoId WHERE ID = @Id");
                accesoDatos.setearParametro("@Id", usuario.Id);
                accesoDatos.setearParametro("@PerfilAccesoId", usuario.PerfilAcceso.Id);
                accesoDatos.setearParametro("@MedicoId", usuario.Medico != null ? usuario.Medico.Id : (object)DBNull.Value);
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

        public List<Usuario> listarFiltrado(string filtroNombre, string perfilAccesoId)
        {
            List<Usuario> usuarios = new List<Usuario>();
            AccesoDatos accesoDatos = new AccesoDatos();
            PerfilAccesoNegocio perfilAccesoNegocio = new PerfilAccesoNegocio();

            try
            {
                string consulta = "SELECT ID, Nombre_Usuario, PerfilAccesoID, MedicoID, Activo FROM Usuario WHERE Activo = 1";
                if (filtroNombre != "")
                    consulta += " AND UPPER(Nombre_Usuario) LIKE @filtroNombre";
                if (perfilAccesoId != "")
                    consulta += " AND PerfilAccesoID = @perfilAccesoId";
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@filtroNombre", "%" + filtroNombre.ToUpper() + "%");
                accesoDatos.setearParametro("@perfilAccesoId", perfilAccesoId);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)accesoDatos.Lector["ID"];
                    aux.Nombre_Usuario = (string)accesoDatos.Lector["Nombre_Usuario"];
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

        public Usuario obtener(int id)
        {
            Usuario usuario = new Usuario();
            AccesoDatos accesoDatos = new AccesoDatos();
            PerfilAccesoNegocio perfilAccesoNegocio = new PerfilAccesoNegocio();

            try
            {
                accesoDatos.setearConsulta("SELECT Nombre_Usuario, PerfilAccesoID, MedicoID, Activo FROM Usuario WHERE ID = @id;");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    usuario.Id = id;
                    usuario.Nombre_Usuario = (string)accesoDatos.Lector["Nombre_Usuario"];
                    if (!(accesoDatos.Lector["PerfilAccesoID"] is DBNull))
                    {
                        usuario.PerfilAcceso = perfilAccesoNegocio.obtener((int)accesoDatos.Lector["PerfilAccesoID"]);
                    }
                    if (!(accesoDatos.Lector["MedicoID"] is DBNull))
                    {
                        // TODO: Traer Medico usando PerfilAccesoNegocio
                        // aux.Medico = 
                    }
                    usuario.Activo = (bool)accesoDatos.Lector["Activo"];
                }

                return usuario;
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

        public bool existeUsuario(string nombreUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id FROM Usuario WHERE UPPER(Nombre_Usuario) = @nombreUsuario;");
                datos.setearParametro("@nombreUsuario", nombreUsuario.ToUpper());
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool passValida(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id FROM Usuario WHERE ID = @id AND Contrasena = @contrasena;");
                datos.setearParametro("@id", usuario.Id);
                datos.setearParametro("@contrasena", usuario.Contrasena);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
