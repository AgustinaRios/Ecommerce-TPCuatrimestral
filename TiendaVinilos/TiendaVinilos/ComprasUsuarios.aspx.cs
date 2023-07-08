using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVinilos
{
   
    public partial class ComprasUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string buscar = Request.QueryString["buscar"];

                if (!string.IsNullOrEmpty(buscar))
                {
                    PedidoNegocio pedidoNegocio = new PedidoNegocio();
                    List<PedidoConUsuario> listaPedidosConUsuario = pedidoNegocio.Listar(buscar);
                    GridViewPedidos.DataSource = listaPedidosConUsuario;
                    GridViewPedidos.DataBind();
                }
                else if (Session["listaCompras"] != null)
                {
                    List<PedidoConUsuario> listaCompras = (List<PedidoConUsuario>)Session["listaCompras"];
                    GridViewPedidos.DataSource = listaCompras;
                    GridViewPedidos.DataBind();
                }
                else
                {
                    PedidoNegocio pedidoNegocio = new PedidoNegocio();
                    List<PedidoConUsuario> listaPedidosConUsuario = pedidoNegocio.ListarTodos();
                    GridViewPedidos.DataSource = listaPedidosConUsuario;
                    GridViewPedidos.DataBind();
                }
            }

        }

       

       

    }
}

