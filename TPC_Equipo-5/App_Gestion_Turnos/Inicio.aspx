<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="App_Gestion_Turnos.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg bg-info navbar-dark">
        <div class="container-fluid navbarStyle">
            <!-- Navbar brand -->
            <a class="nav-link text-white" href="#"><i class="bi bi-house-door mx-1" style="font-size: 1.5rem"></i>Inicio</a>
            <!-- Icons -->
            <ul class="navbar-nav d-flex flex-row me-1">
                <li class="nav-item me-3 me-lg-2">
                    <a class="nav-link text-white" href="Turnos.aspx"><i class="bi bi-calendar-range mx-1" style="font-size: 1.5rem"></i>Turnos</a>
                </li>
                <li class="nav-item me-3 me-lg-2">
                    <a class="nav-link text-white" href="#"><i class="bi bi-prescription2 mx-1" style="font-size: 1.5rem"></i>Medicos</a>
                </li>
                <li class="nav-item me-3 me-lg-2">
                    <a class="nav-link text-white" href="Pacientes.aspx"><i class="bi bi-person-fill mx-1" style="font-size: 1.5rem"></i>Pacientes</a>
                </li>
            </ul>
        </div>
    </nav>

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
