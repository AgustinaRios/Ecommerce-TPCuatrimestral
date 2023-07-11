<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComprasUsuarios.aspx.cs" Inherits="TiendaVinilos.ComprasUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContenedorPrincipal">
        <div class="container-listas">

            <table>
                <thead>

                    <tr style="color: #000000; background-color: #243ed3">
                        <th scope="col">Id</th>
                        <th scope="col">Apellido</th>
                        <th scope="col">Nombre</th>
                         <th scope="col">Modo de Entrega</th>
                            <th scope="col">Direccion</th>
                        <th scope="col">Localidad</th>
                        <th scope="col">Provincia</th>
                       
                        <th scope="col">
                            <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512">
                                <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                <path d="M64 64C28.7 64 0 92.7 0 128V384c0 35.3 28.7 64 64 64H512c35.3 0 64-28.7 64-64V128c0-35.3-28.7-64-64-64H64zM272 192H496c8.8 0 16 7.2 16 16s-7.2 16-16 16H272c-8.8 0-16-7.2-16-16s7.2-16 16-16zM256 304c0-8.8 7.2-16 16-16H496c8.8 0 16 7.2 16 16s-7.2 16-16 16H272c-8.8 0-16-7.2-16-16zM164 152v13.9c7.5 1.2 14.6 2.9 21.1 4.7c10.7 2.8 17 13.8 14.2 24.5s-13.8 17-24.5 14.2c-11-2.9-21.6-5-31.2-5.2c-7.9-.1-16 1.8-21.5 5c-4.8 2.8-6.2 5.6-6.2 9.3c0 1.8 .1 3.5 5.3 6.7c6.3 3.8 15.5 6.7 28.3 10.5l.7 .2c11.2 3.4 25.6 7.7 37.1 15c12.9 8.1 24.3 21.3 24.6 41.6c.3 20.9-10.5 36.1-24.8 45c-7.2 4.5-15.2 7.3-23.2 9V360c0 11-9 20-20 20s-20-9-20-20V345.4c-10.3-2.2-20-5.5-28.2-8.4l0 0 0 0c-2.1-.7-4.1-1.4-6.1-2.1c-10.5-3.5-16.1-14.8-12.6-25.3s14.8-16.1 25.3-12.6c2.5 .8 4.9 1.7 7.2 2.4c13.6 4.6 24 8.1 35.1 8.5c8.6 .3 16.5-1.6 21.4-4.7c4.1-2.5 6-5.5 5.9-10.5c0-2.9-.8-5-5.9-8.2c-6.3-4-15.4-6.9-28-10.7l-1.7-.5c-10.9-3.3-24.6-7.4-35.6-14c-12.7-7.7-24.6-20.5-24.7-40.7c-.1-21.1 11.8-35.7 25.8-43.9c6.9-4.1 14.5-6.8 22.2-8.5V152c0-11 9-20 20-20s20 9 20 20z" />
                            </svg></th>

                        <th scope="col">Total</th>
                        <th scope="col">Fecha de Venta</th>
                        <th scope="col">Estado de Entrega</th> 
                        <th scope="col">
                            <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 512 512">
                                <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                <path d="M368.4 18.3L312.7 74.1 437.9 199.3l55.7-55.7c21.9-21.9 21.9-57.3 0-79.2L447.6 18.3c-21.9-21.9-57.3-21.9-79.2 0zM288 94.6l-9.2 2.8L134.7 140.6c-19.9 6-35.7 21.2-42.3 41L3.8 445.8c-3.8 11.3-1 23.9 7.3 32.4L164.7 324.7c-3-6.3-4.7-13.3-4.7-20.7c0-26.5 21.5-48 48-48s48 21.5 48 48s-21.5 48-48 48c-7.4 0-14.4-1.7-20.7-4.7L33.7 500.9c8.6 8.3 21.1 11.2 32.4 7.3l264.3-88.6c19.7-6.6 35-22.4 41-42.3l43.2-144.1 2.8-9.2L288 94.6z" />
                            </svg></th>

                    </tr>

                </thead>


                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <tbody>

                            <tr>
                                <td><%# Eval("Pedido.Id") %></td>
                                <td><%# Eval("NombreUsuario") %></td>
                                <td><%# Eval("ApellidoUsuario") %></td>
                                <td><%# Eval("Pedido.FormaEntrega") %></td>
                                <td><%# Eval("Pedido.Direccion") %></td>
                                <td><%# Eval("Pedido.Localidad") %></td>
                                <td><%# Eval("Pedido.Provincia") %></td>
                                <td><%# Eval("Pedido.FormaPago") %></td>
                                <td><%# Eval("Pedido.Total") %></td>
                                <td><%# Eval("Pedido.FechaCreacion") %></td>
                                <td><%# Eval("Pedido.Estado") %></td>
                                <td>
                                    <asp:Button Text="Modificar" CssClass="btn btn-secondary" ID="btnModificar" AutoPostBack="true" OnClick="btnModificar_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Pedido.Id")%>' />
                                </td>

                            </tr>
                        </tbody>
                    </ItemTemplate>

                </asp:Repeater>
            </table>
</div>
        </div>
</asp:Content>
