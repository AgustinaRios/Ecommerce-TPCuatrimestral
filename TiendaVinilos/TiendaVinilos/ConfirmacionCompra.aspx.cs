using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace TiendaVinilos
{
    public partial class ConfirmacionCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Pedido"] != null)
                {
                    Pedido pedido = (Pedido)Session["Pedido"];
                    ProductosCarrito carrito = (ProductosCarrito)Session["carrito"];

                    LblMensaje.Text = "¡Su compra se generó con éxito!  Recibirás un correo electrónico para seguir el estado de tu pedido";
                    LblMensaje.Visible = true;
                    LblIdPedido.Text = pedido.Id.ToString();
                    LblDireccion.Text = pedido.Direccion;
                    LblLocalidad.Text = pedido.Localidad;
                    LblProvincia.Text = pedido.Provincia;

                    // Configurar las columnas del GridView
                    BoundField bfTitulo = new BoundField();
                    bfTitulo.DataField = "Titulo";
                    bfTitulo.HeaderText = "Título";

                    BoundField bfArtista = new BoundField();
                    bfArtista.DataField = "ArtistaNombre"; 
                    bfArtista.HeaderText = "Artista";

                    BoundField bfCantidad = new BoundField();
                    bfCantidad.DataField = "Cantidad";
                    bfCantidad.HeaderText = "Cantidad";

                    BoundField bfSubtotal = new BoundField();
                    bfSubtotal.DataField = "SubTotal";
                    bfSubtotal.HeaderText = "Subtotal";
                    bfSubtotal.DataFormatString = "{0:C}";

                    // Agregar las columnas al GridView
                    GridViewProductos.Columns.Add(bfTitulo);
                    //GridViewProductos.Columns.Add(bfArtista);
                    GridViewProductos.Columns.Add(bfCantidad);
                    GridViewProductos.Columns.Add(bfSubtotal);

                    GridViewProductos.DataSource = carrito.lista.Select(item => new
                    {
                        item.Producto.Titulo,
                        
                        item.Cantidad,
                        item.SubTotal
                    }).ToList();

                    GridViewProductos.DataBind();

                    LblTotal.Text = carrito.totalCarrito(carrito).ToString();

                    // Establecer el carrito en cero
                    ProductosCarrito carritoEnCero = (ProductosCarrito)Session["carrito"];
                    carrito.lista.Clear();
                    Session["carrito"] = carritoEnCero;

                    Session["carrito"] = new ProductosCarrito();
                    carrito = (ProductosCarrito)Session["carrito"];

                    // Reiniciar el contador de elementos
                    Session["ItemCount"] = 0;
                }

                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuario = (Usuario)Session["usuario"];
                int id = usuario.ID;
                usuario = usuarioNegocio.ObtenerUsuarioPorId(id);

                EmailService emailService = new EmailService();
                string resultadoEnvio = emailService.EnviarCorreo(usuario.Email, "Confirmación de compra", "Gracias por elegirnos! Su pedido a sido confirmado y se encuentra en preparación, será notificado por este medio sobre el estado del mismo.");


            }
        }
    }
}