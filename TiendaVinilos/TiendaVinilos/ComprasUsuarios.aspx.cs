using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVinilos
{
    public class PedidoConUsuario
    {
        public Pedido Pedido { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
    }

    public partial class ComprasUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                List<Pedido> listaPedidos = pedidoNegocio.ListarTodos();
                List<PedidoConUsuario> listaPedidosConUsuario = ObtenerPedidosConUsuario(listaPedidos);
                GridViewPedidos.DataSource = listaPedidosConUsuario;
                GridViewPedidos.DataBind();
            }
        }

        private List<PedidoConUsuario> ObtenerPedidosConUsuario(List<Pedido> pedidos)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<PedidoConUsuario> pedidosConUsuario = new List<PedidoConUsuario>();

            foreach (Pedido pedido in pedidos)
            {
                PedidoConUsuario pedidoConUsuario = new PedidoConUsuario();
                pedidoConUsuario.Pedido = pedido;

                Usuario usuario = usuarioNegocio.ObtenerUsuarioPorId(pedido.IdUsuario);
                if (usuario != null)
                {
                    pedidoConUsuario.NombreUsuario = usuario.Nombre;
                    pedidoConUsuario.ApellidoUsuario = usuario.Apellido;
                }

                pedidosConUsuario.Add(pedidoConUsuario);
            }

            return pedidosConUsuario;
        }

        protected void GridViewPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PedidoConUsuario pedidoConUsuario = (PedidoConUsuario)e.Row.DataItem;

                Label lblNombre = (Label)e.Row.FindControl("lblNombre");
                lblNombre.Text = pedidoConUsuario.NombreUsuario;

                Label lblApellido = (Label)e.Row.FindControl("lblApellido");
                lblApellido.Text = pedidoConUsuario.ApellidoUsuario;
            }
        }

    }
}

