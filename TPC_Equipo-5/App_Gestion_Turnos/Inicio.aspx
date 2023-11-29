<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="App_Gestion_Turnos.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (ListaTurnos.Count > 0)
        { %>


    <div>
        <h3 class="tituloPagina">Turnos urgentes</h3>
    </div>
    <div class="table_container">
        <asp:GridView runat="server" ID="grdTurnos" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdTurnos_SelectedIndexChanged" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="Fecha" DataField="FechaStr" />
                <asp:BoundField HeaderText="Médico" DataField="MedicoStr" />
                <asp:BoundField HeaderText="Paciente" DataField="PacienteStr" />
                <asp:BoundField HeaderText="Estado" DataField="EstadoStr" />
                <asp:BoundField HeaderText="EstadoValor" DataField="EstadoValor" HeaderStyle-CssClass="oculto">
                    <ItemStyle CssClass="oculto"></ItemStyle>
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton" />
            </Columns>
        </asp:GridView>
    </div>

    <%} %>


    <%if (NivelAcceso == 1)
        { %>

    <div>
        <h3 class="tituloPagina">Próximos turnos</h3>
    </div>
    <div class="table_container">
        <asp:GridView runat="server" ID="GridProxTurnos" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="Fecha" DataField="FechaStr" />
                <asp:BoundField HeaderText="Paciente" DataField="PacienteStr" />
                <asp:BoundField HeaderText="Especialidad" DataField="EspecialidadStr" />
                <asp:BoundField HeaderText="Estado" DataField="EstadoStr" />
                <asp:BoundField HeaderText="EstadoValor" DataField="EstadoValor" HeaderStyle-CssClass="oculto">
                    <ItemStyle CssClass="oculto"></ItemStyle>
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton" />
            </Columns>
        </asp:GridView>
    </div>
    <%} %>

    <%if (NivelAcceso == 3)
        { %>

    <div>
        <h3 class="tituloPagina">Bienvenido admin</h3>
    </div>

    <%} %>


    <script type="text/javascript">

        $(document).ready(function () {
            changeBackgroundColor()
        });


        function changeBackgroundColor() {
            var table = document.getElementById("ContentPlaceHolder1_grdTurnos");
            var rows = table.getElementsByTagName("tr");

            for (var i = 1; i < rows.length; i++) {
                var cells = rows[i].getElementsByTagName("td");

                var dateCellValue = cells[cells.length - 6].innerHTML.trim();
                var lastCellValue = cells[cells.length - 2].innerHTML.trim();

                if (lastCellValue === "1") {
                    $(rows[i]).children().css("color", "#3ac577");
                    $(rows[i]).children().css("font-weight", "700");
                }
                if (lastCellValue === "2") {
                    $(rows[i]).children().css("color", "tomato");
                    $(rows[i]).children().css("font-weight", "700");
                }
                if (lastCellValue === "4") {
                    $(rows[i]).children().css("color", "#e59605");
                    $(rows[i]).children().css("font-weight", "700");
                }
            }
        }
    </script>
</asp:Content>
