<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup ="true" CodeBehind="MisCompras.aspx.cs" Inherits="TiendaVinilos.MisCompras" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="ContenedorPrincipal">
<div class="container-listas">
  
        <asp:GridView ID="GridViewPedidos" runat="server" AutoGenerateColumns="False" CssClass="table" EmptyDataText="No hay pedidos disponibles">
            <Columns>
                <asp:BoundField DataField="FormaEntrega" HeaderText="Forma de Entrega" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                <asp:BoundField DataField="FormaPago" HeaderText="Forma de Pago" />
                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Estado" HeaderText="Estado del Pedido" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:d}" />
            </Columns>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
         </div>
</asp:Content>


