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

    <div class="table_container">
        <asp:GridView runat="server" ID="grdEspecialidades" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdEspecialidades_SelectedIndexChanged" DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="Codigo"/>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
