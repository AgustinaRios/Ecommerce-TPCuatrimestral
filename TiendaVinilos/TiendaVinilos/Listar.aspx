<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="Listar.aspx.cs" Inherits="TiendaVinilos.Listar" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <table class="table">
        <thead class="thead-dark">
            <tr>

                
                <th scope="col" for="txtTitulo">Titulo</th>
                <th scope="col">Artista</th>
                <th scope="col">Fecha Lanzamiento</th>
                <th scope="col">Imagen Tapa</th>
                <th scope="col">Imagen Contrata</th>
                <th scope="col">Precio</th>
                <th scope="col">Genero</th>
                <th scope="col">Categoria</th>
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

        

</asp:Content>




