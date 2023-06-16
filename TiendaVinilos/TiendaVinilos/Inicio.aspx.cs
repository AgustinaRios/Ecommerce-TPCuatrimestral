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
   
        public partial class Inicio : System.Web.UI.Page
        {
            public List<Album> listaAlbum { get; set; }
            


            protected void Page_Load(object sender, EventArgs e)
            {

                AlbumNegocio negocio = new AlbumNegocio();
                try
                {


                    listaAlbum = negocio.listar();



                }
                catch (Exception ex)
                {
                   
                    throw ex;
                }


            }

        }
}
