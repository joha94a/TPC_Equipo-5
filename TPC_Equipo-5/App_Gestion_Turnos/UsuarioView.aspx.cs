using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Gestion_Turnos
{
    public partial class UsuarioView : System.Web.UI.Page
    {
        public int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = negocio.obtener(id);
                Id = usuario.Id;
                if (!IsPostBack)
                {
                    PerfilAccesoNegocio negocioPerfilAcceso = new PerfilAccesoNegocio();
                    txtNombre_Usuario.Value = usuario.Nombre_Usuario;
                    txtNombre_Usuario.Disabled = true;
                    if(usuario.Medico != null)
                        txtMedico.Value = usuario.Medico.Nombre;

                    cmbPerfilAcceso.DataSource = negocioPerfilAcceso.listar();
                    cmbPerfilAcceso.DataTextField = "Descripcion";
                    cmbPerfilAcceso.DataValueField = "Id";
                    cmbPerfilAcceso.DataBind();
                    cmbPerfilAcceso.Items.FindByValue(usuario.PerfilAcceso.Id.ToString()).Selected = true;
                    if (usuario.Id == 1)
                        cmbPerfilAcceso.Enabled = false;
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    PerfilAccesoNegocio negocioPerfilAcceso = new PerfilAccesoNegocio();
                    lblNuevaContrasena.Text = "Contraseña:";
                    lblRepNuevaContrasena.Text = "Repita contraseña:";
                    cmbPerfilAcceso.DataSource = negocioPerfilAcceso.listar();
                    cmbPerfilAcceso.DataTextField = "Descripcion";
                    cmbPerfilAcceso.DataValueField = "Id";
                    cmbPerfilAcceso.DataBind();
                    cmbPerfilAcceso.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    cmbPerfilAcceso.SelectedIndex = 0;
                }
            }
        }

        protected void btnMedico_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PerfilAccesoNegocio negocioPerfilAcceso = new PerfilAccesoNegocio();
            MedicoNegocio medicoNegocio = new MedicoNegocio();

            // Insert
            if (Id == 0) 
            {
                usuario.Id = 0;
                usuario.Nombre_Usuario = txtNombre_Usuario.Value;
                // ToDo: Validar nombre usuario
                if (txtNuevaContrasena.Value == txtRepNuevaContrasena.Value && txtNuevaContrasena.Value != "")
                    usuario.Contrasena = txtNuevaContrasena.Value;
                else
                {
                    // ToDo: Validación contraseña
                }
                int idPerfilAcceso = int.Parse(cmbPerfilAcceso.SelectedItem.Value);
                if (idPerfilAcceso == 0)
                {
                    // ToDo: Validación perfil acceso
                }
                usuario.PerfilAcceso = negocioPerfilAcceso.obtener(idPerfilAcceso);
                // ToDo: Médico
                usuarioNegocio.agregar(usuario);
            }
            // Update
            else
            {
                usuario.Id = Id;
                // ToDo: Validación contraseña vieja correcta
                if (txtNuevaContrasena.Value == txtRepNuevaContrasena.Value && txtNuevaContrasena.Value != "")
                    usuario.Contrasena = txtNuevaContrasena.Value;
                else
                {
                    // ToDo: Validación contraseña
                }
                int idPerfilAcceso = int.Parse(cmbPerfilAcceso.SelectedItem.Value);
                usuario.PerfilAcceso = negocioPerfilAcceso.obtener(idPerfilAcceso);
                // ToDo: Médico
                usuarioNegocio.modificar(usuario);
            }
            Response.Redirect("Usuarios.aspx", false);
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

        }
    }
}