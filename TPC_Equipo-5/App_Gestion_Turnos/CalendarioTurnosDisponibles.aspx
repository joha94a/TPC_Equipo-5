<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalendarioTurnosDisponibles.aspx.cs" Inherits="App_Gestion_Turnos.CalendarioTurnosDisponibles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="table_container">
        <asp:GridView runat="server" ID="grdTurnos" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdTurnos_SelectedIndexChanged" OnDataBound="grdTurnos_DataBound" DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Fecha" DataField="FechaStr"/>
                <asp:BoundField HeaderText="Medico" DataField="MedicoStr"/>
                <asp:BoundField HeaderText="Hora" DataField="HoraStr"/>
                <asp:CommandField ShowSelectButton="true" SelectText="SELECCIONAR" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton"/>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
