<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="App_Gestion_Turnos.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="seccionInicioRecep">
        <h3>Turnos a reprogramar</h3>
        <div class="turnosYnovedades">
            <div class="seccionTurnosRepc">
                    <table class="table table-hover table-bordered" style="width: 90%;">
                        <thead>
                            <tr>
                                <th scope="col">Número</th>
                                <th scope="col">Fecha</th>
                                <th scope="col">Hora</th>
                                <th scope="col">Médico</th>
                                <th scope="col">Paciente</th>
                                <th scope="col"></th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
            </div>

            <div class="seccionNovedadRepc">
                <!--espacio para novedades para el recepcionista-->
                
            </div>
        </div>

    </section>


</asp:Content>
