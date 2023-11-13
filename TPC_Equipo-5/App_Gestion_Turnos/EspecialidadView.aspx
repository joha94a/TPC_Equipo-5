<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EspecialidadView.aspx.cs" Inherits="App_Gestion_Turnos.EspecialidadView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form_container">
        <div class="row">
            <label class="form-label" for="txtCodigo">Código:</label>
            <input type="text" class="form-control" id="txtCodigo" runat="server" style="width:300px" onkeyup="validacion('#ContentPlaceHolder1_txtCodigo')">
            <span class="requerido_texto oculto">Este campo es requerido</span>
        </div>
        <div class="row">
            <label class="form-label" for="txtDescripcion">Descripción:</label>
            <textarea class="form-control" id="txtDescripcion" runat="server" style="width:300px"></textarea>
        </div>
    </div>
    
    <div class="masterMenu">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary"  OnClientClick="return validar()"/>
        <%if(Id > 0)
            {%>
            <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal">Eliminar</button>
          <%}
            else
            {%>
                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal" disabled="disabled">Eliminar</button>
            <%}%>
        <a class="btn btn-return" href="Especialidades.aspx">Volver</a>
    </div>
    <div class="message_container">
        <span class="requerido_texto" id="spnMensaje" runat="server"></span>
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
    
<script type="text/javascript">
    function validar() {
        if ($("#ContentPlaceHolder1_txtCodigo").val() === "") {
            $("#ContentPlaceHolder1_txtCodigo").siblings(".requerido_texto").removeClass("oculto")
            $("#ContentPlaceHolder1_txtCodigo").addClass('requerido')
            return false;
        }
        return true;
    }

    function validacion(id) {
        if ($(id).val() === "") {
            $(id).siblings(".requerido_texto").removeClass("oculto")
            $(id).addClass('requerido')
            $('#ContentPlaceHolder1_btnGuardar').prop('disabled', true);
        }
        else {
            $(id).siblings(".requerido_texto").addClass("oculto")
            $(id).removeClass('requerido')
            $("#ContentPlaceHolder1_btnGuardar").prop('disabled', false);
        }
    }
</script>

</asp:Content>
