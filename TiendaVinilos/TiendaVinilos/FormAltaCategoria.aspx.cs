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
    public partial class FormAltaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Categoria nuevo = new Categoria();
                nuevo.Descripcion= TxtDescripcion.Text;
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.agregar(nuevo);
                LblMensaje.Text = "Categoria agregada exitosamente";
                LblMensaje.Visible = true;

                Response.Redirect("Categorias.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);

            }


        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nuevo = new Categoria();
                nuevo.Descripcion = TxtDescripcion.Text;
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.agregar(nuevo);
                LblMensaje.Text = "Categoría agregada exitosamente";
                LblMensaje.Visible = true;

                Response.Redirect("Categorias.aspx", false);

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