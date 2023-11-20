<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioView.aspx.cs" Inherits="App_Gestion_Turnos.UsuarioView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_container">
        <div class="row column1">
            <div class="control">
                <label class="form-label" for="txtNombre_Usuario">Nombre de usuario:</label>
                <input type="text" class="form-control" id="txtNombre_Usuario" runat="server">
            </div>
        </div>
        <%if (Id > 0)
            {
            %>
        <div class="row column1">
            <div class="control">
                <label class="form-label" for="txtContrasenaActual">Contraseña actual:</label>
                <input type="text" class="form-control" id="txtContrasenaActual" runat="server">
            </div>
        </div>
        <%}
            %>
        <div class="row column1">
            <div class="control">
                <asp:Label ID="lblNuevaContrasena" CssClass="form-label" runat="server" Text="Nueva contraseña:" for="txtNuevaContrasena"></asp:Label>
                <input type="text" class="form-control" id="txtNuevaContrasena" runat="server">
            </div>
        </div>
        <div class="row column1">
            <div class="control">
                <asp:Label ID="lblRepNuevaContrasena" CssClass="form-label" runat="server" Text="Repita nueva contraseña:" for="txtRepNuevaContrasena"></asp:Label>
                <input type="text" class="form-control" id="txtRepNuevaContrasena" runat="server">
            </div>
        </div>
        <div class="row column1">
            <div class="control">
                <label class="form-label" for="cmbPerfilAcceso">Tipo:</label>
                <asp:DropDownList CssClass="form-select" ID="cmbPerfilAcceso" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row column1">
            <div class="control">
                <label class="form-label" for="txtMedico">Medico:</label>
                <input type="text" class="form-control" id="txtMedico" runat="server">

                <asp:Button ID="btnMedico" runat="server" Text="Cambiar Médico" OnClick="btnMedico_Click" class="btn btn-primary" />
            </div>
        </div>


    </div>

    <div class="masterMenu">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
        <%if (Id > 1)
            {%>
        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#bajaModal">Dar de baja</button>
        <%}
            else
            {%>
        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#bajaModal" disabled="disabled">Dar de baja</button>
        <%}%>
        <a class="btn btn-return" href="Usuarios.aspx">Volver</a>
    </div>

    <div class="modal fade" id="bajaModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Dar de baja</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ¿Desea dar de baja el usuario?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-return" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnBaja" runat="server" Text="Dar de baja" OnClick="btnBaja_Click" class="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
