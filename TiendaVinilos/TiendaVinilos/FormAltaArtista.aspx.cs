using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVinilos
{
    public partial class FormAltaArtista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Artista nuevo = new Artista();
                nuevo.Nombre = TxtNombre.Text;
                ArtistaNegocio negocio = new ArtistaNegocio();
                negocio.agregar(nuevo);
                LblMensaje.Text = "Artista agregado exitosamente";
                LblMensaje.Visible = true;

                Response.Redirect("Artistas.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}