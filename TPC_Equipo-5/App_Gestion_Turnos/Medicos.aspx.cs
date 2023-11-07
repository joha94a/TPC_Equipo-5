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
    public partial class Medicos : System.Web.UI.Page
    {
        public List<Medico> ListaMedicos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string filtro = Request.QueryString["filtro"];
            MedicoNegocio negocio = new MedicoNegocio();

            if (!IsPostBack && !string.IsNullOrEmpty(filtro))
            {
                ListaMedicos = negocio.listarMedicoFiltrado(filtro);
                txtFiltro.Text = filtro;
            }
            else
            {
                ListaMedicos = negocio.listarMedicos();
            }

            if (!IsPostBack)
            {
                repMedicos.DataSource = ListaMedicos;
                repMedicos.DataBind();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            if (!string.IsNullOrEmpty(filtro))
            {
                Response.Redirect("Medicos.aspx?filtro=" + filtro, false);
            }
            else
            {
                Response.Redirect("Medicos.aspx", false);
            }
        }
    }
}