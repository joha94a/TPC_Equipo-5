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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
                Response.Redirect("Inicio.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text.Trim() == "")
            {
                lblValidacionUsuario.InnerHtml = "Ingrese usuario.";
                lblValidacionPassword.InnerHtml = "";
            }
            else if (txtPassword.Text.Trim() == "")
            {
                lblValidacionUsuario.InnerHtml = "";
                lblValidacionPassword.InnerHtml = "Ingrese contraseña.";
            }
            else
            {
                try
                {
                    Usuario usuario = new Usuario();
                    UsuarioNegocio negocio = new UsuarioNegocio();

                    usuario.Nombre_Usuario = txtUsuario.Text.ToUpper();
                    usuario.Contrasena = txtPassword.Text;
                    int id = negocio.passValida(usuario);
                    if (id > 0)
                    {
                        usuario = negocio.obtener(id);
                        Session.Add("usuario", usuario);
                        Response.Redirect("Inicio.aspx", false);
                    }
                    else
                    {
                        lblValidacionUsuario.InnerHtml = "";
                        lblValidacionPassword.InnerHtml = "Usuario o contraseña incorrecta.";
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}