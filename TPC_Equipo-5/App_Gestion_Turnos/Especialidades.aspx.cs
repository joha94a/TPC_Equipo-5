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
    public partial class Especialidades : System.Web.UI.Page
    {
        public List<Especialidad> ListaEspecialidad { get; set; }

        EspecialidadNegocio negocio = new EspecialidadNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaEspecialidad = negocio.Get();
            grdEspecialidades.DataSource = ListaEspecialidad;
            grdEspecialidades.DataBind();
        }
        protected void grdEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = grdEspecialidades.SelectedDataKey.Value.ToString();
            Response.Redirect("EspecialidadView.aspx?id=" + id, false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Value;
            string descripcion = txtDescripcion.Value;
            grdEspecialidades.DataSource = negocio.Get(codigo, descripcion);
            grdEspecialidades.DataBind(); 
        }
    }
}