using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace TiendaVinilos
{
    public partial class Domicilio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            Pedido domicilio = new Pedido();
            if (TxtDireccion.Text == "" || TxtLocalidad.Text == "" || TxtProvincia.Text == "")
            {
                LblMensaje.Text = "Complete todos los campos";
                LblMensaje.Visible = true;
                return;

            }
            else
            {

                domicilio.Direccion = TxtDireccion.Text;
                domicilio.Localidad = TxtLocalidad.Text;
                domicilio.Provincia = TxtProvincia.Text;
                Session.Add("DomicilioEntrega", domicilio);
                Response.Redirect("FormularioCompra.aspx", false);
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioCompra.aspx", false);
        }
    }
}