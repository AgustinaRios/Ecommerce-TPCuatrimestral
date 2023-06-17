<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TiendaVinilos.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
   
  <div id="carouselExampleIndicators" class="carousel slide">
  <div class="carousel-indicators">
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
  </div>
  <div class="carousel-inner" >
    <div class="carousel-item active">
      <img src="https://tap-multimedia-1156.nyc3.digitaloceanspaces.com/slider/3966/large/COMPU.jpg" class="d-block w-100 " alt="...">
    </div>
    <div class="carousel-item">
      <img src="https://tap-multimedia-1156.nyc3.digitaloceanspaces.com/slider/3649/large/slider_COMPU_METALLICA.jpg" class="d-block w-100 " alt="...">
    </div>
    <div class="carousel-item">
      <img src="https://tap-multimedia-1156.nyc3.digitaloceanspaces.com/slider/2484/large/slider_COMPU_EADDA.jpg" class="d-block w-100 " alt="...">
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>
    <br />
      <div class="container">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <% 
            foreach (Dominio.Album album in listaAlbum)
            {
        %> 
        
        <div class="col">
           <div class="shadow-lg p-3 mb-5 bg-body-tertiary rounded">
            <div class="card">
                <img src="<%:album.ImgTapa%>" class="card-img-top" alt=".Imagen del producto">
                <div class="card-body">
                    <h5 class="card-title"><%:album.Titulo%></h5>
                    <p class="card-text"> <%:album.Artista %></p>
                    <p class="card-text"> <%:album.FechaLanzamiento %></p>
                     <div class="columnas">
                    <a href="Detalle.aspx?id=<%:album.Id %>" class="btn btn-success">Ver Detalle</a>
                    <a href="Carrito.aspx?id=<%:album.Id %>" class="btn btn-success">Carrito</a>
                    </div>
                </div>
            </div>
            </div>
         </div>
          <%}%>
     </div>
    
    
</div>

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
</asp:Content>
