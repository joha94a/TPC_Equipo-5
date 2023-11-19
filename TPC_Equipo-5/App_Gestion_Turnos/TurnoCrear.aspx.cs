using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace App_Gestion_Turnos
{
    public partial class TurnoCrear : System.Web.UI.Page
    {
        public Paciente Paciente = new Paciente();
        public IList<Especialidad> EspecialidadesLista = new List<Especialidad>();
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

            if(!IsPostBack)
            {
                EspecialidadesLista = especialidadNegocio.Get();
                cmbEspecialidad.DataSource = EspecialidadesLista;
                cmbEspecialidad.DataTextField = "Descripcion";
                cmbEspecialidad.DataValueField = "Id";
                cmbEspecialidad.DataBind();
            }
            else
            {
                PacienteNegocio negocio = new PacienteNegocio();
                int documento = Convert.ToInt32(txtDNI.Value);
                Paciente = negocio.GetPorDNI(documento);
            }
            if (Request.QueryString["doc"] != null)
            {
                PacienteNegocio negocio = new PacienteNegocio();
                string doc = Request.QueryString["doc"];
                txtDNI.Value = doc;
                Paciente = negocio.GetPorDNI(Convert.ToInt32(doc));
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();
            int documento = Convert.ToInt32(txtDNI.Value);

            Paciente = negocio.GetPorDNI(documento);
            if(Paciente.Id == 0)
            {
                Response.Redirect("PacienteView.aspx?doc=" + documento, false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int especialidadId = Convert.ToInt32(cmbEspecialidad.SelectedValue);
            Response.Redirect("CalendarioTurnosDisponibles.aspx?pId=" + Paciente.Id + "&eId=" + especialidadId, false);
        }
    }
}