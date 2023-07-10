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
    public partial class MisCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["usuario"];
          
            int id = usuario.ID;

            PedidoNegocio negocio = new PedidoNegocio();
           List<Pedido> listaCompras = new List<Pedido>();
            listaCompras = negocio.BuscarPorIdUsuario(id);
            GridViewPedidos.DataSource = listaCompras;
            GridViewPedidos.DataBind();
        }
    }
}