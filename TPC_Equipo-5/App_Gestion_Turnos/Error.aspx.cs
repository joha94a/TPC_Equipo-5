using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Gestion_Turnos
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                string error = Session["error"].ToString();
                lblError.Text = error;
                Session.Remove("error");
            }
        }

        protected void btnVolverAInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", false);
        }
    }
}