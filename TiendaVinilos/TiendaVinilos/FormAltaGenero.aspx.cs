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
    public partial class FormAltaGenero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Genero nuevo = new Genero();
                nuevo.Descripcion = TxtNombre.Text;
                GeneroNegocio negocio = new GeneroNegocio();
                negocio.agregar(nuevo);
                LblMensaje.Text = "Genero agregado exitosamente";
                LblMensaje.Visible = true;

                Response.Redirect("Generos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Generos.aspx", false);
        }
    }
}