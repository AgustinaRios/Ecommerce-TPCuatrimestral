<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="TiendaVinilos.Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <table class="table">
        <thead class="thead-dark">
            <tr>
            
                <th scope="col" for="txtId">Id</th>
                <th scope="col" for="txtTitulo">Titulo</th>
                <th scope="col">Artista</th>
                <th scope="col">Fecha Lanzamiento</th>
                <th scope="col">Imagen Tapa</th>
                <th scope="col">Imagen Contrata</th>
                <th scope="col">Precio</th>
                <th scope="col">Genero</th>
                <th scope="col">Categoria</th>
                <th scope="col">Modificar</th>
            </tr>
        </thead>
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <tbody>
                    <tr>
         
                        <th scope="row"><%# Eval("Id")%></th>
                        <td><%# Eval("Titulo")%></td>
                        <td><%# Eval("Artista")%></td>
                        <td><%# Eval("FechaLanzamiento")%></td>
                        <td><%# Eval("ImgTapa")%></td>
                        <td><%# Eval("ImgContratapa")%></td>
                        <td><%# Eval("Precio")%></td>
                        <td><%# Eval("Genero")%></td>
                        <td><%# Eval("Categoria")%></td>
  <td> 
      <asp:Button Text="Modificar" Cssclass="btn btn-success" ID="btnModificar" AutoPostBack="true" OnClick="btnModificar_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Id")%>'/>

 </td>
                    </tr>

                </tbody>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <asp:Button ID="BtnAlta" runat="server" Text="Nuevo Vinilo" CssClass="btn btn-outline-success" type="submit" OnClick="BtnAlta_Click" />

    <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnEliminar" runat="server" />


</asp:Content>




