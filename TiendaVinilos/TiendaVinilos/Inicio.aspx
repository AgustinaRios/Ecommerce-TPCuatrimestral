﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TiendaVinilos.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent"  runat="server">
    
        
    <div id="carouselExampleIndicators" class="carousel slide">
  <div class="carousel-indicators">
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
  </div>
  <div class="carousel-inner" >
    <div class="carousel-item active">
      <img src="https://tap-multimedia-1156.nyc3.digitaloceanspaces.com/slider/3966/large/COMPU.jpg" class="ImgCarrusel" alt="...">
    </div>
    <div class="carousel-item">
      <img src="https://tap-multimedia-1156.nyc3.digitaloceanspaces.com/slider/3649/large/slider_COMPU_METALLICA.jpg" class="ImgCarrusel" alt="...">
    </div>
    <div class="carousel-item">
      <img  src="https://tap-multimedia-1156.nyc3.digitaloceanspaces.com/slider/2484/large/slider_COMPU_EADDA.jpg" class="ImgCarrusel" alt="...">
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

       
      <div class="row row-cols-1 row-cols-md-5 g-4 " >
        <% 
            foreach (Dominio.Album album in listaAlbum)
            {
        %>

        <updatepanel >
                <contentemplate>

           
            <div class="card">               
                <img src="<%:album.ImgTapa%>"  class="ImgCard" alt=".Imagen del producto">
                <div class="bodyvinilo">
                    <p class="card-text"> "<%:album.Titulo %>"</p>  
                    <p class="card-text"> <%:album.Artista %></p>  
                    <div class="col">
                    <a href="Inicio.aspx?id=<%:album.Id %>"> <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512"><!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d="M0 24C0 10.7 10.7 0 24 0H69.5c22 0 41.5 12.8 50.6 32h411c26.3 0 45.5 25 38.6 50.4l-41 152.3c-8.5 31.4-37 53.3-69.5 53.3H170.7l5.4 28.5c2.2 11.3 12.1 19.5 23.6 19.5H488c13.3 0 24 10.7 24 24s-10.7 24-24 24H199.7c-34.6 0-64.3-24.6-70.7-58.5L77.4 54.5c-.7-3.8-4-6.5-7.9-6.5H24C10.7 48 0 37.3 0 24zM128 464a48 48 0 1 1 96 0 48 48 0 1 1 -96 0zm336-48a48 48 0 1 1 0 96 48 48 0 1 1 0-96z"/></svg></a>                                                                                                      
                    <a href="Detalle.aspx?iddetalle=<%:album.Id %>" class="btn btn-success">Detalle</a>
                    </div>
                    </div>        
            </div>
        
        
                      </contentemplate>
            </updatepanel>

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
  
</asp:Content>
