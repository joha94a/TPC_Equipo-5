<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicoView.aspx.cs" Inherits="App_Gestion_Turnos.MedicoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form_container">
        <div class="row column2">
            <div class="control">
                <label class="form-label" for="txtNombre">Nombre:</label>
                <input type="text" class="form-control" id="txtNombre" runat="server" style="width: 300px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>
            <div class="control">
                <label class="form-label" for="txtApellido">Apellido:</label>
                <input type="text" class="form-control" id="txtApellido" runat="server" style="width: 300px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>
        </div>
      
        <div class="row column2">
            <div class="control">
                <label class="form-label" for="txtMail">Mail:</label>
                <input type="text" class="form-control" id="txtMail" runat="server" style="width: 300px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>
            <div class="control">
                <label class="form-label" for="txtTelefono">Teléfono:</label>
                <input type="text" class="form-control" id="txtTelefono" runat="server" style="width: 200px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>
            
        </div>
    </div>
   
</asp:Content>
