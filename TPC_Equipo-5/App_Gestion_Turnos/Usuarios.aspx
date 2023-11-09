<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="App_Gestion_Turnos.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="tituloPagina">Usuarios</h3>
    </div>
    <div class="masterMenu">
        <a class="btn btn-primary" href="UsuarioView.aspx">Nuevo</a>
    </div>
    <div class="filter_container">
        <div class="row">
            <div class="control">
                <label class="form-label" for="cmbPerfilAcceso">Tipo:</label>
                <select class="form-select" id="cmbPerfilAcceso" runat="server">
                    <%--
                    <option selected></option>
                    <option value="1">Medico</option>
                    <option value="2">Recepcionista</option>
                    <option value="3">Administrador</option>
                    --%>
                </select>
            </div>
        </div>

        <div class="row">
            <label class="form-label" for="txtNombre_Usuario">Nombre de usuario:</label>
            <input type="text" class="form-control" id="txtNombre_Usuario" runat="server">
        </div>

        <div class="row">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
        </div>
    </div>
    <div class="table_container">
        <asp:GridView runat="server" ID="grdUsuarios" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdUsuarios_SelectedIndexChanged" DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Nombre Usuario" DataField="Nombre_Usuario" />
                <asp:BoundField HeaderText="Tipo" DataField="PerfilAcceso.Descripcion" />
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
