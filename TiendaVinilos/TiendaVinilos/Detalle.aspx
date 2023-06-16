<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TiendaVinilos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="demo" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <div class="card">
                        
                        <% 
                            Dominio.Album album = albumSeleccionado;

                        %>
                        <div class="row">
                            <div class="col-md-6 text-center align-self-center">
                                <img class="img-fluid" src="<%= album.ImgTapa %>">
                                <img class="img-fluid" src="<%= album.ImgContratapa %>">
                            </div>
                            <div class="col-md-6 info">
                                <div class="row title">
                                    <div class="col">
                                        <h2><%= album.Titulo %></h2>
                                    </div>
                                    <div class="col text-right"><a href="#"><i class="fa fa-heart-o"></i></a></div>
                                </div>
                                
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star-half-full"></span>
                             
                                <div class="row price">
                                    <label class="radio">
                                       
                                        <span>
                                            <div class="row"><big><b>Artista: <%= album.Artista %></b></big></div>
                                            <div class="row"><big><b>Fecha Lanzamiento: <%= album.FechaLanzamiento%></b></big></div>
                                            <div class="row"><big><b>Genero: <%= album.Genero %></b></big></div>
                                            <div class="row"><big><b>Categoria: <%= album.Categoria %></b></big></div>
                                            <div class="row"><big><b>Precio: $<%= album.Precio %></b></big></div>
                                            </a> </span>
                                    </label>

                                </div>
                            </div>
                        </div>

                        <button type="button" id="btn Carrito" class="btn btn-primary" data-toggle="button" aria-pressed="false" autocomplete="off">
                            Agregar Carrito
                        </button>
                    </div>
                </div>
            </div>
        </div>


    </div>

    <%--OTRO DISEÑO DE BOOTSTRAP PERO HABRIA QUE ARREGLAR EL ENCABEZADO
                PARA VER CUAL QUEDA MEJOR--%>

    <%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <% 
                            Dominio.Album album = albumSeleccionado;

                        %>
    <div class='container-fluid'>
        <div class="card mx-auto col-md-3 col-10 mt-5">
            <img class='mx-auto img-thumbnail'
                src="<%=album.ImgTapa%>"
                 <%--src="<%album.ImgContratapa %>"--%>
    <%--  width="auto" height="auto"/>
            <div class="card-body text-center mx-auto">
                <div class='cvp'>
                    <h5 class="card-title font-weight-bold">Yail wrist watch</h5>
                    <p class="card-text">$299</p>
                    <a href="#" class="btn details px-auto">view details</a><br />
                    <a href="#" class="btn cart px-auto">ADD TO CART</a>
                </div>
            </div>
        </div>

    </div>--%>
</asp:Content>
