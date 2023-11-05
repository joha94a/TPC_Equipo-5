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
    public partial class HorarioView : System.Web.UI.Page
    {
        public int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);
                if(!IsPostBack)
                {
                    HorarioNegocio negocio = new HorarioNegocio();
                    Horario obj = negocio.Get(Id);
                    cmbDia.Value = Convert.ToInt32(obj.Dia).ToString();
                    cmbHoraDesde.Value = obj.Hora_Inicio.Hours.ToString();
                    cmbMinutosDesde.Value = obj.Hora_Inicio.Minutes.ToString();

                    cmbHoraHasta.Value = obj.Hora_Fin.Hours.ToString();
                    cmbMinutosHasta.Value = obj.Hora_Fin.Minutes.ToString();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Dia dia = (Dia)Convert.ToInt32(cmbDia.Value);
            int horaDesde = Convert.ToInt32(cmbHoraDesde.Value);
            int minutosDesde = Convert.ToInt32(cmbMinutosDesde.Value);
            int horaHasta = Convert.ToInt32(cmbHoraHasta.Value);
            int minutosHasta = Convert.ToInt32(cmbMinutosHasta.Value);

            TimeSpan horaInicio = new TimeSpan(horaDesde, minutosDesde, 0);
            TimeSpan horaFin = new TimeSpan(horaHasta, minutosHasta, 0);

            Horario obj = new Horario();
            obj.Id = Id;
            obj.Dia = dia;
            obj.Hora_Inicio = horaInicio;
            obj.Hora_Fin = horaFin;
            HorarioNegocio negocio = new HorarioNegocio();
            negocio.Save(obj);

            Response.Redirect("Horarios.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(Request.QueryString["id"]);

            HorarioNegocio negocio = new HorarioNegocio();
            negocio.Delete(Id);
            Response.Redirect("Horarios.aspx", false);
        }
    }
}