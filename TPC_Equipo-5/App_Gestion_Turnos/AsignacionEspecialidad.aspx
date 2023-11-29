<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignacionEspecialidad.aspx.cs" Inherits="App_Gestion_Turnos.AsignacionEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form_container">
        <div class="row column2">
            <div class="control">
                <label class="form-label" for="txtMedico">Medico:</label>
                <input type="text" class="form-control" id="txtMedico" runat="server" style="width: 300px" disabled="disabled">
            </div>

            <div class="table_container">
                <asp:GridView runat="server" ID="grdEspecialidades" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="grdEspecialidades_SelectedIndexChanged" DataKeyNames="Id" ShowHeaderWhenEmpty="True" EmptyDataText="Sin especialidad">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />

                        <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderText="" ControlStyle-CssClass="btn btn-primary gridButton" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>

        <div class="row column">
            <div class="control">
                <label class="form-label" for="ddlEspecialidad">Especialidad</label>
                <asp:DropDownList class="form-select" ID="ddlEspecialidad" runat="server" Style="width: 300px"></asp:DropDownList>
            </div>
        </div>

        <div class="row column">
            <div class="control">
                <asp:Button ID="AgregarEspecialidad" Text="Agregar" CssClass="btn btn-primary" runat="server" OnClick="AgregarEspecialidad_Click" />

            </div>
        </div>

    </div>
</asp:Content>
