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

    <div class="ContenedorPrincipal">
              <div class="container-Formularios"style="width: 850px; height: 450px; margin-top: 20px">
            <div class="card">
                <% Dominio.Album album = albumSeleccionado; %>
                <div class="row">
                    <div class="col-md-6 text-center">
                        <div id="albumCarousel" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner" >
                                <div class="carousel-item active">
                                    <img class="img-fluid rounded" style="width: 350px; height: 350px;" src="<%= album.ImgTapa %>" alt="Tapa del álbum">
                                </div>
                                <% if (album.ImgContratapa != null)

                                    { %>
                                <div class="carousel-item">
                                    <img class="img-fluid rounded" style="width: 350px; height: 350px;" src="<%= album.ImgContratapa %>" alt="Contratapa del álbum">
                                </div>
                                <%} %>
                            </div>
                            <a class="carousel-control-prev" href="#albumCarousel" role="button" data-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="sr-only" style="color: #0000FF"></span>
                            </a>
                            <a class="carousel-control-next" href="#albumCarousel" role="button" data-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="sr-only" style="color: #0000FF"></span>
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
                        <div class="row">
                            <div class="col">
                                <h2 style="font-size-adjust:inherit"><%= album.Titulo %></h2>
                            </div>
                            <div class="col">
                                <a href="Detalle.aspx?id=<%: album.Id %>">
                                     <svg xmlns="http://www.w3.org/2000/svg" height="1em" viewBox="0 0 576 512">
                                        <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                        <path d="M0 24C0 10.7 10.7 0 24 0H69.5c22 0 41.5 12.8 50.6 32h411c26.3 0 45.5 25 38.6 50.4l-41 152.3c-8.5 31.4-37 53.3-69.5 53.3H170.7l5.4 28.5c2.2 11.3 12.1 19.5 23.6 19.5H488c13.3 0 24 10.7 24 24s-10.7 24-24 24H199.7c-34.6 0-64.3-24.6-70.7-58.5L77.4 54.5c-.7-3.8-4-6.5-7.9-6.5H24C10.7 48 0 37.3 0 24zM128 464a48 48 0 1 1 96 0 48 48 0 1 1 -96 0zm336-48a48 48 0 1 1 0 96 48 48 0 1 1 0-96z" />
                                    </svg>
                                </a>
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
                </div>
            </div>
        </div>
    </div>


</asp:Content>
