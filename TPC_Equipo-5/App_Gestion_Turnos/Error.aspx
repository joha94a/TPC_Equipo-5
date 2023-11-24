<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="App_Gestion_Turnos.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="m-5">
                <h1 style="color:brown">Error:</h1>
                <asp:Label ID="lblError" runat="server" Text="Página de error" ForeColor="Brown"></asp:Label>
            </div>
            <div class="m-5">
                <asp:Button ID="btnVolverAInicio" runat="server" Text="Volver a inicio" CssClass="btn btn-return" OnClick="btnVolverAInicio_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
