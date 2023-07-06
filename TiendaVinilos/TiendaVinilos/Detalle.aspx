<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TiendaVinilos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilos personalizados */
        .album-details {
            margin-top: 20px;
        }

        .album-details h2 {
            font-size: 24px;
            color: #333;
        }

        .rating {
            margin-bottom: 10px;
        }

        .rating .fa-star {
            color: #f1c40f;
        }

        .rating .fa-star-half-full {
            color: #f1c40f;
        }

        .artist,
        .release-date,
        .genre,
        .category,
        .price {
            font-size: 16px;
            color: #666;
            margin-bottom: 5px;
        }

        .price {
            font-weight: bold;
            color: #f1c40f;
        }
    </style>

    <div class="CuerpoRegistro">
        <div class="container">
            <div class="card">
                <% Dominio.Album album = albumSeleccionado; %>
                <div class="row">
                    <div class="col-md-6 text-center">
                        <div id="albumCarousel" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <img class="img-fluid rounded" src="<%= album.ImgTapa %>" alt="Tapa del álbum">
                                </div>
                                <div class="carousel-item">
                                    <img class="img-fluid rounded" src="<%= album.ImgContratapa %>" alt="Contratapa del álbum">
                                </div>
                            </div>
                            <a class="carousel-control-prev" href="#albumCarousel" role="button" data-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="sr-only">Anterior</span>
                            </a>
                            <a class="carousel-control-next" href="#albumCarousel" role="button" data-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="sr-only">Siguiente</span>
                            </a>
                        </div>
                        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
                        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>
                        <script>
                            $(document).ready(function () {
                                $('.carousel').carousel();
                            });
                        </script>
                    </div>
                  <div class="col-md-6 info">
    <div class="row title">
        <div class="col">
            <h2><%= album.Titulo %></h2>
        </div>
        <div class="col text-right">
            <a href="Detalle.aspx?id=<%: album.Id %>"><i class="fa-solid fa-cart-plus"></i></a>
        </div>
    </div>
    <div class="rating">
        <span class="fa fa-star checked"></span>
        <span class="fa fa-star checked"></span>
        <span class="fa fa-star checked"></span>
        <span class="fa fa-star checked"></span>
        <span class="fa fa-star-half-full"></span>
    </div>
    <div class="row album-details">
        <div class="col">
            <p class="artist"><b>Artista:</b> <%= album.Artista %></p>
            <p class="release-date"><b>Fecha Lanzamiento:</b> <%= album.FechaLanzamiento %></p>
            <p class="genre"><b>Género:</b> <%= album.Genero %></p>
            <p class="category"><b>Categoría:</b> <%= album.Categoria %></p>
            <p class="price"><b>Precio:</b> $<%= album.Precio %></p>
        </div>
    </div>
</div>
                        

</asp:Content>