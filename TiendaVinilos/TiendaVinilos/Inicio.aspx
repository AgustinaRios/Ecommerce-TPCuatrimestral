<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Inicio.aspx.cs" Inherits="TiendaVinilos.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://th.bing.com/th/id/OIP.XQ5p_6YS8JmhoJZD0UUBZQHaEo?pid=ImgDet&rs=1" class="ImgCarrusel" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://th.bing.com/th/id/OIP.eY27L9dvKNZ9I4vCnXq--AHaE7?pid=ImgDet&rs=1" class="ImgCarrusel" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://www.safesound.se/wp-content/gallery/banner/banner_qsc_800x250.jpg" class="ImgCarrusel" alt="...">
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
        <div class="row row-cols-1 row-cols-md-5 g-4 ">
            <% 
                foreach (Dominio.Album album in listaAlbum)
                {
            %>

            <updatepanel>
                <contentemplate>
                    <div class="card">
                        <img src="<%:album.ImgTapa%>" class="ImgCard" alt=".Imagen del producto">
                        <div class="bodyvinilo">
                            <p class="card-text">"<%:album.Titulo %>"</p>
                            <p class="card-text"><%:album.Artista %></p>
                            <p class="card-precio">$<%:album.Precio %></p>
                            <div class="col">
                                <a href="Detalle.aspx?iddetalle=<%:album.Id %>" class="btn btn-success">Detalle</a>
                                <a href="Inicio.aspx?id=<%:album.Id %>">
                                    <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512">
                                        <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                        <path d="M0 24C0 10.7 10.7 0 24 0H69.5c22 0 41.5 12.8 50.6 32h411c26.3 0 45.5 25 38.6 50.4l-41 152.3c-8.5 31.4-37 53.3-69.5 53.3H170.7l5.4 28.5c2.2 11.3 12.1 19.5 23.6 19.5H488c13.3 0 24 10.7 24 24s-10.7 24-24 24H199.7c-34.6 0-64.3-24.6-70.7-58.5L77.4 54.5c-.7-3.8-4-6.5-7.9-6.5H24C10.7 48 0 37.3 0 24zM128 464a48 48 0 1 1 96 0 48 48 0 1 1 -96 0zm336-48a48 48 0 1 1 0 96 48 48 0 1 1 0-96z" />
                                    </svg></a>
                            </div>
                        </div>
                    </div>
                </contentemplate>
            </updatepanel>

            <%}%>
        </div>
    </div>
</asp:Content>
