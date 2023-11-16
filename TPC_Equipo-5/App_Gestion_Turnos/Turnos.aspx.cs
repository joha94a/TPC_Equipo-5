using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Gestion_Turnos
{
    public partial class Turnos : System.Web.UI.Page
    {
        public List<Turno> ListaTurnos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();

            ListaTurnos = negocio.GetParaBuscador();
            grdTurnos.DataSource = ListaTurnos;
            grdTurnos.DataBind();
        }

        protected void grdTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(!IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TurnoEstado estado = (TurnoEstado)Convert.ToInt32(e.Row.Cells[4].Text);
                    if (estado == TurnoEstado.Cancelado)
                    {
                        e.Row.BackColor = Color.FromName("Tomato");
                    }
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            int estado = Convert.ToInt32(cmbEstado.Value);
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;

            if (txtFechaDesde.Value.Length > 0) fechaDesde = Convert.ToDateTime(txtFechaDesde.Value);
            if (txtFechaHasta.Value.Length > 0) fechaHasta = Convert.ToDateTime(txtFechaHasta.Value);

            grdTurnos.DataSource = negocio.ListarBuscador(fechaDesde, fechaHasta, estado);
            grdTurnos.DataBind();
        }
    }
}