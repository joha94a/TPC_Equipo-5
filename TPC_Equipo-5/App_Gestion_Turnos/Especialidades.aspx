<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="App_Gestion_Turnos.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="tituloPagina">Especialidades</h3>
    </div>

    <div class="masterMenu">
        <a class="btn btn-primary" href="EspecialidadView.aspx">Nuevo</a>
    </div>

    <div class="filter_container">
        <div class="row">
            <div class="control">
                <label class="form-label" for="txtCodigo">Código:</label>
                <input type="text" class="form-control" id="txtCodigo" runat="server">
            </div>
            <div class="control">
                <label class="form-label" for="txtDescripcion">Descripción:</label>
                <input type="text" class="form-control" id="txtDescripcion" runat="server">
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary"/>
        </div>
    </div>

    <div class="table_container">
        <asp:GridView runat="server" ID="grdEspecialidades" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdEspecialidades_SelectedIndexChanged" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo"/>
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion"/>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

