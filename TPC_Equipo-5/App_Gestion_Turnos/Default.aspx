<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App_Gestion_Turnos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container py-5 h-50">
                    <div class="row d-flex justify-content-center align-items-center h-50">
                        <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                            <div class="card bg-dark text-white" style="border-radius: 1rem;">
                                <div class="card-body p-4 text-center">
                                    <div class="mb-md-2 mt-md-2">
                                        <h3 class="fw-bold mb-2 text-uppercase">Iniciar sesión</h3>
                                        <p class="text-white-50 mb-5">Ingrese su usuario y contraseña</p>

                                        <div class="form-outline form-white mb-4">
                                            <asp:Label Text="Usuario" runat="server" CssClass="form-label" />
                                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                                            <div ID="lblValidacionUsuario" runat="server" class="invalid-feedback" style="display:block"></div>
                                        </div>

                                        <div class="form-outline form-white mb-4">
                                            <asp:Label ID="lblPassword" CssClass="form-label" runat="server" Text="Contraseña" for="txtPassword"></asp:Label>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                                            <div ID="lblValidacionPassword" runat="server" class="invalid-feedback" style="display:block"></div>
                                        </div>

                                        <p class="small mb-3 pb-lg-1"><a class="text-white-50" href="#!">Olvidó su contraseña?</a></p>
                                        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-outline-light btn-lg px-5" OnClick="btnLogin_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>
