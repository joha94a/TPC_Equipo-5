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
                    <a class="nav-link text-white" href="#"><i class="bi bi-person-fill mx-1" style="font-size: 1.5rem"></i>Pacientes </a>
                </li>
            </ul>
        </div> 
    </nav>

    <h1>Este es el inicio</h1>
</asp:Content>
