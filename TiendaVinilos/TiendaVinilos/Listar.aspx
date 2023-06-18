<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="TiendaVinilos.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-striped">
  
    <thead>
     <tr>
        
      <th scope="col">Titulo </th>
      <th scope="col">Artista</th>
      <th scope="col">FechaLanzamiento</th>
    <%--  <th scope="col">ImgTapa</th>
      <th scope="col">ImgContratapa</th>--%>
      <th scope="col">Genero</th>
      <th scope="col">Categoria</th>    
      <th> <asp:Button ID="BtnAlta" runat="server" Text="Nuevo Vinilo" Cssclass="btn btn-outline-success" type="submit"  onclick="BtnAlta_Click" /> </th>   
    </tr>
      
     </thead>
     <tbody>
        <% 
            foreach (Dominio.Album album in listaAlbum)
            {
        %> 
        
        <tr>
      <th scope="col">><%:album.Titulo%></th>
      <th scope="col"> <%:album.Artista %></th>
      <th scope="col"> <%:album.FechaLanzamiento %></th>
    <%--  <th scope="col"><%:album.ImgTapa %></th>
      <th scope="col"><%:album.ImgContratapa %></th>--%>
      <th scope="col"> <%:album.Genero %></th>
      <th scope="col"> <%:album.Categoria %></th>
      <th>
               <% 
                   }
        %> 

       <asp:Button Text="Modificar" CssClass="btn btn-primary"  ID="btnmodificar"    runat="server" />             
      <asp:Button Text="Eliminar" CssClass="btn btn-danger"  ID="btnEliminar"   runat="server" />
      </th>
      </tr>
           
    </tbody>
    </table>
  
</asp:Content>
