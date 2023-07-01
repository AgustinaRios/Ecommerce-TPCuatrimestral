using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
namespace TiendaVinilos
{
    public partial class AlbumsxGenero : System.Web.UI.Page
    {
        public List<Album> listaAlbum { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            AlbumNegocio negocio = new AlbumNegocio();
            try
            {
                if (Request.QueryString["idgenero"] != null)
                {
                    Int32 IdGenero = Int32.Parse(Request.QueryString["idgenero"]);
                    Session.Add("id", IdGenero);//se la necesita por que se pierde el id del gnero cuando se recrga la pg,por ejemplo cuando haces clic en btncarrito
                    listaAlbum = negocio.listarxGenero(IdGenero);
                    Session.Add("Listaalbum", listaAlbum);
                }
                else
                {
                    //si idgnero es nulo quiere decir que se cargo la pag por hacer click en btncarrito
                    Int32 IdGenero2 = (Int32)Session["idgenero"];
                    listaAlbum = negocio.listarxGenero(IdGenero2);
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