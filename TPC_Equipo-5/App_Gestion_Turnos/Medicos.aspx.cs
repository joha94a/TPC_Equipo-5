using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Gestion_Turnos
{
    public partial class Medicos : System.Web.UI.Page
    {
        public List<Medico> ListaMedicos { get; set; }
        MedicoNegocio negocio = new MedicoNegocio();
        EspecialidadNegocio negocioEsp = new EspecialidadNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.isAdmin(Session["usuario"]))
            {
                Session.Add("error", "Necesita permisos de administrador para ver esta página.");
                Response.Redirect("Error.aspx", false);
            }

            try
            {
                if (!IsPostBack)
                {
                    ddlEspecialidad.DataSource = negocioEsp.Get();
                    ddlEspecialidad.DataBind();
                    ListaMedicos = negocio.listarMedicos();
                    grdMedicos.DataSource = ListaMedicos;
                    grdMedicos.DataBind();
                    ddlEspecialidad.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddlEspecialidad.SelectedIndex = 0;
                }
            }
            catch
            {
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void grdMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdMedicos.SelectedDataKey.Value.ToString();
            Response.Redirect("MedicoView.aspx?id=" + id, false);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            string mail = txtMail.Value;
            string especialidad = ddlEspecialidad.SelectedItem.ToString();
            try
            {
                grdMedicos.DataSource = negocio.listarMedicoFiltrado(nombre, apellido, mail, especialidad);
                grdMedicos.DataBind();
            }
            catch
            {
                Response.Redirect("Error.aspx", false);
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