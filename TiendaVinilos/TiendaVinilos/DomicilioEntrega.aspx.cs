using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Dominio;
namespace TiendaVinilos
{
    public partial class Domicilio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        bool ValidarVacios()
        {

           
            TxtDireccion.BorderColor = Color.White;
            TxtLocalidad.BorderColor = Color.White;
            TxtProvincia.BorderColor = Color.White;

            bool vacios = false;
            
            if (TxtDireccion.Text == "")
            {
                TxtDireccion.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtLocalidad.Text == "")
            {
                TxtLocalidad.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtProvincia.Text == "")
            {
                TxtProvincia.BorderColor = Color.Red;
                vacios = true;
            }

            return vacios;
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            Pedido domicilio = new Pedido();
            if (ValidarVacios()==true)
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