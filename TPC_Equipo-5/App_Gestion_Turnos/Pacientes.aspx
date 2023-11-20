<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="App_Gestion_Turnos.Pacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="tituloPagina">Pacientes</h3>
    </div>
    
    <div class="masterMenu">
        <a class="btn btn-primary" href="PacienteView.aspx">Nuevo</a>
    </div>


    <div class="filter_container">
        <div class="row">
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
        <div class="row">
            <div class="control">
                <label class="form-label" for="txtFechaNacimientoDesde">Fecha de nacimiento desde:</label>
                <input type="date" class="form-control" id="txtFechaNacimientoDesde" runat="server" style="width:200px" min="1900-01-01">
            </div>
            <div class="control">
                <label class="form-label" for="txtFechaNacimientoHasta">Fecha de nacimiento hasta:</label>
                <input type="date" class="form-control" id="txtFechaNacimientoHasta" runat="server" style="width:200px" min="1900-01-01">
            </div>
            <div class="control">
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary"/>
        </div>
    </div>

    <div class="table_container">
        <asp:GridView runat="server" ID="grdPacientes" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdPacientes_SelectedIndexChanged" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="DNI" DataField="DNI"/>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="Fecha_NacimientoStr"/>
                <asp:BoundField HeaderText="Mail" DataField="Mail"/>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
