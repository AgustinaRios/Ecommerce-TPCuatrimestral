using Dominio;
using Negocio;
using System;
using System.Collections.Generic;

namespace TiendaVinilos
{
    public partial class AlbumsxCategoria : System.Web.UI.Page
    {
        public List<Album> listaAlbum = new List<Album>();
        protected void Page_Load(object sender, EventArgs e)
        {

            AlbumNegocio negocio = new AlbumNegocio();
            try
            {
                string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if (Id != null)
                {
                    Int32 IdCategoria = Int32.Parse(Request.QueryString["Id"]);
                    Session.Add("Id", IdCategoria);//se la necesita por que se pierde el id del gnero cuando se recrga la pg,por ejemplo cuando haces clic en btncarrito
                    listaAlbum = negocio.listarxCategoria(IdCategoria);
                    Session.Add("ListaAlbum", listaAlbum);
                }
                else
                {
                    //si idgnero es nulo quiere decir que se cargo la pag por hacer click en btncarrito
                    Int32 IdCategoria = (Int32)Session["Id"];
                    listaAlbum = negocio.listarxCategoria(IdCategoria);
                    Session.Add("ListaAlbum", listaAlbum);
                }

                if (Request.QueryString["idfiltrado"] != null)
                {
                    Int32 IdArt = Int32.Parse(Request.QueryString["idfiltrado"]);
                    Session.Add("idArtCarrito", IdArt);

                    Session.Add("items", 1);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }



    }
}