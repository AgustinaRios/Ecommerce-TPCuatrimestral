<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCompra.aspx.cs" Inherits="TiendaVinilos.FormularioCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="CuerpoRegistro">

        <div class="FormularioRegistro ">
            <asp:Label ID="Lbltitlulo" runat="server" Font-Size="Smaller"></asp:Label>
            <div>

                <asp:TextBox ID="TxtTitulo" runat="server" type="text" placeholder="Ingrese un Titulo" class="controls"></asp:TextBox>
                <asp:DropDownList runat="server" ID="ddlFormaEntrega" class="form-control" AutoPostBack="true" />
                <asp:DropDownList runat="server" ID="ddlFormaPago" class="form-control" AutoPostBack="true" />
                <updatepanel>

                <%if (ddlFormaEntrega.SelectedIndex==1)
            
                    { %>
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
                <%} %>
                        </updatepanel>

            </div>
        </div>

        <updatepanel>
            <contentemplate>
                <br />

                <div>
                    <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
                </div>
    </div>




</asp:Content>
