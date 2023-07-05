<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCompra.aspx.cs" Inherits="TiendaVinilos.FormularioCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <updatepanel>



        <div class="CuerpoRegistro">
            <div class="FormularioRegistro ">
                <asp:Label ID="Lbltitlulo" runat="server" Font-Size="Smaller"></asp:Label>
                <div>

                    <asp:DropDownList runat="server" ID="ddlFormaEntrega" class="form-control" AutoPostBack="true" />

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

                    <asp:DropDownList runat="server" ID="ddlFormaPago" class="form-control" AutoPostBack="true" />
                    <% 
                        if (ddlFormaPago.SelectedIndex == 2)
                        {%>
                    <a href="https://www.mercadopago.com.ar/"target="_blank">Logo Mercado</a>
                    <%}
                        if (ddlFormaPago.SelectedIndex == 3)
                        { %>

                    <div class="form-inline">
                        <label for="TxtNroTarjeta">Numero Tarjeta</label>
                        <asp:TextBox ID="TxtNroTarjeta" runat="server" class="controls"></asp:TextBox>
                    </div>
                    <div class="form-inline">
                        <label for="TxtCodSeguridad">Codigo Seguridad</label>
                        <asp:TextBox ID="TxtCodSeguridad" runat="server" class="controls small"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblFechaVto" runat="server" Text="Fecha Vencimiento" Font-Size="Small"></asp:Label>

                    <asp:TextBox ID="TxtFechaVto" class="form-control" type="date" runat="server"></asp:TextBox>

                    <%} %>
                      <asp:Button ID="BtnAceptar" Text="ENTRAR" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                 

                </div>
            </div>

            <updatepanel>
                <contentemplate>
                    <br />

                    <div>
                        <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
                    </div>
        </div>




    </updatepanel>
</asp:Content>
