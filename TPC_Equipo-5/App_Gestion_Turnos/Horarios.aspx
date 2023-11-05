<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Horarios.aspx.cs" Inherits="App_Gestion_Turnos.Horarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="tituloPagina">Horarios</h3>
    </div>

    <div class="masterMenu">
        <a class="btn btn-primary" href="HorarioView.aspx">Nuevo</a>
    </div>
    <div class="table_container">
        <%--<table class="table">
          <thead>
            <tr>
                <th scope="col">D&iacutea</th>
                <th scope="col">Desde</th>
                <th scope="col">Hasta</th>
                <th></th>
                <th></th>
            </tr>
          </thead>
          <tbody>
                <%
                    foreach (var item in ListaHorarios)
                    {
                %>
            <tr>
                <td><%:item.DiaStr %></td>
                <td><%:item.Hora_Inicio %></td>
                <td><%:item.Hora_Fin %></td>
                <td><asp:Button ID="btnHorarioVer" runat="server" Text="VER" OnClick="btnHorarioVer_Click" class="btn btn-primary gridButton"/></td>
                <td><asp:Button ID="btnHorarioDelete" runat="server" Text="ELIMINAR" OnClick="btnHorarioDelete_Click" class="btn btn-danger gridButton"/></td>
            </tr>
                <%
                    }
                %>
          </tbody>
        </table>--%>
        <asp:GridView runat="server" ID="grdHorarios" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdHorarios_SelectedIndexChanged" DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Día" DataField="Dia"/>
                <asp:BoundField HeaderText="Desde" DataField="Hora_InicioStr"/>
                <asp:BoundField HeaderText="Hasta" DataField="Hora_FinStr"/>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
