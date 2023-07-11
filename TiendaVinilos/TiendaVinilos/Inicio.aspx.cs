using Dominio;
using Negocio;
using System;
using System.Collections.Generic;

namespace TiendaVinilos
{

    public partial class Inicio : System.Web.UI.Page
    {
        public List<Album> listaAlbum { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("FiltroBusqueda", 2);
            AlbumNegocio negocio = new AlbumNegocio();
            try
            {

                     listaAlbum = negocio.listar();
                     Session.Add("Listaalbum", listaAlbum);
                

                if (Request.QueryString["id"] != null)
                {
                    Int32 IdArt = Int32.Parse(Request.QueryString["id"]);
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