<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="App_Gestion_Turnos.Pacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="tituloPagina">Pacientes</h3>
    </div>
    <div class="seccionFiltros">
        <asp:Label ID="lblFiltro" runat="server" Text="Buscar paciente:"></asp:Label>
        <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click"/>
    </div>
    <div class="seccionAgregar">
        <asp:Button ID="btnAgregarPaciente" runat="server" Text="Dar de alta paciente" />
    </div>
    <div class="seccionTabla">
        <table class="table table-hover table-bordered" style="width:90%;">
            <thead>
                <tr>
                    <th scope="col">DNI</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Apellido</th>
                    <th scope="col">Fecha Nacimiento</th>
                    <th scope="col">Genero</th>
                    <th scope="col">Telefono</th>
                    <th scope="col">Mail</th>
                    <th scope="col"></th>
                    <th scope="col"></th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repPacientes" runat="server">
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%#Eval("DNI") %></th>
                            <td><%#Eval("Nombre") %></td>
                            <td><%#Eval("Apellido") %></td>
                            <td><%#Eval("Fecha_Nacimiento") %></td>
                            <td><%#Eval("Genero") %></td>
                            <td><%#Eval("Telefono") %></td>
                            <td><%#Eval("Mail") %></td>
                            <td>
                                <asp:Button ID="btnVer" runat="server" Text="Ver" CommandName="Ver" CommandArgument='<%# Eval("ID") %>' />
                            </td>
                            <td>
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("ID") %>' />
                            </td>
                            <td>
                                <asp:Button ID="btnEliminar" runat="server" Text="Dar baja" CommandName="Eliminar" CommandArgument='<%# Eval("ID") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
