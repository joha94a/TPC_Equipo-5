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
    public partial class MedicoView : System.Web.UI.Page
    {
        public int Id { get; set; }
        MedicoNegocio negocio = new MedicoNegocio();
        public List<Horario> ListaHorarios = new List<Horario>();
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
                    Medico obj = negocio.Get(Id);
                    txtNombre.Value = obj.Nombre;
                    txtApellido.Value = obj.Apellido;
                    txtTelefono.Value = obj.Telefono;
                    txtMail.Value = obj.Mail;
                    ListaHorarios = new HorarioNegocio().obtenerHorarioPorMedico(obj.Id);
                    grdHorarios.DataSource = ListaHorarios;
                    grdHorarios.DataBind();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32(Request.QueryString["id"]);
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            string telefono = txtTelefono.Value;
            string mail = txtMail.Value;


            Medico obj = new Medico();

            obj.Id = Id;
            obj.Nombre = nombre;
            obj.Apellido = apellido;
            obj.Telefono = telefono;
            obj.Mail = mail;
            negocio.agregar(obj);
            

            if (Request.QueryString["doc"] != null)
            {
                // Response.Redirect("TurnoCrear.aspx?doc=" + obj.DNI, false);
            }
            else
            {
                Response.Redirect("Medicos.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            negocio.eliminar(Id);
            Response.Redirect("Medicos.aspx", false);
        }
    }
}