<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioView.aspx.cs" Inherits="App_Gestion_Turnos.UsuarioView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_container">
        <div class="row column1">
            <div class="control">
                <asp:Label ID="lblNombre_Usuario" CssClass="form-label" runat="server" Text="Nombre de usuario:" for="txtNombre_Usuario"></asp:Label>
                <asp:TextBox ID="txtNombre_Usuario" runat="server" CssClass="form-control" />
            </div>
        </div>
        <%if (Id > 0)
            {
            %>
        <div class="row column1">
            <div class="control">
                <asp:Label ID="lblContrasenaActual" CssClass="form-label" runat="server" Text="Contraseña actual:" for="txtContrasenaActual"></asp:Label>
                <asp:TextBox ID="txtContrasenaActual" runat="server" CssClass="form-control" />
            </div>
        </div>
        <%}
            %>
        <div class="row column1">
            <div class="control">
                <asp:Label ID="lblNuevaContrasena" CssClass="form-label" runat="server" Text="Nueva contraseña:" for="txtNuevaContrasena"></asp:Label>
                <asp:TextBox ID="txtNuevaContrasena" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="row column1">
            <div class="control">
                <asp:Label ID="lblRepNuevaContrasena" CssClass="form-label" runat="server" Text="Repita nueva contraseña:" for="txtRepNuevaContrasena"></asp:Label>
                <asp:TextBox ID="txtRepNuevaContrasena" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="row column1">
            <div class="control">
                <asp:Label ID="lblPerfilAcceso" CssClass="form-label" runat="server" Text="Tipo:" for="cmbPerfilAcceso"></asp:Label>
                <asp:DropDownList CssClass="form-select" ID="cmbPerfilAcceso" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row column1">
            <div class="control">
                <asp:Label ID="lblMedico" CssClass="form-label" runat="server" Text="Medico:" for="txtMedico"></asp:Label>
                <asp:TextBox ID="txtMedico" runat="server" CssClass="form-control" />


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
