using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace App_Gestion_Turnos
{
    public partial class TurnoView : System.Web.UI.Page
    {
        public Turno Turno { get; set; }
        TurnoNegocio negocio = new TurnoNegocio();
        public bool VieneDePaciente { get; set; }
        public int PacienteId { get; set; }
        public int NivelAcceso { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                NivelAcceso = ((Usuario)Session["usuario"]).PerfilAcceso.Nivel_Acceso;
            }

            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                
                Turno = negocio.Get(id);
                PacienteId = Turno.Paciente.Id;
                if (!IsPostBack)
                {
                    txtObservaciones.Value = Turno.Observaciones;
                }
            }

            if (Request.QueryString["p"] != null && Request.QueryString["p"].ToLower() == "true")
            {
                VieneDePaciente = true;
            }
            else
            {
                VieneDePaciente = false;
            }
        }

        protected void btnAusente_Click(object sender, EventArgs e)
        {
            Turno.Estado = TurnoEstado.Ausente;
            negocio.Guardar(Turno);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Turno.Estado = TurnoEstado.Cancelado;
            negocio.Guardar(Turno);
        }

        protected void btnCompletado_Click(object sender, EventArgs e)
        {
            Turno.Estado = TurnoEstado.Completado;
            negocio.Guardar(Turno);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Turno.Observaciones = txtObservaciones.Value;
            negocio.Guardar(Turno);
        }
    }
}