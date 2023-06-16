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

                string ID = Request.QueryString["id"];
                int id = Int32.Parse(ID);

                AlbumNegocio negocio = new AlbumNegocio();

                albumSeleccionado = negocio.ObtenerAlbum(id);
                Session.Add("producto", albumSeleccionado);



            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }


        }




    }
}