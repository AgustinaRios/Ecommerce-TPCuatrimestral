using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
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

                Int32 IdGenero = Int32.Parse(Request.QueryString["idgenero"]);
                Session.Add("idGenero", IdGenero);

                listaAlbum = negocio.listarxGenero(IdGenero);
                Session.Add("Listaalbum", listaAlbum);

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