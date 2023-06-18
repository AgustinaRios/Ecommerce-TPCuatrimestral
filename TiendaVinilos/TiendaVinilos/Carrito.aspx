<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TiendaVinilos.Carrito" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-striped">
  
    <thead>
     <tr>
        
      <th scope="col">Titulo </th>
      <th scope="col">Artista</th>
      <th scope="col">FechaLanzamiento</th>
      <th scope="col">ImgTapa</th>
      <th scope="col">ImgContratapa</th>
      <th scope="col">Genero</th>
       <th scope="col">Categoria</th>
         <th scope="col">Accion</th>
    </tr>
       </thead>
     <tbody>
        
       <tr>
      <th scope="col">En vivo </th>
      <th scope="col">NTVG</th>
      <th scope="col">12/11/2020</th>
      <th scope="col">ImgTapa</th>
      <th scope="col">ImgContratapa</th>
      <th scope="col">Rock</th>
      <th scope="col">Mas Vendidos</th>
      <th>
       <asp:TextBox TextMode="Number" runat="server" text="1" ID="txtCantidad" min="1"/>
       <asp:Button Text="Agregar"  CssClass="btn btn-primary"  ID="btnAgregar"    runat="server" ToolTip="Agregar vinilo al carrito" />             
      <asp:Button Text="Eliminar" CssClass="btn btn-danger"  ID="btnEliminar"   runat="server" ToolTip="Eliminar Vinilo del carrito" />
      </th>
      </tr>
           
    </tbody>
    </table>
<p>Total: <asp:Label ID="lblTotal" runat="server" text="200" /></p>
     <asp:Button Text="Realizar Compras" CssClass="btn btn-danger"  ID="BtnComprar" Onclick="BtnComprar_Click" runat="server" ToolTip="Comprar Vinilos" />
         
</asp:Content>