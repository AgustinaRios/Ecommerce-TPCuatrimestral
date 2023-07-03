<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormAltaArtista.aspx.cs" Inherits="TiendaVinilos.FormAltaArtista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="CuerpoRegistro">
            <div class="FormularioRegistro">
                <asp:Label ID="LblNombre" runat="server" Text="Nuevo Artista"></asp:Label>
                <div>
                    <asp:TextBox ID="TxtNombre" runat="server" type="text" placeholder="Ingrese un Artista" class="controls"></asp:TextBox>
                </div>
                <updatepanel>
                    <contentemplate>
                        <br />
                       <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                        <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                        <div>
                            <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
                        </div>
            </div>
        </div>

</asp:Content>
