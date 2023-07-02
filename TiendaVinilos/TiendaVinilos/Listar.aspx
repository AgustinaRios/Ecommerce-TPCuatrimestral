﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="Listar.aspx.cs" Inherits="TiendaVinilos.Listar" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <div class="CuerpoRegistro">

    <table class="table-hover"">
        <thead class="thead-dark">
            <tr>

                
                <th scope="col">Titulo</th>
                <th scope="col">Artista</th>
                <th scope="col">Fecha Lanzamiento</th> 
                <th scope="col">Imagen Tapa</th>
                <th scope="col">Imagen Contrata</th>
                <th scope="col">Precio</th>
                <th scope="col">Genero</th>
                <th scope="col"><svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 512 512">
                                    <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                    <path d="M4.1 38.2C1.4 34.2 0 29.4 0 24.6C0 11 11 0 24.6 0H133.9c11.2 0 21.7 5.9 27.4 15.5l68.5 114.1c-48.2 6.1-91.3 28.6-123.4 61.9L4.1 38.2zm503.7 0L405.6 191.5c-32.1-33.3-75.2-55.8-123.4-61.9L350.7 15.5C356.5 5.9 366.9 0 378.1 0H487.4C501 0 512 11 512 24.6c0 4.8-1.4 9.6-4.1 13.6zM80 336a176 176 0 1 1 352 0A176 176 0 1 1 80 336zm184.4-94.9c-3.4-7-13.3-7-16.8 0l-22.4 45.4c-1.4 2.8-4 4.7-7 5.1L168 298.9c-7.7 1.1-10.7 10.5-5.2 16l36.3 35.4c2.2 2.2 3.2 5.2 2.7 8.3l-8.6 49.9c-1.3 7.6 6.7 13.5 13.6 9.9l44.8-23.6c2.7-1.4 6-1.4 8.7 0l44.8 23.6c6.9 3.6 14.9-2.2 13.6-9.9l-8.6-49.9c-.5-3 .5-6.1 2.7-8.3l36.3-35.4c5.6-5.4 2.5-14.8-5.2-16l-50.1-7.3c-3-.4-5.7-2.4-7-5.1l-22.4-45.4z" />
                                </svg></th>
                <th scope="col">Activo</th>
                <th scope="col">Accion</th>
                <th scope="col">Accion</th>
            </tr>
            <tr>
             <asp:Button ID="BtnAlta" runat="server" Text="Nuevo Vinilo" CssClass="btn btn-outline-success" type="submit" OnClick="BtnAlta_Click" />
             </tr>
        </thead>
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <tbody>
                    <tr>

                        
                        <td><%# Eval("Titulo")%></td>
                        <td><%# Eval("Artista")%></td>
                        <td><%# Eval("FechaLanzamiento")%></td>
                        <td>
                            <img src='<%# Eval("ImgTapa") %>' class="ImgItemListar" alt="Imagen del producto" />
                        </td>
                         <td>
                            <img src='<%# Eval("ImgContratapa")%>' class="ImgItemListar" alt="Imagen del producto" />
                        </td>
                       
                      
                        <td><%# Eval("Precio")%></td>
                        <td><%# Eval("Genero")%></td>
                        <td><%# Eval("Categoria")%></td>
                         <td><%# Eval("Activo")%></td>
                        
                         <td>
                        <asp:Button Text="Modificar" Cssclass="btn btn-success" ID="btnModificar" AutoPostBack="true" OnClick="btnModificar_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Id")%>'/>
                       </td>
                       <td> 

                           <asp:Button Text="Eliminar" Cssclass="btn btn-danger" ID="btnEliminar" OnClientClick="return confirm('Esta seguro que quiere eleminar este album ?');" OnClick="btnEliminar_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Id")%> '/>  
                       </td>
                   </tr>
                </tbody>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <asp:Label ID="lblMensaje" runat="server" CssClass="message" Visible="false"></asp:Label>

        </div>

</asp:Content>




