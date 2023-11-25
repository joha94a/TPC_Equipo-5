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
            if (!Seguridad.isRecep(Session["usuario"]) && !Seguridad.isAdmin(Session["usuario"]))
            {
                Session.Add("error", "No tiene permisos para ver esta página.");
                Response.Redirect("Error.aspx", false);
            }

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

            if(horaInicio == horaFin)
            {
                spnMensaje.InnerText = "El horario \"desde\" no puede ser igual al horario \"hasta\".";
            }
            else
            {

                Horario obj = new Horario();
                obj.Id = Id;
                obj.Dia = dia;
                obj.Hora_Inicio = horaInicio;
                obj.Hora_Fin = horaFin;

                HorarioNegocio negocio = new HorarioNegocio();
                negocio.Save(obj);

                Response.Redirect("Horarios.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(Request.QueryString["id"]);

            HorarioNegocio negocio = new HorarioNegocio();
            MedicoNegocio medicoNegocio = new MedicoNegocio();

            if (medicoNegocio.RelacionesDeHorarios(Id) > 0)
            {
                spnMensaje.InnerText = "El horario no se puede eliminar porque existe al menos un médico que lo posee.";
            }
            else
            {
                negocio.Delete(Id);
                Response.Redirect("Horarios.aspx", false);
            }
        }
    }
}