<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumsxGenero.aspx.cs" Inherits="TiendaVinilos.AlbumsxGenero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid"> 
         <br /> 

       <div class="container">
    <div class="row row-cols-2 row-cols-lg-5 g-2 g-lg-3">
        <% 
            foreach (Dominio.Album album in listaAlbum)
            {
        %> 
        
        <div class="col">
           <div class="shadow-lg p-3 mb-5 bg-body-tertiary rounded">
            <div class="card" >
                <img src="<%:album.ImgTapa%>" class="card-img-top" alt=".Imagen del producto">
                <div class="card-body">
                    <h5 class="card-title"><%:album.Titulo%></h5>
                    <p class="card-text"> <%:album.Artista %></p>
                    <p class="card-text"> <%:album.FechaLanzamiento %></p>
                     <div class="d-grid gap-2">
                     <a href="Detalle.aspx?id=<%:album.Id %>" class="btn btn-success">Ver Detalle</a>
                     <a href="Inicio.aspx?id=<%:album.Id %>" class="btn btn-success">Carrito</a>
                    </div>                                   
                </div>
            </div>
            </div>
         </div>
          <%}%>
     </div>   
</div>   
    <br />
    <nav aria-label="...">
  <ul class="pagination">
    <li class="page-item disabled">
      <span class="page-link">Previous</span>
    </li>
    <li class="page-item"><a class="page-link" href="#">1</a></li>
    <li class="page-item active" aria-current="page">
      <span class="page-link">2</span>
    </li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
    <li class="page-item">
      <a class="page-link" href="#">Next</a>
    </li>
  </ul>
</nav>
    </div>
    
</asp:Content>
