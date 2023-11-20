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
    
    <div class="filter_container">
        <div class="row">
            <div class="control">
                    <label class="form-label" for="cmbDia">D&iacutea:</label>
                    <select class="form-select dia_select" id="cmbDia" runat="server">
                        <option selected ></option>
                        <option value="1">Lunes</option>
                        <option value="2">Martes</option>
                        <option value="3">Miercoles</option>
                        <option value="4">Jueves</option>
                        <option value="5">Viernes</option>
                        <option value="6">Sabado</option>
                        <option value="7">Domingo</option>
                    </select>
                </div>
            <div class="control">

            </div>
        </div>
        <div class="row">
            <div class="control">
                <div class="input-group mb-3 hora_selection" id="horaInicio_container">
                    <label class="form-label">Desde:</label>
                    <select class="form-select hora_dropdown" aria-label="Default select example" id="cmbHoraDesde" runat="server">
                      <option selected></option>
                      <option value="0">00</option>
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
                        <option selected></option>
                        <option value="0">00</option>
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
                      <option selected></option>
                      <option value="0">00</option>
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
                        <option selected ></option>
                        <option value="0">00</option>
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
        <div class="row">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary"/>
        </div>
    </div>

    <div class="table_container">
        <asp:GridView runat="server" ID="grdHorarios" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdHorarios_SelectedIndexChanged" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="Día" DataField="Dia"/>
                <asp:BoundField HeaderText="Desde" DataField="Hora_InicioStr"/>
                <asp:BoundField HeaderText="Hasta" DataField="Hora_FinStr"/>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
