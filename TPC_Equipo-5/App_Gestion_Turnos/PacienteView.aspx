<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PacienteView.aspx.cs" Inherits="App_Gestion_Turnos.PacienteView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="form_container">
        <div class="row column3">
            <div class="control">
                <label class="form-label" for="txtDNI">D.N.I.:</label>
                <input type="text" class="form-control" id="txtDNI" runat="server" style="width:200px">
            </div>
            <div class="control">
                <label class="form-label" for="txtNombre">Nombre:</label>
                <input type="text" class="form-control" id="txtNombre" runat="server" style="width:300px">
            </div>
            <div class="control">
                <label class="form-label" for="txtApellido">Apellido:</label>
                <input type="text" class="form-control" id="txtApellido" runat="server" style="width:300px">
            </div>
        </div>
        <div class="row column3">
            <div class="control">
                <label class="form-label" for="txtFechaNacimiento">Fecha de Nacimiento:</label>
                <input type="date" class="form-control" id="txtFechaNacimiento" runat="server" style="width:200px" min="1900-01-01">
            </div>
            <div class="control">
                <label class="form-label" for="cmbGenero">G&eacutenero:</label>
                <select class="form-select" id="cmbGenero" runat="server" style="width:200px">
                    <option value="M" selected>Masculino</option>
                    <option value="F" >Femenino</option>
                    <option value="O" >Otro</option>
                </select>
            </div>
            <div class="control">
                <label class="form-label" for="txtDireccion">Dirección:</label>
                <input type="text" class="form-control" id="txtDireccion" runat="server" style="width:300px">
            </div>
        </div>
        <div class="row column3">
            <div class="control">
                <label class="form-label" for="txtMail">Mail:</label>
                <input type="text" class="form-control" id="txtMail" runat="server" style="width:300px">
            </div>
            <div class="control">
                <label class="form-label" for="txtTelefono">Teléfono:</label>
                <input type="text" class="form-control" id="txtTelefono" runat="server" style="width:200px">
            </div>
            <div class="control">
                <label class="form-label" for="txtObservaciones">Observaciones:</label>
                <textarea class="form-control" id="txtObservaciones" runat="server"></textarea>
            </div>
        </div>
    </div>
    
    <div class="masterMenu">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary"/>
        <%if(Id > 0)
            {%>
            <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal">Eliminar</button>
          <%}
            else
            {%>
                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal" disabled="disabled">Eliminar</button>
            <%}%>
        <a class="btn btn-return" href="Pacientes.aspx">Volver</a>
    </div>

    <div class="modal fade" id="eliminarModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            ¿Desea eliminar el registro?
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-return" data-bs-dismiss="modal">Cancelar</button>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-danger"/>
          </div>
        </div>
      </div>
    </div>
</asp:Content>

