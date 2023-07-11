using Dominio;
using Negocio;
using System;
using System.Collections.Generic;


namespace TiendaVinilos
{
    public partial class AlbumFiltrado : System.Web.UI.Page
    {
        public List<Album> listaAlbum { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("FiltroBusqueda", 2);
            AlbumNegocio negocio = new AlbumNegocio();
            try
            {
                //no va a carrito terminar la logica

                if (Request.QueryString["idfiltrado"] != null)
                {
                    Int32 IdArt = Int32.Parse(Request.QueryString["idfiltrado"]);
                    Session.Add("idArtCarrito", IdArt);

                    Session.Add("items", 1);


                }
                listaAlbum = (List<Album>)Session["listaFiltrada"];

                if (listaAlbum != null)
                {

                    Session.Add("listaAlbum", listaAlbum);

                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);

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