<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Carrito.aspx.cs" Inherits="TiendaVinilos.Carrito" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="ContenedorPrincipal">
<div class="container-listas">
    <table class="table table-striped">
    <thead>
    <tr style="color: #000000 ;background-color:#243ed3">
        
      <th scope="col">Titulo </th>
      <th scope="col">Artista</th>
      <th scope="col"><svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 512 512"><!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d="M499.1 6.3c8.1 6 12.9 15.6 12.9 25.7v72V368c0 44.2-43 80-96 80s-96-35.8-96-80s43-80 96-80c11.2 0 22 1.6 32 4.6V147L192 223.8V432c0 44.2-43 80-96 80s-96-35.8-96-80s43-80 96-80c11.2 0 22 1.6 32 4.6V200 128c0-14.1 9.3-26.6 22.8-30.7l320-96c9.7-2.9 20.2-1.1 28.3 5z"/></svg></th>
      <th scope="col"><svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 512 512">  <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --> <path d="M4.1 38.2C1.4 34.2 0 29.4 0 24.6C0 11 11 0 24.6 0H133.9c11.2 0 21.7 5.9 27.4 15.5l68.5 114.1c-48.2 6.1-91.3 28.6-123.4 61.9L4.1 38.2zm503.7 0L405.6 191.5c-32.1-33.3-75.2-55.8-123.4-61.9L350.7 15.5C356.5 5.9 366.9 0 378.1 0H487.4C501 0 512 11 512 24.6c0 4.8-1.4 9.6-4.1 13.6zM80 336a176 176 0 1 1 352 0A176 176 0 1 1 80 336zm184.4-94.9c-3.4-7-13.3-7-16.8 0l-22.4 45.4c-1.4 2.8-4 4.7-7 5.1L168 298.9c-7.7 1.1-10.7 10.5-5.2 16l36.3 35.4c2.2 2.2 3.2 5.2 2.7 8.3l-8.6 49.9c-1.3 7.6 6.7 13.5 13.6 9.9l44.8-23.6c2.7-1.4 6-1.4 8.7 0l44.8 23.6c6.9 3.6 14.9-2.2 13.6-9.9l-8.6-49.9c-.5-3 .5-6.1 2.7-8.3l36.3-35.4c5.6-5.4 2.5-14.8-5.2-16l-50.1-7.3c-3-.4-5.7-2.4-7-5.1l-22.4-45.4z" /></svg></th> 
      <th scope="col"><svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 448 512"><!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d="M256 80c0-17.7-14.3-32-32-32s-32 14.3-32 32V224H48c-17.7 0-32 14.3-32 32s14.3 32 32 32H192V432c0 17.7 14.3 32 32 32s32-14.3 32-32V288H400c17.7 0 32-14.3 32-32s-14.3-32-32-32H256V80z"/></svg></th>
      <th scope="col"><svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 448 512"><!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d="M135.2 17.7C140.6 6.8 151.7 0 163.8 0H284.2c12.1 0 23.2 6.8 28.6 17.7L320 32h96c17.7 0 32 14.3 32 32s-14.3 32-32 32H32C14.3 96 0 81.7 0 64S14.3 32 32 32h96l7.2-14.3zM32 128H416V448c0 35.3-28.7 64-64 64H96c-35.3 0-64-28.7-64-64V128zm96 64c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16zm96 0c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16zm96 0c-8.8 0-16 7.2-16 16V432c0 8.8 7.2 16 16 16s16-7.2 16-16V208c0-8.8-7.2-16-16-16z"/></svg></th>
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
                     </th>
                         <th>
                         <asp:Button Text="Eliminar" CssClass="btn btn-danger"  ID="btnEliminar" AutoPostBsack="true" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("Producto.Id")%>' runat="server" />
                           
                              <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>
                               
                         </th>
                     </tr>
            </ItemTemplate> 
        </asp:Repeater>
       


    </tbody>
    </table>

    <p style="color: #FF0000" Font-Size="XX-Large">TOTAL: <asp:Label ID="lblTotal" runat="server" OnLoad="lblTotal_Load" ForeColor="Red" Font-Size="XX-Large" /></p>
    <asp:Label ID="Label2" ForeColor="red" runat="server" Visible="false" Font-Size="30px"></asp:Label>
   <asp:Button Text="Comenzar la Compra" CssClass="btn btn-danger"  ID="BtnComprar" Onclick="BtnComprar_Click" runat="server" ToolTip="Comprar Vinilos" />
   </div> 
    
   </div>    
</asp:Content>