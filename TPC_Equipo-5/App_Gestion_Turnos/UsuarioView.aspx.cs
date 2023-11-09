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
                Id = Convert.ToInt32(Request.QueryString["id"]);
                if (!IsPostBack)
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = negocio.obtener(Id);
                    PerfilAccesoNegocio negocioPerfilAcceso = new PerfilAccesoNegocio();

                    txtNombre_Usuario.Value = usuario.Nombre_Usuario;
                    if(usuario.Medico != null)
                        txtMedico.Value = usuario.Medico.Nombre;
                    cmbPerfilAcceso.DataSource = negocioPerfilAcceso.listar();
                    cmbPerfilAcceso.DataTextField = "Descripcion";
                    cmbPerfilAcceso.DataValueField = "Id";
                    cmbPerfilAcceso.DataBind();
                    cmbPerfilAcceso.Items.FindByValue(usuario.PerfilAcceso.Id.ToString()).Selected = true;
                }
            }
        }

        protected void btnMedico_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

        }
    }
}