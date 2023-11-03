<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="App_Gestion_Turnos.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h3 class="tituloPagina">Turnos</h3>
    </div>
    <div class="seccionBotonesTurnos">
        <asp:Button class="botonTurnos" ID="btnNuevoTurno" runat="server" Text="Nuevo turno" />
        <asp:Button class="botonTurnos" ID="btnModificarTurno" runat="server" Text="Modificar turno" />
        <asp:Button class="botonTurnos" ID="btnListarTurnos" runat="server" Text="Listar turnos" />
    </div>

    <div class="seccionGrillaTurnos">

    </div>
</asp:Content>
