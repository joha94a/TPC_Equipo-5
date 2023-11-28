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
    public partial class HorarioView : System.Web.UI.Page
    {
        public int Id { get; set; }
        public bool SeccionMedicoVisible { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.isRecep(Session["usuario"]) && !Seguridad.isAdmin(Session["usuario"]))
            {
                Session.Add("error", "No tiene permisos para ver esta página.");
                Response.Redirect("Error.aspx", false);
            }

            if (ViewState["SeccionMedicoVisible"] != null)
                SeccionMedicoVisible = (bool)ViewState["SeccionMedicoVisible"];

            if (Request.QueryString["id"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);
                if(!IsPostBack)
                {
                    HorarioNegocio negocio = new HorarioNegocio();
                    Horario obj = negocio.Get(Id);
                    cmbDia.Value = Convert.ToInt32(obj.Dia).ToString();
                    cmbHoraDesde.Value = obj.Hora_Inicio.Hours.ToString();
                    cmbMinutosDesde.Value = obj.Hora_Inicio.Minutes.ToString();

                    cmbHoraHasta.Value = obj.Hora_Fin.Hours.ToString();
                    cmbMinutosHasta.Value = obj.Hora_Fin.Minutes.ToString();
                    if (obj.Medico != null)
                    {
                        txtMedico.Text = obj.Medico.Apellido + ", " + obj.Medico.Nombre;
                        ViewState["IdMedico"] = obj.Medico.Id;
                    }
                }
            }
        }

        protected void btnMedico_Click(object sender, EventArgs e)
        {
            txtFiltroMedico.Text = "";
            cmbMedico.CssClass = "form-select";
            lblValidacionElegirMedico.InnerText = "";
            filtrarMedicos();
            SeccionMedicoVisible = true;
            ViewState["SeccionMedicoVisible"] = SeccionMedicoVisible;
            btnMedico.Visible = false;
        }

        private void filtrarMedicos(string filtro = "")
        {
            try
            {
                MedicoNegocio negocio = new MedicoNegocio();
                List<Medico> lista = new List<Medico>();
                if (filtro == "")
                {
                    lista = negocio.listarMedicos();
                }
                else
                {
                    lista = negocio.listarMedicoFiltrado(filtro);
                }
                cmbMedico.Items.Clear();
                for (int i = 0; i < lista.Count; i++)
                {
                    cmbMedico.Items.Insert(cmbMedico.Items.Count, new ListItem(lista[i].Apellido + ", " + lista[i].Nombre, lista[i].Id.ToString()));
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            filtrarMedicos(txtFiltroMedico.Text);
        }

        protected void btnElegirMedico_Click(object sender, EventArgs e)
        {
            if (cmbMedico.SelectedValue == "")
            {
                cmbMedico.CssClass = "form-select is-invalid";
                lblValidacionElegirMedico.InnerText = "Elegir un médico.";
            }
            else
            {
                cmbMedico.CssClass = "form-select";
                lblValidacionElegirMedico.InnerText = "";
                ViewState["IdMedico"] = int.Parse(cmbMedico.SelectedValue);
                txtMedico.Text = cmbMedico.SelectedItem.Text;
                SeccionMedicoVisible = false;
                ViewState["SeccionMedicoVisible"] = SeccionMedicoVisible;
                btnMedico.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool valido = true;
            Dia dia = (Dia)Convert.ToInt32(cmbDia.Value);
            int horaDesde = Convert.ToInt32(cmbHoraDesde.Value);
            int minutosDesde = Convert.ToInt32(cmbMinutosDesde.Value);
            int horaHasta = Convert.ToInt32(cmbHoraHasta.Value);
            int minutosHasta = Convert.ToInt32(cmbMinutosHasta.Value);

            TimeSpan horaInicio = new TimeSpan(horaDesde, minutosDesde, 0);
            TimeSpan horaFin = new TimeSpan(horaHasta, minutosHasta, 0);

            try
            {
                if (horaInicio == horaFin)
                {
                    spnMensaje.InnerText = "El horario \"desde\" no puede ser igual al horario \"hasta\".";
                    valido = false;
                }
                else
                    spnMensaje.InnerText = "";

                string strMedico = ViewState["IdMedico"] == null ? "" : ViewState["IdMedico"].ToString();
                if (strMedico == "")
                {
                    valido = false;
                    txtMedico.CssClass = "form-control is-invalid";
                    lblValidacionMedico.InnerText = "Medico requerido.";
                }
                else
                {
                    txtMedico.CssClass = "form-control";
                    lblValidacionMedico.InnerText = "";
                }

                if (valido)
                {

                    Horario obj = new Horario();
                    obj.Id = Id;
                    obj.Dia = dia;
                    obj.Hora_Inicio = horaInicio;
                    obj.Hora_Fin = horaFin;
                    obj.Medico = new Medico();
                    obj.Medico.Id = int.Parse(ViewState["IdMedico"].ToString());

                    HorarioNegocio negocio = new HorarioNegocio();
                    negocio.Save(obj);

                    Response.Redirect("Horarios.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(Request.QueryString["id"]);

            HorarioNegocio negocio = new HorarioNegocio();
            MedicoNegocio medicoNegocio = new MedicoNegocio();


            // ToDo: Validar que no existan turnos reservados (activos) para ese médico en ese horario antes de eliminar.

            /*
            if (medicoNegocio.RelacionesDeHorarios(Id) > 0)
            {
                spnMensaje.InnerText = "El horario no se puede eliminar porque existe al menos un médico que lo posee.";
            }
            else
            {
                negocio.Delete(Id);
                Response.Redirect("Horarios.aspx", false);
            }
            */
        }
    }
}