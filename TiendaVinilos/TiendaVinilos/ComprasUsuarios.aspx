<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ComprasUsuarios.aspx.cs" Inherits="TiendaVinilos.ComprasUsuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewPedidos" runat="server" AutoGenerateColumns="False" CssClass="table" EmptyDataText="No hay pedidos disponibles">
        <Columns>
            <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                    <asp:Label ID="lblNombre" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NombreUsuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Apellido">
                <ItemTemplate>
                    <asp:Label ID="lblApellido" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ApellidoUsuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Pedido.FormaEntrega" HeaderText="Forma de Entrega" />
            <asp:BoundField DataField="Pedido.Direccion" HeaderText="Dirección" />
            <asp:BoundField DataField="Pedido.Localidad" HeaderText="Localidad" />
            <asp:BoundField DataField="Pedido.Provincia" HeaderText="Provincia" />
            <asp:BoundField DataField="Pedido.FormaPago" HeaderText="Forma de Pago" />
            <asp:BoundField DataField="Pedido.Total" HeaderText="Total" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Pedido.Estado" HeaderText="Estado del Pedido" />
            <asp:BoundField DataField="Pedido.FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:d}" />
        </Columns>
    </asp:GridView>
</asp:Content>

