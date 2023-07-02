<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Carrito.aspx.cs" Inherits="TiendaVinilos.Carrito" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="CuerpoRegistro">
    <table class="table table-striped">
  
    <thead>
     <tr>
        
      <th scope="col">Titulo </th>
      <th scope="col">Artista</th>
      <th scope="col">Genero</th>
       <th scope="col">Categoria</th>
         <th scope="col">Accion</th>
    </tr>
       </thead>
     <tbody>
         <asp:Repeater runat="server" ID="repetidorCarrito">
            <ItemTemplate>
                     <tr>
                     <th><p><%#Eval("Producto.Titulo")%></p></th>
                     <th><p><%#Eval("Producto.Artista")%></p></th>
                     <th><p><%#Eval("Producto.Genero.Descripcion")%></p></th>
                     <th><p><%#Eval("Producto.Categoria.Descripcion")%></p></th>
                     <th>
                        <asp:TextBox TextMode="Number" runat="server" OnTextChanged="txtCantidad_TextChanged" text='<%#Eval("Cantidad")%>' ID="txtCantidad" min="1"/>
                        <asp:Button Text="Agregar" CssClass="btn btn-primary"  ID="btnAgregar" AutoPostBack="true" OnClick="btnAgregar_Click"  CommandArgument='<%#Eval("Producto.Id")%>' runat="server" />
                     <asp:Button Text="Eliminar" CssClass="btn btn-danger"  ID="btnEliminar" AutoPostBsack="true" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("Producto.Id")%>' runat="server" />
                     </th>
                     </tr>
            </ItemTemplate> 
        </asp:Repeater>
           
    </tbody>
    </table>
<p>Total: <asp:Label ID="lblTotal" runat="server" OnLoad="lblTotal_Load" /></p>
     <asp:Button Text="Realizar Compras" CssClass="btn btn-danger"  ID="BtnComprar" Onclick="BtnComprar_Click" runat="server" ToolTip="Comprar Vinilos" />
   </div>      
</asp:Content>