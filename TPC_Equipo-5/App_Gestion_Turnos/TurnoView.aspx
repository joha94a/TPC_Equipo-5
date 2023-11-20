<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnoView.aspx.cs" Inherits="App_Gestion_Turnos.TurnoView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="masterMenu">
        <%if(Turno.Estado != Dominio.TurnoEstado.Ausente)
            {%>
            <button type="button" class="btn btn-ausente" data-bs-toggle="modal" data-bs-target="#AusenteModal">Ausente</button>
          <%}
        if (Turno.Estado != Dominio.TurnoEstado.Cancelado)
        {%>
            <button type="button" class="btn btn-cancelar" data-bs-toggle="modal" data-bs-target="#CancelarModal">Cancelar</button>
        <%} 
        if(Turno.Estado != Dominio.TurnoEstado.Completado)
        {%>
            <button type="button" class="btn btn-completado" data-bs-toggle="modal" data-bs-target="#CompletadoModal">Completado</button>
        <%}%>
    </div>


    <div class="form_container">
        <div class="row column3">
            <div class="control">
                <label class="form-label boldLabel" for="lblFecha">Fecha:</label>
                <label id="lblFecha"><%:Turno.FechaStr%></label>
            </div>
            <div class="control">
                <label class="form-label boldLabel" for="lblHora">Hora:</label>
                <label id="lblHora"><%:Turno.Fecha.ToString("HH:mm")%></label>
            </div>
            <div class="control">
                <label class="form-label boldLabel" for="lblEstado">Estado:</label>
                <label id="lblEstado"><%:Turno.Estado.ToString()%></label>
            </div>
        </div>
        <div class="row column1">
            <div class="control">
                <label class="form-label boldLabel" for="lblMedico">M&eacutedico:</label>
                <label id="lblMedico"><%:Turno.Medico.Apellido + ", " + Turno.Medico.Nombre%></label>
            </div>
        </div>
        <div class="row column3">
            <div class="control">
                <label class="form-label boldLabel" for="lblPaciente">Paciente:</label>
                <label id="lblPaciente"><%:Turno.Paciente.Apellido + ", " + Turno.Paciente.Nombre%></label>
            </div>
            <div class="control">
                <label class="form-label boldLabel" for="lblDNI">D.N.I.:</label>
                <label id="lblDNI"><%:Turno.Paciente.DNI%></label>
            </div>
            <div class="control">
                <label class="form-label boldLabel" for="lblFechaNacimiento">Fecha de nacimiento:</label>
                <label id="lblFechaNacimiento"><%:Turno.Paciente.Fecha_NacimientoStr%></label>
            </div>
        </div>
        <div class="row column3">
            <div class="control">
                <label class="form-label boldLabel" for="txtObservaciones">Observaciones:</label>
                <textarea class="form-control" id="txtObservaciones" runat="server"></textarea>
            </div>
        </div>
    </div>

    <div class="masterMenu">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"  class="btn btn-primary"/>
        <a class="btn btn-return" href="Turnos.aspx">Volver</a>
    </div>

    <div class="modal fade" id="AusenteModal" tabindex="-1" aria-labelledby="ausenteModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="ausenteModalLabel">Ausente</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            ¿Desea marcar el turno como <span style="font-weight:700; color:#e59605">ausente</span>?
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-return" data-bs-dismiss="modal">No</button>
            <asp:Button ID="btnAusente" runat="server" Text="  Si  " OnClick="btnAusente_Click" class="btn btn-ausente"/>
          </div>
        </div>
      </div>
    </div>
    
    <div class="modal fade" id="CancelarModal" tabindex="-1" aria-labelledby="cancelarModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="cancelarModalLabel">Cancelar</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            ¿Desea marcar el turno como <span style="font-weight:700; color:#eb3e1f">cancelado</span>?
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-return" data-bs-dismiss="modal">No</button>
            <asp:Button ID="btnCancelar" runat="server" Text="  Si  " OnClick="btnCancelar_Click" class="btn btn-cancelar"/>
          </div>
        </div>
      </div>
    </div>
    
    <div class="modal fade" id="CompletadoModal" tabindex="-1" aria-labelledby="completadoModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="completadoModalLabel">Completado</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            ¿Desea marcar el turno como <span style="font-weight:700; color:seagreen">completado</span>?
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-return" data-bs-dismiss="modal">No</button>
            <asp:Button ID="btnCompletado" runat="server" Text="  Si  " OnClick="btnCompletado_Click" class="btn btn-completado"/>
          </div>
        </div>
      </div>
    </div>

    <script type="text/javascript">

        if ($('#lblEstado').text() === "Activo") {
            $('#lblEstado').css("color", "seagreen");
            $('#lblEstado').css("font-weight", "700");
        }
        else if ($('#lblEstado').text() === "Cancelado") {
            $('#lblEstado').css("color", "#eb3e1f");
            $('#lblEstado').css("font-weight", "700");
        }
        else if ($('#lblEstado').text() === "Ausente") {
            $('#lblEstado').css("color", "#e59605");
            $('#lblEstado').css("font-weight", "700");
        }
    </script>

</asp:Content>
