<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="App_Gestion_Turnos.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h3 class="tituloPagina">Turnos</h3>
    </div>
    <div class="masterMenu">
        <a class="btn btn-primary" href="TurnoCrear.aspx">Nuevo</a>
    </div>
    
    <div class="filter_container">
        <div class="row">
            <div class="control">
                <label class="form-label" for="txtFechaDesde">Fecha desde:</label>
                <input type="date" class="form-control" id="txtFechaDesde" runat="server" style="width:200px" min="1900-01-01">
            </div>
            <div class="control">
                <label class="form-label" for="txtFechaHasta">Fecha hasta:</label>
                <input type="date" class="form-control" id="txtFechaHasta" runat="server" style="width:200px" min="1900-01-01">
            </div>
            <div class="control">
                <label class="form-label" for="cmbEstado">Estado:</label>
                <select class="form-select" id="cmbEstado" runat="server" style="width:200px">
                    <option value="0" selected>Todos</option>
                    <option value="1">Activo</option>
                    <option value="2">Cancelado</option>
                    <option value="3">Completado</option>
                    <option value="4">Ausente</option>
                </select>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary"/>
        </div>
    </div>

    <div class="table_container">
        <asp:GridView runat="server" ID="grdTurnos" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdTurnos_SelectedIndexChanged" DataKeyNames="Id" OnRowDataBound="grdTurnos_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Fecha" DataField="FechaStr"/>
                <asp:BoundField HeaderText="Médico" DataField="MedicoStr"/>
                <asp:BoundField HeaderText="Paciente" DataField="PacienteStr"/>
                <asp:BoundField HeaderText="Estado" DataField="EstadoStr"/>
                <asp:BoundField HeaderText="EstadoValor" DataField="EstadoValor">
                    <ItemStyle CssClass="oculto"></ItemStyle>
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton"/>
            </Columns>
        </asp:GridView>
    </div>

    <script type="text/javascript">

        

        $(document).ready(function () {
            changeBackgroundColor()
        });

        function changeBackgroundColor() {
            var table = document.getElementById("ContentPlaceHolder1_grdTurnos");
            var rows = table.getElementsByTagName("tr");

            // Start from the second row (skip the header row)
            for (var i = 1; i < rows.length; i++) {
                var cells = rows[i].getElementsByTagName("td");

                // Get the last cell value
                var dateCellValue = cells[cells.length - 6].innerHTML.trim();
                var lastCellValue = cells[cells.length - 2].innerHTML.trim();

                if (lastCellValue === "1" /*&& dateCellValue === formatDateToDDMMYYYY()*/) {
                    $(rows[i]).children().css("color", "#3ac577");
                    $(rows[i]).children().css("font-weight", "700");
                }
                if (lastCellValue === "4") {
                    $(rows[i]).children().css("color", "tomato");
                    $(rows[i]).children().css("font-weight", "700");
                }
            }
        }
        function formatDateToDDMMYYYY() {
            var today = new Date();

            var day = today.getDate();
            var month = today.getMonth() + 1; // Months are zero-based
            var year = today.getFullYear();

            // Pad day and month with leading zeros if necessary
            day = day < 10 ? "0" + day : day;
            month = month < 10 ? "0" + month : month;

            var formattedDate = day + "/" + month + "/" + year;

            return formattedDate;
        }
    </script>

</asp:Content>