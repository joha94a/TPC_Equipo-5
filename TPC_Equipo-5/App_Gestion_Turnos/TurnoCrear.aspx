<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnoCrear.aspx.cs" Inherits="App_Gestion_Turnos.TurnoCrear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="form_container">
        <div class="row column1">
            <div class="control">
                <label class="form-label" for="txtDNI">D.N.I.:</label>
                <input type="number" class="form-control" id="txtDNI" runat="server" style="width:200px" onkeyup="validacion(this.id)">
                <span class="requerido_texto oculto">Este campo es requerido</span>
            </div>
            <div class="control">
                <asp:Button ID="btnContinuar" runat="server" Text="Continuar" OnClick="btnContinuar_Click"  class="btn btn-primary"/>
            </div>
        </div>
        
            
          <%if(Paciente.Id > 0)
            {%>
            <div class="row column3">
                <div class="control">
                    <label class="form-label" for="lblApellido">Apellido:</label>
                    <label id="lblApellido"><%:Paciente.Apellido%></label>
                </div>
                <div class="control">
                    <label class="form-label" for="lblNombre">Nombre:</label>
                    <label id="lblNombre"><%:Paciente.Nombre%></label>
                </div>
                <div class="control">
                    <label class="form-label" for="lblObservaciones">Observaciones:</label>
                    <label id="lblObservaciones"><%:Paciente.Observaciones%></label>
                </div>
            </div>
        <div class="row column3">
            <div class="control">
                <label class="form-label" for="lblFechaNacimiento">Fecha de Nacimiento:</label>
                <label id="lblFechaNacimiento"><%:Paciente.Fecha_NacimientoStr%></label>
            </div>
            <div class="control">
                <label class="form-label" for="lblGenero">G&eacutenero:</label>
                <label id="lblGenero"><%:Paciente.GeneroStr%></label>
            </div>
            <div class="control"></div>
        </div>

            <div class="row column1">
                <div class="control">
                    <label class="form-label" for="cmbEspecialidad">Especialidad:</label>
                    <asp:DropDownList ID="cmbEspecialidad" runat="server" CssClass="form-select form_control"></asp:DropDownList>
                    
                </div>
                <div class="control">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  class="btn btn-primary"/>
                </div>
            </div>
          <%}%>
    </div>

    
</asp:Content>
