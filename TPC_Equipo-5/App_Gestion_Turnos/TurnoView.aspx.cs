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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                
                Turno = negocio.Get(id);
                if (!IsPostBack)
                {
                    txtObservaciones.Value = Turno.Observaciones;
                }
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