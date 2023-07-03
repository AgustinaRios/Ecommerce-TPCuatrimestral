<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="FormAltaGenero.aspx.cs" Inherits="TiendaVinilos.FormAltaGenero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="CuerpoRegistro">
            <div class="FormularioRegistro">
                <asp:Label ID="LblNombre" runat="server" Text="Nuevo Genero"></asp:Label>
                <div>
                    <asp:TextBox ID="TxtNombre" runat="server" type="text" placeholder="Ingrese un genero" class="controls"></asp:TextBox>
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
