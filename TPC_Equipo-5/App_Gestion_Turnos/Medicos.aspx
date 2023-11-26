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

    <div class="seccionFiltros">
        <asp:Label ID="lblFiltro" runat="server" Text="Buscar médico:"></asp:Label>
        <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
    </div>
    <div class="seccionAgregar">
        <!--seccion para boton agregar medico-->
    </div>
    
    <asp:GridView runat="server" ID="grdMedicos" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdMedicos_SelectedIndexChanged" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
    <Columns>
        <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
        <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
        <asp:BoundField HeaderText="Mail" DataField="Mail"/>
        <asp:TemplateField HeaderText="Especialidades">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litEspecialidades" Text='<%# GetEspecialidadesDescription(Eval("Especialidades")) %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowSelectButton="true" SelectText="VER" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton"/>
    </Columns>
</asp:GridView>



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
