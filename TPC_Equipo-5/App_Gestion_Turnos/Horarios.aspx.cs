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
        }
    }
}