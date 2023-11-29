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
        public List<Turno> TurnosMedico { get; set; }
        public int NivelAcceso { get; set; }
        public int IdMedico { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();

            try
            {
                ListaTurnos = negocio.GetActivosUrgente();
                grdTurnos.DataSource = ListaTurnos;
                grdTurnos.DataBind();

                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    NivelAcceso = ((Usuario)Session["usuario"]).PerfilAcceso.Nivel_Acceso;
                    if (NivelAcceso == 1)
                    {
                        IdMedico = ((Usuario)Session["usuario"]).Medico.Id;

                        TurnosMedico = negocio.TurnosPorMedico(IdMedico);
                        GridProxTurnos.DataSource = TurnosMedico;
                        GridProxTurnos.DataBind();

                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void grdTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdTurnos.SelectedDataKey.Value.ToString();
            Response.Redirect("TurnoView.aspx?id=" + id, false);
        }

        protected void GridProxTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = GridProxTurnos.SelectedDataKey.Value.ToString();
            Response.Redirect("TurnoView.aspx?id=" + id, false);
        }
    }
}