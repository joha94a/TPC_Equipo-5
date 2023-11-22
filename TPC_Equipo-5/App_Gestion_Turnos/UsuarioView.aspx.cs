using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Gestion_Turnos
{
    public partial class UsuarioView : System.Web.UI.Page
    {
        public int Id { get; set; }
        public bool SeccionMedicoVisible { get; set; }

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
                    txtNombre_Usuario.Text = usuario.Nombre_Usuario;
                    txtNombre_Usuario.Enabled = false;
                    if(usuario.Medico != null)
                        txtMedico.Text = usuario.Medico.Nombre;

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
                    cmbPerfilAcceso.Items.Insert(0, new ListItem(String.Empty, "0"));
                    cmbPerfilAcceso.SelectedIndex = 0;
                }
            }
        }

        protected void btnMedico_Click(object sender, EventArgs e)
        {
            SeccionMedicoVisible = true;
            btnMedico.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PerfilAccesoNegocio negocioPerfilAcceso = new PerfilAccesoNegocio();
            MedicoNegocio medicoNegocio = new MedicoNegocio();

            usuario.Id = Id;
            if (validar(usuario))
            {
                return;
                // Insert
                if (Id == 0)
                {
                    usuarioNegocio.agregar(usuario);
                }
                // Update
                else
                {
                    usuarioNegocio.modificar(usuario);
                }
                Response.Redirect("Usuarios.aspx", false);
            }           
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

        }

        protected bool validar(Usuario usuario)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            bool valido = true;

            // Nuevo
            if (usuario.Id == 0)
            {
                // Nombre de usuario
                if (txtNombre_Usuario.Text.Trim() == "")
                {
                    valido = false;
                    txtNombre_Usuario.CssClass = "form-control is-invalid";
                    lblValidacionNombre_Usuario.InnerText = "Usuario requerido.";
                }
                else if (usuarioNegocio.existeUsuario(txtNombre_Usuario.Text.Trim()))
                {
                    valido = false;
                    txtNombre_Usuario.CssClass = "form-control is-invalid";
                    lblValidacionNombre_Usuario.InnerText = "Usuario ya existe.";
                }
                else
                {
                    txtNombre_Usuario.CssClass = "form-control is-valid";
                    lblValidacionNombre_Usuario.InnerText = "";
                    usuario.Nombre_Usuario = txtNombre_Usuario.Text.Trim();
                }

                // Contraseña
                if (txtNuevaContrasena.Text == "")
                {
                    valido = false;
                    txtNuevaContrasena.CssClass = "form-control is-invalid";
                    lblValidacionNuevaContrasena.InnerText = "Contraseña requerida.";
                }
                else if (txtNuevaContrasena.Text != txtRepNuevaContrasena.Text)
                {
                    valido = false;
                    txtNuevaContrasena.CssClass = "form-control";
                    lblValidacionNuevaContrasena.InnerText = "";
                    txtRepNuevaContrasena.CssClass = "form-control is-invalid";
                    lblValidacionRepNuevaContrasena.InnerText = "Contraseñas no coinciden.";
                }
                else
                {
                    txtNuevaContrasena.CssClass = "form-control";
                    lblValidacionNuevaContrasena.InnerText = "";
                    txtRepNuevaContrasena.CssClass = "form-control";
                    lblValidacionRepNuevaContrasena.InnerText = "";
                }

                // Perfil de acceso
                int idPerfilAcceso = int.Parse(cmbPerfilAcceso.SelectedItem.Value);
                if (idPerfilAcceso == 0)
                {
                    valido = false;
                    cmbPerfilAcceso.CssClass = "form-control is-invalid";
                    lblValidacionPerfilAcceso.InnerText = "Debe seleccionar un perfil.";
                }
                else
                {
                    usuario.PerfilAcceso = new PerfilAcceso();
                    usuario.PerfilAcceso.Id = idPerfilAcceso;
                    cmbPerfilAcceso.CssClass = "form-control is-valid";
                    lblValidacionPerfilAcceso.InnerText = "";
                }

                // ToDo: Médico

            }
            // Modificacion
            else
            {
                // Contraseña
                if (txtNuevaContrasena.Text != "" || txtRepNuevaContrasena.Text != "")
                {
                    if (txtNuevaContrasena.Text != txtRepNuevaContrasena.Text)
                    {
                        valido = false;
                        txtRepNuevaContrasena.CssClass = "form-control is-invalid";
                        lblValidacionNuevaContrasena.InnerText = "Contraseñas no coinciden.";
                    }
                    else
                    {
                        txtNuevaContrasena.CssClass = "form-control";
                        lblValidacionNuevaContrasena.InnerText = "";
                        txtRepNuevaContrasena.CssClass = "form-control";
                        lblValidacionRepNuevaContrasena.InnerText = "";
                        usuario.Contrasena = txtNuevaContrasena.Text;
                    }
                }

                // Perfil de acceso
                usuario.PerfilAcceso = new PerfilAcceso();
                usuario.PerfilAcceso.Id = int.Parse(cmbPerfilAcceso.SelectedItem.Value);

                // ToDo: Médico

            }
            return valido;
        }

        protected void cmbPerfilAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbPerfilAcceso.SelectedValue == null || cmbPerfilAcceso.SelectedValue != "1" )
            {
                SeccionMedicoVisible = false;
                btnMedico.Visible = true;
            }

            
        }
    }
}