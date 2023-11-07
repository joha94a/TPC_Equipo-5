<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="App_Gestion_Turnos.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="tituloPagina">Gestionar médicos</h3>
    </div>
    <div class="seccionFiltros">
        <asp:Label ID="lblFiltro" runat="server" Text="Buscar médico:"></asp:Label>
        <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>

    </div>
    <div class="seccionAgregar">
        <!--seccion para boton agregar medico-->
    </div>
    <div class="seccionTabla">
        <table class="table table-hover table-bordered" style="width: 90%;">
            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col">Apellido</th>
                    <th scope="col">Telefono</th>
                    <th scope="col">Mail</th>
                    <th scope="col"></th>
                    <th scope="col"></th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repMedicos" runat="server">
    <ItemTemplate>
        <tr>
            
            <td><%#Eval("Nombre") %></td>
            <td><%#Eval("Apellido") %></td>
            <td><%#Eval("Telefono") %></td>
            <td><%#Eval("Mail") %></td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
            </tbody>
        </table>
    </div>

    <!--VISTA PARA LOS MEDICOS

    <div>
        <h3 class="tituloPagina">Mis datos</h3>
    </div>

    <div class="seccionDatosMedico">
        <div class="seccionDatosPersonalesMedico">
            <div class="datosAgrupados">
                <label>Nombre y Apellido:</label>
                     <asp:TextBox ID="TextBoxNombre" runat="server" Enabled="false">Juan Pepito</asp:TextBox>
            </div>

            <div class="datosAgrupados">
                <label>Especialidades:</label>
                <asp:TextBox ID="TextBoxEspecialidad" runat="server" Enabled="false">Obstetra</asp:TextBox>
            </div>

            <div class="datosAgrupados">
                <label>Mail de contacto:</label>
                <asp:TextBox ID="TextBoxMail" runat="server">JuanPepito@gmail.com</asp:TextBox>
                <asp:Button ID="btnEditarMail" runat="server" Text="Editar" />
            </div>

            <div class="datosAgrupados">
                <label>Telefono:</label>
                <asp:TextBox ID="TextBoxTelefono" runat="server">11112222333</asp:TextBox>
                <asp:Button ID="btnEditarTel" runat="server" Text="Editar" />
            </div>
        </div>
    </div>-->
</asp:Content>
