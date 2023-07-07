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
                if (Request.QueryString["iddetalle"] != null)
                {
                    Int32 id = Int32.Parse(Request.QueryString["iddetalle"]);
                    AlbumNegocio negocio = new AlbumNegocio();
                    albumSeleccionado = negocio.ObtenerAlbum(id);
                    Session.Add("Id", id);
                    Session.Add("producto", albumSeleccionado);

                }
                else
                {
                    //si id es nulo quiere decir que se cargo la pag por hacer click en btncarrito
                    Int32 Id = (Int32)Session["Id"];
                    AlbumNegocio negocio = new AlbumNegocio();
                    albumSeleccionado = negocio.ObtenerAlbum(Id);
                    Session.Add("producto", albumSeleccionado);
                }
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