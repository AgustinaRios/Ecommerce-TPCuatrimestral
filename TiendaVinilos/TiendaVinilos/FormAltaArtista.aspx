<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormAltaArtista.aspx.cs" Inherits="TiendaVinilos.FormAltaArtista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="ContenedorPrincipal">
        <div class="container-Formularios" style="width: 414px; height: 225px; margin-top: 66px">
                    <div class="row">
                    <asp:Label ID="LblNombre" runat="server" ForeColor="White" Font-Size="Medium"></asp:Label> 
                    </div>
                    <div class="row">
                    <asp:TextBox ID="TxtNombre" runat="server" type="text" placeholder="Ingrese un Artista" class="controls"></asp:TextBox>
                    </div>
                    <div class="row">
                    <div class="col">
                       <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                     </div>
                     <div class="col">
                     <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                     </div>
                     </div>
                       <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>
                     </div>
            </div>
</asp:Content>
