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
    public partial class Horarios : System.Web.UI.Page
    {
        public List<Horario> ListaHorarios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            HorarioNegocio negocio = new HorarioNegocio();
            ListaHorarios = negocio.Get();
            grdHorarios.DataSource = ListaHorarios;
            grdHorarios.DataBind();
        }

        protected void grdHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdHorarios.SelectedDataKey.Value.ToString();
            Response.Redirect("HorarioView.aspx?id=" + id, false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Dia? dia = null; 
            if(cmbDia.Value != "") dia = (Dia)Convert.ToInt32(cmbDia.Value);

            int? horaDesde = null;
            int? minutosDesde = null;
            int? horaHasta = null;
            int? minutosHasta = null;

            if(cmbHoraDesde.Value.Length > 0 || cmbMinutosDesde.Value.Length > 0)
            {
                horaDesde = cmbHoraDesde.Value.Length > 0 ? Convert.ToInt32(cmbHoraDesde.Value) : 0;
                minutosDesde = cmbMinutosDesde.Value.Length > 0 ? Convert.ToInt32(cmbMinutosDesde.Value) : 0;
            }
            if (cmbHoraHasta.Value.Length > 0 || cmbMinutosHasta.Value.Length > 0)
            {
                horaHasta = cmbHoraHasta.Value.Length > 0 ? Convert.ToInt32(cmbHoraHasta.Value) : 0;
                minutosHasta = cmbMinutosHasta.Value.Length > 0 ? Convert.ToInt32(cmbMinutosHasta.Value) : 0;
            }

            TimeSpan? horaInicio = null;
            TimeSpan? horaFin = null;

            if (horaDesde != null)
            {
                horaInicio = new TimeSpan(horaDesde.Value, minutosDesde.Value, 0);
            }
            if (horaHasta != null)
            {
                horaFin = new TimeSpan(horaHasta.Value, horaHasta.Value, 0);
            }

            HorarioNegocio negocio = new HorarioNegocio();
            
            grdHorarios.DataSource = negocio.Get(dia, horaInicio, horaFin);
            grdHorarios.DataBind();
        }
    }
}