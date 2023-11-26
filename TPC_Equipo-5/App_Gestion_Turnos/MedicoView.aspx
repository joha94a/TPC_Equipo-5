<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicoView.aspx.cs" Inherits="App_Gestion_Turnos.MedicoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form_container">
        <div class="row column2">
            <div class="control">
                <label class="form-label" for="txtNombre">Nombre:</label>
                <input type="text" class="form-control" id="txtNombre" runat="server" style="width: 300px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>
            <div class="control">
                <label class="form-label" for="txtApellido">Apellido:</label>
                <input type="text" class="form-control" id="txtApellido" runat="server" style="width: 300px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>
        </div>

        <div class="row column2">
            <div class="control">
                <label class="form-label" for="txtMail">Mail:</label>
                <input type="text" class="form-control" id="txtMail" runat="server" style="width: 300px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>
            <div class="control">
                <label class="form-label" for="txtTelefono">Teléfono:</label>
                <input type="text" class="form-control" id="txtTelefono" runat="server" style="width: 200px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>

        </div>
    </div>

    <div class="masterMenu">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="return validar()" class="btn btn-primary" />
        <%if (Id > 0)
            {%>
        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal">Eliminar</button>
        <%}
            else
            {%>
        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal" disabled="disabled">Eliminar</button>
        <a class="btn btn-return" href="Medicos.aspx">Volver</a>
        <%} %>
    </div>

    <div class="message_container">
        <span class="requerido_texto" id="spnMensaje" runat="server"></span>
    </div>


    <div class="message_container">
        <h4>Horarios</h4>
    </div>
    <div class="table_container">
        <asp:GridView runat="server" ID="grdHorarios" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="Dia" DataField="Dia" />
                <asp:BoundField HeaderText="Inicio" DataField="Hora_Inicio" />
                <asp:BoundField HeaderText="Fin" DataField="Hora_Fin" />
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="modal fade" id="eliminarModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ¿Desea eliminar el registro?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-return" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            changeBackgroundColor()
        });

        function validar() {
            let hayError = false;
            if ($("#ContentPlaceHolder1_txtDNI").val() === "") {
                $("#ContentPlaceHolder1_txtDNI").siblings(".requerido_texto").removeClass("oculto")
                $("#ContentPlaceHolder1_txtDNI").addClass('requerido')
                hayError = true;
            }
            if ($("#ContentPlaceHolder1_txtNombre").val() === "") {
                $("#ContentPlaceHolder1_txtNombre").siblings(".requerido_texto").removeClass("oculto")
                $("#ContentPlaceHolder1_txtNombre").addClass('requerido')
                hayError = true;
            }
            if ($("#ContentPlaceHolder1_txtApellido").val() === "") {
                $("#ContentPlaceHolder1_txtApellido").siblings(".requerido_texto").removeClass("oculto")
                $("#ContentPlaceHolder1_txtApellido").addClass('requerido')
                hayError = true;
            }
            if ($("#ContentPlaceHolder1_txtFechaNacimiento").val() === "") {
                $("#ContentPlaceHolder1_txtFechaNacimiento").siblings(".requerido_texto").removeClass("oculto")
                $("#ContentPlaceHolder1_txtFechaNacimiento").addClass('requerido')
                hayError = true;
            }
            if (new Date($("#ContentPlaceHolder1_txtFechaNacimiento").val()) > new Date()) {
                $("#ContentPlaceHolder1_txtFechaNacimiento").siblings(".requerido_texto").removeClass("oculto")
                $("#ContentPlaceHolder1_txtFechaNacimiento").siblings(".requerido_texto").text("La fecha es inválida.")
                $("#ContentPlaceHolder1_txtFechaNacimiento").addClass('requerido')
                hayError = true;
            }
            if ($("#ContentPlaceHolder1_txtDireccion").val() === "") {
                $("#ContentPlaceHolder1_txtDireccion").siblings(".requerido_texto").removeClass("oculto")
                $("#ContentPlaceHolder1_txtDireccion").addClass('requerido')
                hayError = true;
            }
            if ($("#ContentPlaceHolder1_txtMail").val() === "") {
                $("#ContentPlaceHolder1_txtMail").siblings(".requerido_texto").removeClass("oculto")
                $("#ContentPlaceHolder1_txtMail").addClass('requerido')
                hayError = true;
            }
            if ($("#ContentPlaceHolder1_txtTelefono").val() === "") {
                $("#ContentPlaceHolder1_txtTelefono").siblings(".requerido_texto").removeClass("oculto")
                $("#ContentPlaceHolder1_txtTelefono").addClass('requerido')
                hayError = true;
            }
            return !hayError;
        }

        function validacion(id) {

            if ($('#' + id).val() === "") {
                $('#' + id).siblings(".requerido_texto").removeClass("oculto")
                $('#' + id).addClass('requerido')
            }
            else {
                $('#' + id).siblings(".requerido_texto").addClass("oculto")
                $('#' + id).removeClass('requerido')
            }
        }

        function changeBackgroundColor() {
            var table = document.getElementById("ContentPlaceHolder1_grdTurnos");
            var rows = table.getElementsByTagName("tr");

            for (var i = 1; i < rows.length; i++) {
                var cells = rows[i].getElementsByTagName("td");

                var dateCellValue = cells[cells.length - 5].innerHTML.trim();
                var lastCellValue = cells[cells.length - 2].innerHTML.trim();

                if (lastCellValue === "1" /*&& dateCellValue === formatDateToDDMMYYYY()*/) {
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
