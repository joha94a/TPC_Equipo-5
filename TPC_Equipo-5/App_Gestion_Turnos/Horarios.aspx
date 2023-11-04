<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Horarios.aspx.cs" Inherits="App_Gestion_Turnos.Horarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="tituloPagina">Horarios</h3>
    </div>

    <table class="table">
      <thead>
        <tr>
          <th scope="col">Dia</th>
          <th scope="col">Desde</th>
          <th scope="col">Hasta</th>
        </tr>
      </thead>
      <tbody>
            <%
                foreach (var item in ListaHorarios)
                {
            %>
        <tr>
              <td><%: item.DiaStr %></td>
              <td><%: item.Hora_Inicio %></td>
              <td><%: item.Hora_Fin %></td>
        </tr>
            <%
                }
            %>
      </tbody>
    </table>

</asp:Content>
