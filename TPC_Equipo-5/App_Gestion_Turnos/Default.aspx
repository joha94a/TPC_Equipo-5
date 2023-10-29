<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App_Gestion_Turnos.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--LOGIN DE EJEMPLO - HAY QUE MODIFICAR ESTO-->
   <section>
  <div class="container py-5 h-50">
    <div class="row d-flex justify-content-center align-items-center h-50">
      <div class="col-12 col-md-8 col-lg-6 col-xl-5">
        <div class="card bg-dark text-white" style="border-radius: 1rem;">
          <div class="card-body p-4 text-center">
            <div class="mb-md-2 mt-md-2">
              <h3 class="fw-bold mb-2 text-uppercase">Iniciar sesión</h3>
              <p class="text-white-50 mb-5">Ingrese su usuario y contraseña</p>

              <div class="form-outline form-white mb-4">
                <input type="text" id="typeUser" class="form-control" />
                <label class="form-label" for="typeUser">Usuario</label>
              </div>

              <div class="form-outline form-white mb-4">
                <input type="password" id="typePasswordX" class="form-control" />
                <label class="form-label" for="typePasswordX">Contraseña</label>
              </div>

              <p class="small mb-3 pb-lg-1"><a class="text-white-50" href="#!">Olvidó su contraseña?</a></p>
                <!--
                     <asp:Button ID="button_ingresar" runat="server" Text="Ingresar" href="Inicio.aspx" class="btn btn-outline-light btn-lg px-5" type="submit" />
-->
              <a href="Inicio.aspx" class="btn btn-outline-light btn-lg px-5">Ingresar</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</asp:Content>
