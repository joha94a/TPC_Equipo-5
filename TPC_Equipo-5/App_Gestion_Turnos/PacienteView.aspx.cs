﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Gestion_Turnos
{
    public partial class PacienteView : System.Web.UI.Page
    {
        public int Id { get; set; }
        PacienteNegocio negocio = new PacienteNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);
                if (!IsPostBack)
                {
                    Paciente obj = negocio.Get(Id);
                    txtDNI.Value = obj.DNI.ToString();
                    txtNombre.Value = obj.Nombre;
                    txtApellido.Value = obj.Apellido;
                    txtFechaNacimiento.Value = obj.Fecha_Nacimiento.ToString("yyy-MM-dd");
                    cmbGenero.Value = obj.Genero.ToString();
                    txtDireccion.Value = obj.Direccion;
                    txtTelefono.Value = obj.Telefono;
                    txtMail.Value = obj.Mail;
                    txtObservaciones.Value = obj.Observaciones;
                }
            }
            if(Request.QueryString["id"] == null && !IsPostBack)
            {
                txtFechaNacimiento.Value = DateTime.Today.ToString("yyy-MM-dd");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int dni = Convert.ToInt32(txtDNI.Value);
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Value);
            string genero = cmbGenero.Value;
            string direccion = txtDireccion.Value;
            string telefono = txtTelefono.Value;
            string mail = txtMail.Value;
            string observaciones = txtObservaciones.Value;

            Paciente obj = new Paciente();
            obj.Id = Id;
            obj.DNI = dni;
            obj.Nombre = nombre;
            obj.Apellido = apellido;
            obj.Fecha_Nacimiento = fechaNacimiento;
            obj.Genero = genero;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Mail = mail;
            obj.Observaciones = observaciones;
            negocio.agregar(obj);

            Response.Redirect("Pacientes.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            negocio.Delete(Id);
            Response.Redirect("Pacientes.aspx", false);
        }
    }
}