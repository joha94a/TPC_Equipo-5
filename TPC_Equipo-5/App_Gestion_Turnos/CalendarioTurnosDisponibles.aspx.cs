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
    public partial class CalendarioTurnosDisponibles : System.Web.UI.Page
    {
        public List<TurnoDisponibleCalendario> ListaTurnos { get; set; }
        public int PacienteId { get; set; }
        TurnoNegocio negocio = new TurnoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            PacienteId = Convert.ToInt32(Request.QueryString["pId"]);
            int especialidadId = Convert.ToInt32(Request.QueryString["eId"]);


            ListaTurnos = negocio.TurnoDisponibleCalendarioGet(especialidadId);
            grdTurnos.DataSource = ListaTurnos;
            grdTurnos.DataBind();
        }

        protected void grdTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grdTurnos.SelectedDataKey.Value.ToString());
            TurnoDisponibleCalendario disponible = ListaTurnos.Where(t => t.Id == id).FirstOrDefault();
            Turno obj = new Turno();
            obj.Fecha = disponible.Fecha;
            obj.Estado = TurnoEstado.Activo;
            obj.Medico = new Medico() { Id = disponible.MedicoId };
            obj.Paciente = new Paciente() { Id = PacienteId };
            new TurnoNegocio().Guardar(obj);
            Response.Redirect("Turnos.aspx", false);
        }

        protected void grdTurnos_DataBound(object sender, EventArgs e)
        {
            for (int i = grdTurnos.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdTurnos.Rows[i];
                GridViewRow previousRow = grdTurnos.Rows[i - 1];
                for (int j = 0; j < row.Cells.Count-1; j++)
                {
                    if (row.Cells[j].Text == previousRow.Cells[j].Text)
                    {
                        if (previousRow.Cells[j].RowSpan == 0)
                        {
                            if (row.Cells[j].RowSpan == 0)
                            {
                                previousRow.Cells[j].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                            }
                            row.Cells[j].Visible = false;
                        }
                    }
                }
            }
        }
    }
}