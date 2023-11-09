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
    public partial class Pacientes : System.Web.UI.Page
    {
        public List<Paciente> ListaPacientes { get; set; }
        PacienteNegocio negocio = new PacienteNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListaPacientes = negocio.listarPacientes();
            grdPacientes.DataSource = ListaPacientes;
            grdPacientes.DataBind();

            /*
            string filtro = Request.QueryString["filtro"];

            if (!IsPostBack && !string.IsNullOrEmpty(filtro))
            {
                ListaPacientes = negocio.listarPacientesFiltrado(filtro);
                txtFiltro.Text = filtro;
            }
            else
            {
                ListaPacientes = negocio.listarPacientes();
            }

            if (!IsPostBack)
            {
                repPacientes.DataSource = ListaPacientes;
                repPacientes.DataBind();
            }
            */
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            if (!string.IsNullOrEmpty(filtro))
            {
                Response.Redirect("Pacientes.aspx?filtro=" + filtro, false);
            }
            else
            {
                Response.Redirect("Pacientes.aspx", false);
            }
        }

        protected void grdPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdPacientes.SelectedDataKey.Value.ToString();
            Response.Redirect("PacienteView.aspx?id=" + id, false);
        }
    }
}