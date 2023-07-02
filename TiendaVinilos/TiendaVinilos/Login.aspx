<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaVinilos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
        <div class="CuerpoRegistro">
            <div class="FormularioRegistro">
                <h4>Ingrese su Cuenta</h4>
                <asp:TextBox ID="TxtEmail" class="controls" type="Mail" placeholder="Ingrese su Email" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtPass" class="controls" type="password" placeholder="Ingrese su Contraseña" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
                <asp:Button ID="BtnAceptar" Text="ENTRAR" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                <asp:Button Text="Cancelar" CssClass="btn btn-outline-info" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />

                <p><a href="RegistrarCuenta.aspx" aria-describedby="cxcxxcxc">Registrarme</a></p>
            </div>
        </div>




</asp:Content>
