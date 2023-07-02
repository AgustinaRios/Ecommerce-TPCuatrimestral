using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TiendaVinilos
{
    public partial class Detalle : System.Web.UI.Page
    {

        public List<Album> listaproducto { get; set; }

        public Album albumSeleccionado { get; set; }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              if (Request.QueryString["id"] != null)
                {
                Int32 id =Int32.Parse(Request.QueryString["id"]);          
                AlbumNegocio negocio = new AlbumNegocio();
                albumSeleccionado = negocio.ObtenerAlbum(id);
                Session.Add("producto", albumSeleccionado);                                  
                    Session.Add("idArtCarrito", id);
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