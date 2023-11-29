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
    public partial class AsignacionEspecialidad : System.Web.UI.Page
    {
        public int Id { get; set; }
        MedicoNegocio negocio = new MedicoNegocio();
        EspecialidadNegocio negocioEspecialides = new EspecialidadNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idMedico"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["idMedico"]);

                if (!IsPostBack)
                {
                    Medico obj = negocio.Get(Id);
                    txtMedico.Value = obj.Nombre + ", " + obj.Apellido;

                    List<Especialidad> listaEspecialidades = negocioEspecialides.obtenerEspPorMedico(Id);
                    grdEspecialidades.DataSource = listaEspecialidades;
                    grdEspecialidades.DataBind();

                    ddlEspecialidad.DataSource = negocioEspecialides.Get();
                    ddlEspecialidad.DataTextField = "Descripcion";
                    ddlEspecialidad.DataValueField = "Id";

                    ddlEspecialidad.DataBind();



                }
            }

            
        }

        protected void grdEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdMedico = Convert.ToInt32(Request.QueryString["idMedico"]);
            var idEspecialidad = (int)grdEspecialidades.SelectedDataKey.Value;
            negocioEspecialides.modificarRelacionMedEsp(IdMedico, idEspecialidad, false);
            Response.Redirect("AsignacionEspecialidad.aspx?idMedico=" + IdMedico, false);
        }

        protected void AgregarEspecialidad_Click(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(ddlEspecialidad.SelectedItem.Value);
            int IdMedico = Convert.ToInt32(Request.QueryString["idMedico"]);
            
            negocioEspecialides.modificarRelacionMedEsp(IdMedico, idEspecialidad, true);
            Response.Redirect("AsignacionEspecialidad.aspx?idMedico=" + IdMedico, false);
        }
    }
}