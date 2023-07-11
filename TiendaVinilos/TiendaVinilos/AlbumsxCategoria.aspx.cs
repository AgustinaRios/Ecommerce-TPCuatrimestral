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
            Session.Add("FiltroBusqueda", 2);
            AlbumNegocio negocio = new AlbumNegocio();
            try
            {
                string Id = Request.QueryString["IdCategoria"];
                if (Id != null)
                {
                    Int32 IdCat = Int32.Parse(Request.QueryString["IdCategoria"]);
                    Session.Add("IdCategoria", IdCat);//se la necesita por que se pierde el id del gnero cuando se recrga la pg,por ejemplo cuando haces clic en btncarrito
                    listaAlbum = negocio.listarxCategoria(IdCat);
                    Session.Add("Listaalbum", listaAlbum);
                }
                else
                {
                    //si idgnero es nulo quiere decir que se cargo la pag por hacer click en btncarrito
                    Int32 IdCat = (Int32)Session["IdCategoria"];
                    listaAlbum = negocio.listarxCategoria(IdCat);
                    Session.Add("Listaalbum", listaAlbum);
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