<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionCompra.aspx.cs" Inherits="TiendaVinilos.ConfirmacionCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            background-image: url('https://img1.wallspic.com/previews/8/3/4/3/13438/13438-disco_de_vinilo-x750.jpg');
            background-size: cover;
            background-position: center;
            font-family: Arial, sans-serif;
            color: #333;
            margin: 0;
            padding: 0;
        }

        .page-container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.8);
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
        }

        .page-title {
            font-size: 24px;
            margin-bottom: 10px;
        }

        .order-info {
            margin-bottom: 20px;
        }

        .order-label {
            font-weight: bold;
        }

        .order-value {
            font-weight: normal;
        }

        .address-info {
            margin-bottom: 20px;
        }

        .total-info {
            margin-top: 20px;
        }

        .total-value {
            font-weight: bold;
            font-size: 18px;
        }
    </style>

    <div class="page-container">
        <h2 class="page-title">Confirmación de Compra</h2>

        <div class="order-info">
            <label class="order-label">Número de Orden:</label>
            <asp:Label ID="LblIdPedido" runat="server" CssClass="order-value"></asp:Label>
        </div>

        <div class="address-info">
            <label>Dirección de Envío:</label>
            <asp:Label ID="LblDireccion" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LblLocalidad" runat="server"></asp:Label>,
            <asp:Label ID="LblProvincia" runat="server"></asp:Label>
        </div>

        <asp:GridView ID="GridViewProductos" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="Titulo" HeaderText="Título" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

        <div class="total-info">
            <label>Total de la Compra:</label>
            <asp:Label ID="LblTotal" runat="server" CssClass="total-value"></asp:Label>
        </div>

        <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
    </div>
</asp:Content>

