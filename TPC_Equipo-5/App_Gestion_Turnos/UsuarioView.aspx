<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioView.aspx.cs" Inherits="App_Gestion_Turnos.UsuarioView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_container">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label ID="lblNombre_Usuario" CssClass="form-label" runat="server" Text="Nombre de usuario:" for="txtNombre_Usuario"></asp:Label>
                        <asp:TextBox ID="txtNombre_Usuario" runat="server" CssClass="form-control" AutoCompleteType="Disabled" />
                        <div id="lblValidacionNombre_Usuario" runat="server" class="invalid-feedback"></div>
                    </div>
                
                    <div class="mb-3">
                        <asp:Label ID="lblNuevaContrasena" CssClass="form-label" runat="server" Text="Nueva contraseña:" for="txtNuevaContrasena"></asp:Label>
                        <asp:TextBox ID="txtNuevaContrasena" runat="server" CssClass="form-control" TextMode="Password" />
                        <div id="lblValidacionNuevaContrasena" runat="server" class="invalid-feedback"></div>
                    </div>
                
                    <div class="mb-3">
                        <asp:Label ID="lblRepNuevaContrasena" CssClass="form-label" runat="server" Text="Repita nueva contraseña:" for="txtRepNuevaContrasena"></asp:Label>
                        <asp:TextBox ID="txtRepNuevaContrasena" runat="server" CssClass="form-control" TextMode="Password" />
                        <div id="lblValidacionRepNuevaContrasena" runat="server" class="invalid-feedback"></div>
                    </div>
               
                    <div class="mb-3">
                        <asp:Label ID="lblPerfilAcceso" CssClass="form-label" runat="server" Text="Tipo:" for="cmbPerfilAcceso"></asp:Label>
                        <asp:DropDownList CssClass="form-select" ID="cmbPerfilAcceso" runat="server" AutoPostBack="true"></asp:DropDownList>
                        <div id="lblValidacionPerfilAcceso" runat="server" class="invalid-feedback"></div>
                    </div>


                    <%
                    if (cmbPerfilAcceso.SelectedValue == "1")
                    {
                    %>

                            <div class="mb-3">
                                <asp:Label ID="lblMedico" CssClass="form-label" runat="server" Text="Médico:" for="txtMedico"></asp:Label>
                                <asp:TextBox ID="txtMedico" runat="server" CssClass="form-control" Enabled="false" />
                            </div>
                            <div class="mb-3">
                                <asp:Button ID="btnMedico" runat="server" Text="Cambiar Médico" OnClick="btnMedico_Click" class="btn btn-primary" />
                            </div>
                        <%      
                        if (SeccionMedicoVisible)
                        {
                        %>
                            
                            <div class="mb-3">
                                <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="AAAAAAAAAAAAAAA:" for="txtMedico"></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"/>
                            </div>
                            <div class="mb-3">
                                <asp:Button ID="Button1" runat="server" Text="Aceptar" class="btn btn-primary" />
                            </div>
    
                        <%
                        }
                    }
                    %>


                    <div class="masterMenu">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                        <%if (Id > 1)
                            {%>
                        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#bajaModal">Dar de baja</button>
                        <%}
                            else
                            {%>
                        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#bajaModal" disabled="disabled">Dar de baja</button>
                        <%}%>
                        <a class="btn btn-return" href="Usuarios.aspx">Volver</a>
                    </div>

                    <div class="modal fade" id="bajaModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h1 class="modal-title fs-5" id="exampleModalLabel">Dar de baja</h1>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    ¿Desea dar de baja el usuario?
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-return" data-bs-dismiss="modal">Cancelar</button>
                                    <asp:Button ID="btnBaja" runat="server" Text="Dar de baja" OnClick="btnBaja_Click" class="btn btn-danger" />
                                </div>
                            </div>
                        </div>
                    </div>

                    </div>


                                        
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
