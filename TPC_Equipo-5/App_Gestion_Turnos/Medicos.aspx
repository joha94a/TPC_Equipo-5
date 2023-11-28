<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="App_Gestion_Turnos.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 class="tituloPagina">Gestionar médicos</h3>
    </div>

    <div class="masterMenu">
        <a class="btn btn-primary" href="MedicoView.aspx">Agregar médico</a>
    </div>

    <div class="filter_container">
        <div class="row">
            <div class="control">
                <label class="form-label" for="txtNombre">Nombre</label>
                <input type="text" class="form-control" id="txtNombre" runat="server" style="width: 300px">
            </div>

            <div class="control">
                <label class="form-label" for="txtApellido">Apellido</label>
                <input type="text" class="form-control" id="txtApellido" runat="server" style="width: 300px">
            </div>

            <div class="control">
                <label class="form-label" for="txtMail">Mail</label>
                <input type="text" class="form-control" id="txtMail" runat="server" style="width: 300px">
            </div>

            <div class="control">
                <label class="form-label" for="ddlEspecialidad">Especialidad</label>
                    <asp:DropDownList class="form-select" ID="ddlEspecialidad" runat="server" style="width: 300px"></asp:DropDownList>
            </div>


        </div>

        <div class="row">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnFiltrar_Click" class="btn btn-primary" />
        </div>
    </div>


    <!--Seccion donde se listan los medicos-->
    <div class="table_container">
        <asp:GridView runat="server" ID="grdMedicos" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdMedicos_SelectedIndexChanged" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:TemplateField HeaderText="Especialidades">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="litEspecialidades" Text='<%# GetEspecialidadesDescription(Eval("Especialidades")) %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton" />
            </Columns>
        </asp:GridView>
    </div>



    <!--VISTA PARA LOS MEDICOS

    <div>
        <h3 class="tituloPagina">Mis datos</h3>
    </div>

    <div class="seccionDatosMedico">
        <div class="seccionDatosPersonalesMedico">
            <div class="datosAgrupados">
                <label>Nombre y Apellido:</label>
                     <asp:TextBox ID="TextBoxNombre" runat="server" Enabled="false">Juan Pepito</asp:TextBox>
            </div>

            <div class="datosAgrupados">
                <label>Especialidades:</label>
                <asp:TextBox ID="TextBoxEspecialidad" runat="server" Enabled="false">Obstetra</asp:TextBox>
            </div>

            <div class="datosAgrupados">
                <label>Mail de contacto:</label>
                <asp:TextBox ID="TextBoxMail" runat="server">JuanPepito@gmail.com</asp:TextBox>
                <asp:Button ID="btnEditarMail" runat="server" Text="Editar" />
            </div>

            <div class="datosAgrupados">
                <label>Telefono:</label>
                <asp:TextBox ID="TextBoxTelefono" runat="server">11112222333</asp:TextBox>
                <asp:Button ID="btnEditarTel" runat="server" Text="Editar" />
            </div>
        </div>
    </div>-->
</asp:Content>
