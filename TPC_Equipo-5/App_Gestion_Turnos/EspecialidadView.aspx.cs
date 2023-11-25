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
    public partial class EspecialidadView : System.Web.UI.Page
    {
        public int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.isAdmin(Session["usuario"]))
            {
                Session.Add("error", "Necesita permisos de administrador para ver esta página.");
                Response.Redirect("Error.aspx", false);
            }
            if (Request.QueryString["id"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);
                if (!IsPostBack)
                {
                    EspecialidadNegocio negocio = new EspecialidadNegocio();
                    Especialidad obj = negocio.Get(Id);
                    txtCodigo.Value = obj.Codigo;
                    txtDescripcion.Value = obj.Descripcion;
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Value;
            string descripcion = txtDescripcion.Value;

            Especialidad obj = new Especialidad();
            obj.Id = Id;
            obj.Codigo = codigo;
            obj.Descripcion = descripcion;
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            Especialidad existente = negocio.Get(codigo, Id);
            if(existente.Id == 0)
            {
                negocio.Save(obj);
                Response.Redirect("Especialidades.aspx", false);
            }
            else
            {
                spnMensaje.InnerText = "Ya existe un registro con ese código.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            MedicoNegocio medicoNegocio = new MedicoNegocio();
            if(medicoNegocio.RelacionesDeEspecialidad(Id) > 0)
            {
                spnMensaje.InnerText = "La especialidad no se puede eliminar porque existe al menos un médico que la posee.";
            }
            else
            {
                negocio.Delete(Id);
                Response.Redirect("Especialidades.aspx", false);
            }
        }
    }
}