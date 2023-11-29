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

                    
                    List<Especialidad> listaEspecialidades = obj.Especialidades;
                    
                    for(int i = 0; i < listaEspecialidades.Count; i++)
                    {
                        if(i== listaEspecialidades.Count - 1)
                        {
                            TBEspecialidades.Text += listaEspecialidades[i].Descripcion;
                        }
                        else { TBEspecialidades.Text += listaEspecialidades[i].Descripcion + ", "; }
                        
                    }

                    if(listaEspecialidades == null || listaEspecialidades.Count == 0)
                    {
                        TBEspecialidades.Text = "Sin especialidad asignada";
                    }
                    
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
            

            if (Request.QueryString["id"] != null)
            {
                Response.Redirect("Medicos.aspx", false);
            }
            else
            {
                //tiene que ir cargar esp con id dle medico nuevo
                //Response.Redirect("AsignacionEspecialidad.aspx?idMedico=" + IdMedico, false);
                Response.Redirect("Medicos.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            negocio.eliminar(Id);
            Response.Redirect("Medicos.aspx", false);
        }

        protected void btnAgregarHs_Click(object sender, EventArgs e)
        {

            int IdMedico = Convert.ToInt32(Request.QueryString["id"]);
           

            Medico obj = new Medico();

            obj.Id = IdMedico;
            
            try
            {
                Response.Redirect("HorarioView.aspx?idMedico=" + IdMedico, false);
            }
            catch 
            {
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            int IdMedico = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("AsignacionEspecialidad.aspx?idMedico=" + IdMedico, false);
        }
    }
}