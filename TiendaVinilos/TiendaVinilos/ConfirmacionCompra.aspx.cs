using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVinilos
{
    public partial class ConfirmacionCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Pedido pedido = (Pedido)Session["Pedido"];

               
                ProductosCarrito carrito = (ProductosCarrito)Session["carrito"];

               
            }
        }
    }
}