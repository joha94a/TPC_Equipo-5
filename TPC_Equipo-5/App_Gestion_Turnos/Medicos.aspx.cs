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
    public partial class Medicos : System.Web.UI.Page
    {
        public List<Medico> ListaMedicos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.isAdmin(Session["usuario"]))
            {
                Session.Add("error", "Necesita permisos de administrador para ver esta página.");
                Response.Redirect("Error.aspx", false);
            }
            string filtro = Request.QueryString["filtro"];
            MedicoNegocio negocio = new MedicoNegocio();

            ListaMedicos = negocio.listarMedicos();
            grdMedicos.DataSource = ListaMedicos;
            grdMedicos.DataBind();

            if (!IsPostBack && !string.IsNullOrEmpty(filtro))
            {
                ListaMedicos = negocio.listarMedicoFiltrado(filtro);
                txtFiltro.Text = filtro;
            }
            else
            {
                ListaMedicos = negocio.listarMedicos();
            }

            if (!IsPostBack)
            {
                //repMedicos.DataSource = ListaMedicos;
                //repMedicos.DataBind();
            }
        }

        protected void grdMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdMedicos.SelectedDataKey.Value.ToString();
            Response.Redirect("MedicoView.aspx?id=" + id, false);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            if (!string.IsNullOrEmpty(filtro))
            {
                Response.Redirect("Medicos.aspx?filtro=" + filtro, false);
            }
            else
            {
                Response.Redirect("Medicos.aspx", false);
            }
        }

        protected string GetEspecialidadesDescription(object especialidades)
        {
            if (especialidades != null)
            {
                var especialidadesList = especialidades as List<Especialidad>; 

                if (especialidadesList != null && especialidadesList.Any())
                {
                    return string.Join(", ", especialidadesList.Select(e => e.Descripcion));
                }
            }

            return "Sin especialidad";
        }

    }
}