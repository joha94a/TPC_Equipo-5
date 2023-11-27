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
        <div class="row column1">
            <div class="control">
                <label class="form-label" for="cmbPerfilAcceso">Tipo:</label>
                <select class="form-select" id="cmbPerfilAcceso" runat="server"></select>
            </div>
        </div>
        
        <div class="row column1">
            <div class="control">
                <label class="form-label" for="txtNombre_Usuario">Nombre de usuario:</label>
                <asp:TextBox ID="txtNombre_Usuario" runat="server" CssClass="form-control" AutoCompleteType="Disabled"/>
            </div>
        </div>

        <div class="row">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
        </div>
    </div>
    <div class="table_container">
        <asp:GridView runat="server" ID="grdUsuarios" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdUsuarios_SelectedIndexChanged" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" OnDataBound="grdUsuarios_DataBound">
            <Columns>
                <asp:BoundField HeaderText="Nombre Usuario" DataField="Nombre_Usuario" />
                <asp:BoundField HeaderText="Tipo" DataField="PerfilAcceso.Descripcion" />
                <asp:TemplateField HeaderText="Medico">
                    <ItemTemplate>
                        <%# Eval("Medico") != null ? Eval("Medico.Apellido") + ", " + Eval("Medico.Nombre") : String.Empty %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
