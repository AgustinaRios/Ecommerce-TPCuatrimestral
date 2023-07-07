<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DomicilioEntrega.aspx.cs" Inherits="TiendaVinilos.Domicilio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="CuerpoRegistro">
            <div class="FormularioRegistro">
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
            <asp:Button ID="BtnAceptar" Text="Cambiar el domicilio " OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" />
            <asp:Button ID="BtnCancelar" Text="CANCELAR" OnClick="BtnCancelar_Click" runat="server" CssClass="btn btn-danger" />
                  <div>
                        <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
                    </div>
            </div>
        </div>
</asp:Content>
