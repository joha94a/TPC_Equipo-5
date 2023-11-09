using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        }

        protected void grdPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdPacientes.SelectedDataKey.Value.ToString();
            Response.Redirect("PacienteView.aspx?id=" + id, false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Value;
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            DateTime? fechaNacimientoDesde = null;
            DateTime? fechaNacimientoHasta = null;

            if (txtFechaNacimientoDesde.Value.Length > 0) fechaNacimientoDesde = Convert.ToDateTime(txtFechaNacimientoDesde.Value);
            if (txtFechaNacimientoHasta.Value.Length > 0) fechaNacimientoHasta = Convert.ToDateTime(txtFechaNacimientoHasta.Value);

            
            grdPacientes.DataSource = negocio.listarPacientesFiltrado(dni, nombre, apellido, fechaNacimientoDesde, fechaNacimientoHasta);
            grdPacientes.DataBind();
        }
    }
}