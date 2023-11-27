using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Gestion_Turnos
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios { get; set; }

        UsuarioNegocio negocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.isAdmin(Session["usuario"]))
            {
                Session.Add("error", "Necesita permisos de administrador para ver esta página.");
                Response.Redirect("Error.aspx", false);
            }

            PerfilAccesoNegocio negocioPerfilAcceso = new PerfilAccesoNegocio();
            ListaUsuarios = negocio.listar(true);
            if (!IsPostBack)
            {
                grdUsuarios.DataSource = ListaUsuarios;
                grdUsuarios.DataBind();
                cmbPerfilAcceso.DataSource = negocioPerfilAcceso.listar();
                cmbPerfilAcceso.DataTextField = "Descripcion";
                cmbPerfilAcceso.DataValueField = "Id";
                cmbPerfilAcceso.DataBind();
                cmbPerfilAcceso.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                cmbPerfilAcceso.SelectedIndex = 0;
            }
        }
        protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdUsuarios.SelectedDataKey.Value.ToString();
            Response.Redirect("UsuarioView.aspx?id=" + id, false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre_usuario = txtNombre_Usuario.Text;
            int indiceSeleccionado = cmbPerfilAcceso.SelectedIndex;
            string valorSeleccionado;
            if (indiceSeleccionado >= 0)
                valorSeleccionado = cmbPerfilAcceso.Items[indiceSeleccionado].Value;
            else
                valorSeleccionado = "";
            if (nombre_usuario != "" || valorSeleccionado != "")
                grdUsuarios.DataSource = negocio.listarFiltrado(nombre_usuario, valorSeleccionado, true);
            else
            {
                grdUsuarios.DataSource = null;
                grdUsuarios.DataSource = ListaUsuarios;
            }
            grdUsuarios.DataBind();
        }

        protected void grdUsuarios_DataBound(object sender, EventArgs e)
        {
            foreach ( GridViewRow row in grdUsuarios.Rows)
            {
                CheckBox chk = row.Cells[3].Controls[0] as CheckBox;

                if (!chk.Checked)
                {
                    for (int i=0;  i < row.Cells.Count-1; i++)
                    {
                        row.Cells[i].ForeColor = Color.Red;
                    }
                }
            }

        }
    }
}