<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HorarioView.aspx.cs" Inherits="App_Gestion_Turnos.HorarioView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    <div class="form_container">
        <div class="row">
            <div class="contorl dia_selection">
                <label class="form-label" for="cmbDia">D&iacutea:</label>
                <select class="form-select dia_select" id="cmbDia" runat="server" style="width:300px;">
                    <option value="1" selected>Lunes</option>
                    <option value="2">Martes</option>
                    <option value="3">Miercoles</option>
                    <option value="4">Jueves</option>
                    <option value="5">Viernes</option>
                    <option value="6">Sabado</option>
                    <option value="7">Domingo</option>
                </select>
            </div>
        </div>
        <div class="row column2">
            <div class="control">
                <div class="input-group mb-3 hora_selection" id="horaInicio_container">
                    <label class="form-label">Desde:</label>
                    <select class="form-select hora_dropdown" aria-label="Default select example" id="cmbHoraDesde" runat="server">
                      <option selected>00</option>
                      <option value="1">01</option>
                      <option value="2">02</option>
                      <option value="3">03</option>
                      <option value="4">04</option>
                      <option value="5">05</option>
                      <option value="6">06</option>
                      <option value="7">07</option>
                      <option value="8">08</option>
                      <option value="9">09</option>
                      <option value="10">10</option>
                      <option value="11">11</option>
                      <option value="12">12</option>
                      <option value="13">13</option>
                      <option value="14">14</option>
                      <option value="15">15</option>
                      <option value="16">16</option>
                      <option value="17">17</option>
                      <option value="18">18</option>
                      <option value="19">19</option>
                      <option value="20">20</option>
                      <option value="21">21</option>
                      <option value="22">22</option>
                      <option value="23">23</option>
                    </select>

                    <select class="form-select minutos_selection" aria-label="Default select example" id="cmbMinutosDesde" runat="server">
                        <option selected>00</option>
                        <option value="5">05</option>
                        <option value="10">10</option>
                        <option value="15">15</option>
                        <option value="20">20</option>
                        <option value="25">25</option>
                        <option value="30">30</option>
                        <option value="35">35</option>
                        <option value="40">40</option>
                        <option value="45">45</option>
                        <option value="50">50</option>
                        <option value="55">55</option>
                    </select>
                </div>
            </div>
            <div class="control">
                <div class="input-group mb-3 hora_selection" id="horaFin_container">
                    <label class="form-label">Hasta:   </label>
                    <select class="form-select hora_dropdown" aria-label="Default select example" id="cmbHoraHasta" runat="server">
                      <option value="0" selected>00</option>
                      <option value="1">01</option>
                      <option value="2">02</option>
                      <option value="3">03</option>
                      <option value="4">04</option>
                      <option value="5">05</option>
                      <option value="6">06</option>
                      <option value="7">07</option>
                      <option value="8">08</option>
                      <option value="9">09</option>
                      <option value="10">10</option>
                      <option value="11">11</option>
                      <option value="12">12</option>
                      <option value="13">13</option>
                      <option value="14">14</option>
                      <option value="15">15</option>
                      <option value="16">16</option>
                      <option value="17">17</option>
                      <option value="18">18</option>
                      <option value="19">19</option>
                      <option value="20">20</option>
                      <option value="21">21</option>
                      <option value="22">22</option>
                      <option value="23">23</option>
                    </select>
    
                    <select class="form-select minutos_selection" aria-label="Default select example" id="cmbMinutosHasta" runat="server">
                        <option value="0" selected>00</option>
                        <option value="5">05</option>
                        <option value="10">10</option>
                        <option value="15">15</option>
                        <option value="20">20</option>
                        <option value="25">25</option>
                        <option value="30">30</option>
                        <option value="35">35</option>
                        <option value="40">40</option>
                        <option value="45">45</option>
                        <option value="50">50</option>
                        <option value="55">55</option>
                    </select>
                </div>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="m-2 mb-3">
                    <asp:Label ID="lblMedico" CssClass="form-label" runat="server" Text="Médico:" for="txtMedico"></asp:Label>
                    <asp:TextBox ID="txtMedico" runat="server" CssClass="form-control" Width="300px" Enabled="false" />
                    <div id="lblValidacionMedico" runat="server" class="invalid-feedback"></div>
                </div>
                <div class="m-2 mb-3">
                    <asp:Button ID="btnMedico" runat="server" Text="Cambiar Médico" OnClick="btnMedico_Click" CssClass="btn btn-primary" />
                </div>
                <%      
                if (SeccionMedicoVisible)
                {
                %>
                    <div class="p-3 border border-primary rounded">
                            <div class="mb-3">
                                <asp:Label ID="lblFiltroMedico" CssClass="form-label mb-3" runat="server" Text="Filtro:" for="txtFiltroMedico"></asp:Label>
                                <asp:TextBox ID="txtFiltroMedico" runat="server" CssClass="form-control w-50 d-inline-block m-3" AutoCompleteType="Disabled"/>
                                <asp:Button ID="btnBuscarMedico" runat="server" Text="Buscar" CssClass="btn btn-secondary btn-sm m-3" OnClick="btnBuscarMedico_Click" AutoPostBack="false" />
                                <asp:DropDownList CssClass="form-select w-75" ID="cmbMedico" runat="server" AutoPostBack="false"></asp:DropDownList>
                                <div id="lblValidacionElegirMedico" runat="server" class="invalid-feedback"></div>
                            </div>
                            <div class="mb-3">
                                <asp:Button ID="btnElegirMedico" runat="server" Text="Elegir" CssClass="btn btn-primary btn-sm" OnClick="btnElegirMedico_Click" />
                            </div>
                    </div>
                <%
                }
                %>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    
    <div class="masterMenu">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary"/>
        <%if(Id > 0)
            {%>
            <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal">Eliminar</button>
          <%}
            else
            {%>
                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#eliminarModal" disabled="disabled">Eliminar</button>
            <%}%>
        <a class="btn btn-return" href="Horarios.aspx">Volver</a>
    </div>
    
    <div class="message_container">
        <span class="requerido_texto" id="spnMensaje" runat="server"></span>
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
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-danger"/>
          </div>
        </div>
      </div>
    </div>

</asp:Content>
