<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="App_Gestion_Turnos.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h3 class="tituloPagina">Turnos</h3>
    </div>
    <div class="seccionBotonesTurnos">
        <asp:Button class="botonTurnos" ID="btnNuevoTurno" runat="server" Text="Nuevo turno" />
    </div>

    <div class="seccionGrillaTurnos">
        <h4>Turnos vigentes</h4>
    </div>
    <div class="seccionTabla">
        <table class="table table-hover table-bordered" style="width: 90%;">
            <thead>
                <tr>
                    <th scope="col">Fecha</th>
                    <th scope="col">Hora</th>
                    <th scope="col">Paciente</th>
                    <th scope="col">Médico</th>
                    <th scope="col">Observaciones</th>
                    <th scope="col"></th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repTurnos" runat="server">
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%#Eval("Fecha") %></th>
                            <td><%#Eval("Hora") %></td>
                            <td><%# Eval("Paciente.Nombre") + " " + Eval("Paciente.Apellido") %></td>
                            <td><%# Eval("Medico.Nombre") + " " + Eval("Medico.Apellido") %></td>
                            <td><%#Eval("Observaciones") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
