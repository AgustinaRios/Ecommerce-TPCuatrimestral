<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TiendaVinilos.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ContenedorPrincipal">
        <div class="container-Formularios">
            <h4>Mi Perfil</h4>
            <div class="form-inline">
                <label for="TxtNombre">Nombre</label>
                <asp:TextBox ID="TxtNombre" runat="server" class="controls"></asp:TextBox>
            </div>
            <div class="form-inline">
                <label for="TxtApellido">Apellido</label>
                <asp:TextBox ID="TxtApellido" class="controls" aria-label="Apellido" runat="server"></asp:TextBox>
            </div>
            <div class="form-inline">
                <label for="TxtEmail">Email</label>
                <asp:TextBox ID="TxtEmail" CssClass="controls" type="Mail" aria-label="Email" runat="server" />
            </div>
            <div class="form-inline">
                <label for="TxtDireccion">Direccion</label>
                <asp:TextBox ID="TxtDireccion" runat="server" class="controls"></asp:TextBox>
            </div>
            <div class="form-inline">
                <label for="TxtLocalidad">Localidad</label>
                <asp:TextBox ID="TxtLocalidad" runat="server" class="controls"></asp:TextBox>
            </div>
            <div class="form-inline">
                <label for="TxtProvincia">Provincia</label>
                <asp:TextBox ID="TxtProvincia" runat="server" class="controls"></asp:TextBox>
            </div>
            <asp:Button ID="BtnAceptar" Text="GUARDAR CAMBIOS" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" />
            <asp:Button ID="BtnCancelar" Text="CANCELAR" OnClick="BtnCancelar_Click" runat="server" CssClass="btn btn-danger" />

        </div>
    </div>


</asp:Content>
