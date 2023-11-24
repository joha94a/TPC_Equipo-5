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
                        <asp:DropDownList CssClass="form-select" ID="cmbPerfilAcceso" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbPerfilAcceso_SelectedIndexChanged"></asp:DropDownList>
                        <div id="lblValidacionPerfilAcceso" runat="server" class="invalid-feedback"></div>
                    </div>


                    <%
                    if (cmbPerfilAcceso.SelectedValue == "1") // Perfil de médico
                    {
                    %>

                            <div class="mb-3">
                                <asp:Label ID="lblMedico" CssClass="form-label" runat="server" Text="Médico:" for="txtMedico"></asp:Label>
                                <asp:TextBox ID="txtMedico" runat="server" CssClass="form-control" Enabled="false" />
                                <div id="lblValidacionMedico" runat="server" class="invalid-feedback"></div>
                            </div>
                            <div class="mb-3">
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
                    }
                    %>


                    <div class="masterMenu">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                        <asp:Button ID="btnDarDeBaja" runat="server" Text="Dar de baja" CssClass="btn btn-danger" data-bs-toggle="modal" data-bs-target="#bajaModal" />
                        <asp:Button ID="btnActivar" runat="server" Text="Activar" CssClass="btn btn-warning" OnClick="btnActivar_Click" />
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-return" OnClick="btnVolver_Click" />
                    </div>



                    </div>


                                        
            </ContentTemplate>
        </asp:UpdatePanel>

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
</asp:Content>
