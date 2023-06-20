using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TiendaVinilos
{
    public partial class Listar : System.Web.UI.Page
    {
        public List<Album> listaAlbum { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

            AlbumNegocio negocio = new AlbumNegocio();
            try
            {

                if (!IsPostBack)
                {
                    listaAlbum = negocio.listar();

                    repRepetidor.DataSource = negocio.listar();
                    repRepetidor.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("Formulario.aspx?Id=" + Id, false);

        }

        protected void BtnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario.aspx");
        }
       



    }
}