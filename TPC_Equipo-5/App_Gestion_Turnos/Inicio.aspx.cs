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
    public partial class Inicio : System.Web.UI.Page
    {
        public List<Turno> ListaTurnos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            ListaTurnos = negocio.GetActivosUrgente();
            grdTurnos.DataSource = ListaTurnos;
            grdTurnos.DataBind();
        }

        protected void grdTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdTurnos.SelectedDataKey.Value.ToString();
            Response.Redirect("TurnoView.aspx?id=" + id, false);
        }
    }
}