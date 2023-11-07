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
    public partial class Medicos : System.Web.UI.Page
    {
        public List<Medico> ListaMedicos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoNegocio negocio = new MedicoNegocio();

            ListaMedicos = negocio.listarMedicos();

            if (!IsPostBack)
            {
                repMedicos.DataSource = ListaMedicos;
                repMedicos.DataBind();
            }
        }
    }
}